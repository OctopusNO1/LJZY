# LJZY

#### 介绍
这是新疆克拉玛依录井管理系统。

#### 软件架构
系统采用ADO.NET三层架构方式完成  
1.显示层LJZY.WEB:用户输入的数据和显示处理后用户需要的数据。  
2.业务逻辑层LJZY.BLL:对数据层的操作，对数据业务逻辑处理。  
3.数据访问层LJZY.DAO:实现对数据的增、删、改、查。将存储在数据库中的数据提交给业务层，同时将业务层处理的数据保存到数据库。  
4.实体类库LJZY.MODEL:建立数据库中的表字段的实体类。  
5.公共帮助类库LJZY.COMMON:一些公共方法的代码。  
6.数据库应用层LJZY.DBUtility:访问数据库的通用代码。  
7.ExtendsDLL:存放一些引用的dll文件的文件夹  

开发环境: Windows系统、IIS部署网站  
.NET版本号: .NET Framework 4.5

#### 安装教程
安装visual studio 2017，打开项目。  
安装Oracle 11g 32位，导入数据库文件。（在other_sources中有导入说明，安装包未上传）  
将IIS设置为32位，发布系统，登陆成功即可。  

#### 参与贡献

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

#### 码云特技

1. 使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2. 码云官方博客 [blog.gitee.com](https://blog.gitee.com)
3. 你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解码云上的优秀开源项目
4. [GVP](https://gitee.com/gvp) 全称是码云最有价值开源项目，是码云综合评定出的优秀开源项目
5. 码云官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6. 码云封面人物是一档用来展示码云会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)