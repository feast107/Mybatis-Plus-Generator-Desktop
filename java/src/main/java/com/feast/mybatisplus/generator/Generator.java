package com.feast.mybatisplus.generator;

import com.alibaba.fastjson.JSONObject;
import com.baomidou.mybatisplus.annotation.FieldFill;
import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.core.exceptions.MybatisPlusException;
import com.baomidou.mybatisplus.core.toolkit.StringUtils;
import com.baomidou.mybatisplus.generator.AutoGenerator;
import com.baomidou.mybatisplus.generator.config.*;
import com.baomidou.mybatisplus.generator.config.converts.MySqlTypeConvert;
import com.baomidou.mybatisplus.generator.config.po.LikeTable;
import com.baomidou.mybatisplus.generator.config.querys.MySqlQuery;
import com.baomidou.mybatisplus.generator.config.querys.XuguQuery;
import com.baomidou.mybatisplus.generator.config.rules.DateType;
import com.baomidou.mybatisplus.generator.config.rules.NamingStrategy;
import com.baomidou.mybatisplus.generator.fill.Column;
import com.baomidou.mybatisplus.generator.fill.Property;
import com.baomidou.mybatisplus.generator.keywords.MySqlKeyWordsHandler;
import com.feast.mybatisplus.generator.models.ConfigModel;

import java.io.*;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Generator {
    public static final String AUTHOR = "Feast";
    public static final String DB_ADDRESS = "127.0.0.1";
    public static final String DB_PORT = "3306";
    public static final String DB_URL = "jdbc:mysql://" + DB_ADDRESS + ":" + DB_PORT + "/zbh_group_notes?" +
            "characterEncoding=utf8" +
            "&zeroDateTimeBehavior=convertToNull" +
            "&useSSL=false" +
            "&useJDBCCompliantTimezoneShift=true" +
            "&useLegacyDatetimeCode=false" +
            "&serverTimezone=GMT%2B8" +
            "&allowMultiQueries=true" +
            "&allowPublicKeyRetrieval=true";

    public static final String DB_DRIVER = "com.mysql.cj.jdbc.Driver";
    public static final String DB_USER = "root";
    public static final String DB_PASSWORD = "123456";
    public static final String OUTPUT_DIR = "/src/main/java";

    public static void main(String[] __) {
        String currentDirectory = System.getProperty("user.dir");
        Path jarPath = Paths.get(currentDirectory);
        Path rootPath = Paths.get(jarPath.toUri());
        System.out.println(rootPath);
        if (__.length == 0) {
            System.out.println("没有提供配置文件地址");
        }
        String filename = __[0]; // txt 文件路径
        File config = new File(filename);
        if (!config.exists()) {
            System.out.println("配置文件地址无效");
        }
        try {
            FileInputStream fis = new FileInputStream(filename);
            BufferedReader br = new BufferedReader(new InputStreamReader(fis));

            String line;
            while ((line = br.readLine()) != null) {
                System.out.println(line);
            }

            fis.close();
            br.close();

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void Tmain(String[] __) {

        ConfigModel model = JSONObject.parseObject("",ConfigModel.class);

        IDbQuery query = new XuguQuery();
        new AutoGenerator(
                new DataSourceConfig
                        .Builder(model.getDataSourceConfig().getDbUrl(),
                        model.getDataSourceConfig().getDbUser(),
                        model.getDataSourceConfig().getDbPassword())
                        .dbQuery(model.getDataSourceConfig().getQueryType())
                        .schema("mybatis-plus")
                        .typeConvert(new MySqlTypeConvert())
                        .keyWordsHandler(new MySqlKeyWordsHandler())
                        .build()
        ).global(new GlobalConfig
                        .Builder()
                        .outputDir(System.getProperty("user.dir") + OUTPUT_DIR)//配置输出目录
                        .author(AUTHOR)
                        .enableKotlin()
                        .enableSwagger()
                        .dateType(DateType.TIME_PACK)
                        .commentDate("yyyy-MM-dd")
                        .build())
                .packageInfo(
                        new PackageConfig
                                .Builder()
                                .parent("")//包根目录
                                .moduleName("sys")
                                .entity("model")//实体目录
                                .service("service")//接口目录
                                .serviceImpl("service.impl")//实现目录
                                .mapper("mapper")//映射器目录
                                .xml("mapper.xml")
                                .controller("controller")
                                .build()
                ).injection(//inject
                        new InjectionConfig
                                .Builder()
                                .beforeOutputFile((tableInfo, objectMap) -> {
                                    System.out.println("tableInfo: " + tableInfo.getEntityName() + " objectMap: " + objectMap.size());
                                })
                                //.customMap(Collections.singletonMap("test", "baomidou"))
                                //.customFile(Collections.singletonMap("test.txt", "/templates/test.vm"))
                                .build()
                ).strategy(//strategy
                        new StrategyConfig
                                .Builder()
                                .enableCapitalMode()
                                .enableSkipView()
                                .disableSqlFilter()
                                .likeTable(new LikeTable("USER"))
                                .addInclude("t_simple")
                                .addTablePrefix("t_", "c_")
                                .addFieldSuffix("_flag")
                                .build()
                ).strategy(//entity
                        new StrategyConfig
                                .Builder()
                                .entityBuilder()
//                .superClass(BaseEntity.class)
                                .disableSerialVersionUID()
                                .enableChainModel()
                                .enableLombok()
                                .enableRemoveIsPrefix()
                                .enableTableFieldAnnotation()
                                .enableActiveRecord()
                                .versionColumnName("version")
                                .versionPropertyName("version")
                                .logicDeleteColumnName("deleted")
                                .logicDeletePropertyName("deleteFlag")
                                .naming(NamingStrategy.no_change)
                                .columnNaming(NamingStrategy.underline_to_camel)
                                .addSuperEntityColumns("id", "created_by", "created_time", "updated_by", "updated_time")
                                .addIgnoreColumns("age")
                                .addTableFills(new Column("create_time", FieldFill.INSERT))
                                .addTableFills(new Property("updateTime", FieldFill.INSERT_UPDATE))
                                .idType(IdType.AUTO)
                                .formatFileName("%sEntity")
                                .build()
                ).strategy(//controller
                        new StrategyConfig.Builder()
                                .controllerBuilder()
                                //.superClass(BaseController.class)
                                .enableHyphenStyle()
                                .enableRestStyle()
                                .formatFileName("%sAction")
                                .build()
                ).strategy(//Service策略配置
                        new StrategyConfig
                                .Builder()
                                .serviceBuilder()
//                .superServiceClass(BaseService.class)
//                .superServiceImplClass(BaseServiceImpl.class)
                                .formatServiceFileName("%sService")
                                .formatServiceImplFileName("%sServiceImp")
                                .build()
                )
                .strategy(//mapper
                        new StrategyConfig
                                .Builder()
                                .mapperBuilder()
                                .superClass("")
                                .enableBaseResultMap()
                                .enableBaseColumnList()
                                .formatMapperFileName("%sDao")
                                .formatXmlFileName("%sXml")
                                .build()
                )
                .execute();


    }

}
