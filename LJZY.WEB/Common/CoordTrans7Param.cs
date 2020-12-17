using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Common
{
    public class CoordTrans7Param
    {
        public double[,] values = new double[7, 1];
        //{{dx},{dy},{dz},{rx},{ry},{rz},{k}};
        //public double dx,dy,dz,rx,ry,rz,k;
        public void Set4Param(double dx, double dy, double dz, double k)
        {
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
            this.k = k;
            this.rx = this.ry = this.rz = 0;

        }
        public void SetRotationParamRad(double rx, double ry, double rz)
        {
            this.rx = rx;
            this.ry = ry;
            this.rz = rz;
        }
        public void SetRotationParamMM(double rx, double ry, double rz)
        {
            SetRotationParamRad(rx * Math.PI / 648000, ry * Math.PI / 648000, rz * Math.PI / 648000);
        }
        private double[,] GetMx()
        {
            double[,] Mx = new double[,]
            {{1,0,0},
{0,Math.Cos(rx),Math.Sin(rx)},
{0,-Math.Sin(rx),Math.Cos(rx)}};
            return Mx;
        }
        private double[,] GetMy()
        {
            double[,] My = new double[,]
            {{Math.Cos(ry),0,-Math.Sin(ry)},
{0,1,0},
{Math.Sin(ry),0,Math.Cos(ry)}};
            return My;
        }
        private double[,] GetMz()
        {
            double[,] Mz = new double[,]
            {{Math.Cos(rz),Math.Sin(rz),0},
{-Math.Sin(rz),Math.Cos(rz),0},
{0,0,1}};
            return Mz;
        }

        private double[,] GetM() //M=Mx*My*Mz? or M=Mz*My*Mx?
        {
            double[,] M = new double[3, 3];

            MatrixTool.Multi(GetMz(), GetMy(), ref M);
            MatrixTool.Multi(M, GetMx(), ref M);
            return M;
        }
        private double[,] GetMdx()
        {
            double[,] mt = {{ 0, 0, 0 },
{ 0, -Math.Sin(rx), Math.Cos(rx) },
{ 0, -Math.Cos(rx), -Math.Sin(rx) }};

            double[,] m = new double[3, 3];

            MatrixTool.Multi(GetMz(), GetMy(), ref m);
            MatrixTool.Multi(m, mt, ref m);
            return m;
        }
        private double[,] GetMdy()
        {
            double[,] mt = {{ -Math.Sin(ry), 0, -Math.Cos(ry) },
{ 0, 0, 0 },
{ Math.Cos(ry), 0, -Math.Sin(ry) }};

            double[,] m = new double[3, 3];

            MatrixTool.Multi(GetMz(), mt, ref m);
            MatrixTool.Multi(m, GetMx(), ref m);
            return m;
        }

        private double[,] GetMdz()
        {
            double[,] mt = {{ -Math.Sin(rz), Math.Cos(rz), 0 },
{ -Math.Cos(rz), -Math.Sin(rz), 0 },
{ 0, 0, 0 }};

            double[,] m = new double[3, 3];

            MatrixTool.Multi(mt, GetMy(), ref m);
            MatrixTool.Multi(m, GetMx(), ref m);
            return m;
        }
        private double[,] specialMulti(double[,] m, double[,] X)
        {
            int rowNumM = m.GetLength(0);
            int colNumM = m.GetLength(1);
            int rowNumX = X.GetLength(0);
            int colNumX = X.GetLength(1);
            int lines = rowNumX / colNumM;
            double[,] mt = MatrixTool.Init(rowNumM, colNumX);
            double[,] subX = MatrixTool.Init(colNumM, colNumX);
            double[,] res = MatrixTool.Init(rowNumM * lines, colNumX);

            for (int i = 0; i < lines; i++)
            {
                MatrixTool.CopySub(X, i * colNumM, 0, colNumM, colNumX, ref subX, 0, 0);
                MatrixTool.Multi(m, subX, ref mt);
                MatrixTool.CopySub(mt, 0, 0, rowNumM, colNumX, ref res, i * rowNumM, 0);
            }
            return res;
        }
        private double[,] specialSub(double[,] m, double[,] X)
        {
            int rowNumM = m.GetLength(0);
            int colNumM = m.GetLength(1);
            int rowNumX = X.GetLength(0);
            int colNumX = X.GetLength(1);
            int lines = rowNumX / rowNumM;
            double[,] subX = MatrixTool.Init(rowNumM, colNumX);
            double[,] res = MatrixTool.Init(rowNumX, colNumX);

            for (int i = 0; i < rowNumX; i += rowNumM)
            {
                MatrixTool.CopySub(X, i, 0, rowNumM, colNumX, ref subX, 0, 0);
                MatrixTool.Sub(m, subX, ref subX);
                MatrixTool.CopySub(subX, 0, 0, rowNumM, colNumX, ref res, i, 0);
            }
            return res;
        }

        private double[,] GetF(double[,] X, double[,] Y)
        {
            double[,] f0;
            double[,] qx = MatrixTool.Init(X.GetLength(0), 1);
            double[,] K = { { -dx }, { -dy }, { -dz } };
            double[,] S = { { 1 + k } };

            MatrixTool.Multi(X, S, ref qx);
            double[,] M = GetM();
            qx = specialMulti(M, qx);
            MatrixTool.Sub(qx, Y, ref qx);
            f0 = specialSub(K, qx);
            return f0;
        }
        private double[,] GetB(double[,] X)
        {
            int rowNum = X.GetLength(0);
            double[,] B = MatrixTool.Init(rowNum, 7);
            double[,] M = GetM();
            double[,] Mdx = GetMdx();
            double[,] Mdy = GetMdy();
            double[,] Mdz = GetMdz();
            double[,] mi = MatrixTool.Ident(3);
            double[,] MX, MY, MZ, MK;

            MK = specialMulti(M, X);
            MX = specialMulti(Mdx, X);
            MY = specialMulti(Mdy, X);
            MZ = specialMulti(Mdz, X);

            for (int i = 0; i < rowNum; i += 3)
                MatrixTool.CopySub(mi, 0, 0, 3, 3, ref B, i, 0);
            MatrixTool.CopySub(MX, 0, 0, rowNum, 1, ref B, 0, 3);
            MatrixTool.CopySub(MY, 0, 0, rowNum, 1, ref B, 0, 4);
            MatrixTool.CopySub(MZ, 0, 0, rowNum, 1, ref B, 0, 5);
            MatrixTool.CopySub(MK, 0, 0, rowNum, 1, ref B, 0, 6);
            return B;
        }
        private double[,] GetA()
        {
            double[,] M = GetM();
            double[,] I2 = MatrixTool.Ident(3);
            double[,] A = MatrixTool.Init(3, 6);

            MatrixTool.MutliConst(ref I2, -1);
            MatrixTool.MutliConst(ref M, (1 + k));
            MatrixTool.CopySub(M, 0, 0, 3, 3, ref A, 0, 0);
            MatrixTool.CopySub(I2, 0, 0, 3, 3, ref A, 0, 3);
            return A;
        }
        private double[,] GetV(double[,] X, double[,] Y, CoordTrans7Param dpp)
        {
            int rowNum = X.GetLength(0);

            double[,] B, F, A, B2, B3, F2, V;
            double[,] AT = MatrixTool.Init(6, 3);

            A = GetA();
            MatrixTool.AT(A, ref AT);
            MatrixTool.MutliConst(ref AT, 1 / (1 + (1 + k) * (1 + k)));

            F = GetF(X, Y);
            B = GetB(X);
            B2 = MatrixTool.Init(3, 7);
            B3 = MatrixTool.Init(3, 1);
            F2 = MatrixTool.Init(rowNum, 1);
            for (int i = 0; i < rowNum / 3; i++)
            {
                MatrixTool.CopySub(B, i * 3, 0, 3, 7, ref B2, 0, 0);
                MatrixTool.Multi(B2, dpp.values, ref B3);
                MatrixTool.CopySub(B3, 0, 0, 3, 1, ref F2, i * 3, 0);
            }
            MatrixTool.Sub(F, F2, ref F2);
            V = specialMulti(AT, F2);
            return V;
        }
        public double CalculateTrans7Param(double[,] X, double[,] Y)
        {
            int PtNum = X.GetLength(0) / 3;
            double[,] B;
            double[,] F;
            double[,] BT = MatrixTool.Init(7, 3 * PtNum);
            double[,] BTB = MatrixTool.Init(7, 7);
            double[,] BTF = MatrixTool.Init(7, 1);


            //init pararm
            CoordTrans7Param dpp = new CoordTrans7Param();
            Set4Param(0, 0, 0, 0);
            this.SetRotationParamMM(0, 0, 0);
            //debug
            //this.TransCoord(X[0,0],X[1,0],X[2,0],out x2,out y2,out z2);
            int round = 0;
            while (round++ < 20)
            {
                F = GetF(X, Y);
                B = GetB(X);
                MatrixTool.AT(B, ref BT);

                MatrixTool.Multi(BT, B, ref BTB);
                MatrixTool.Inv(BTB);
                MatrixTool.Multi(BT, F, ref BTF);
                MatrixTool.Multi(BTB, BTF, ref dpp.values);
                if (dpp.isSmall())
                    break;
                else
                    MatrixTool.Add(this.values, dpp.values, ref this.values);
            }
            //this.TransCoord(X[0,0],X[1,0],X[2,0],out x2,out y2,out z2);
            double[,] V = GetV(X, Y, dpp);

            double vMax = -1;
            for (int i = 0; i < V.GetLength(0); i++)
            {
                if (Math.Abs(V[i, 0]) > vMax)
                    vMax = Math.Abs(V[i, 0]);
            }

            return vMax;
        }
        private bool isSmall()
        {
            double s = 0;
            for (int i = 0; i < 7; i++)
                s += Math.Abs(values[i, 0]);
            if (s < 0.0000001)
                return true;
            else
                return false;
        }
        public void TransCoord(double x1, double y1, double z1, out double x2, out double y2, out double z2)
        {

            double[,] Xi = { { x1 }, { y1 }, { z1 } };
            double[,] DX = { { dx }, { dy }, { dz } };
            double[,] tY = new double[3, 1];
            double[,] K = { { 1 + k } };

            double[,] M = GetM();
            MatrixTool.Multi(Xi, K, ref tY);
            MatrixTool.Multi(M, tY, ref tY);
            MatrixTool.Add(tY, DX, ref tY);
            x2 = tY[0, 0];
            y2 = tY[1, 0];
            z2 = tY[2, 0];
        }

        public double dx
        {
            get
            {
                return values[0, 0];
            }
            set
            {
                values[0, 0] = value;
            }
        }
        public double dy
        {
            get
            {
                return values[1, 0];
            }
            set
            {
                values[1, 0] = value;
            }
        }
        public double dz
        {
            get
            {
                return values[2, 0];
            }
            set
            {
                values[2, 0] = value;
            }
        }
        public double rx
        {
            get
            {
                return values[3, 0];
            }
            set
            {
                values[3, 0] = value;
            }
        }
        public double ry
        {
            get
            {
                return values[4, 0];
            }
            set
            {
                values[4, 0] = value;
            }
        }
        public double rz
        {
            get
            {
                return values[5, 0];
            }
            set
            {
                values[5, 0] = value;
            }
        }
        public double k
        {
            get
            {
                return values[6, 0];
            }
            set
            {
                values[6, 0] = value;
            }
        }
    }

}