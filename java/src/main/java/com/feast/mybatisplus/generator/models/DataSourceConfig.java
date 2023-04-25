package com.feast.mybatisplus.generator.models;

import com.baomidou.mybatisplus.generator.config.IDbQuery;
import com.baomidou.mybatisplus.generator.config.querys.*;
import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class DataSourceConfig {
    String dbUrl;
    String dbUser;
    String dbPassword;
    String query;


    public IDbQuery getQueryType(){
        switch (getQuery()){
            case "MySql":
                return new MySqlQuery();
            case "Xugu":
                return new XuguQuery();
            case "DB2":
                return new DB2Query();
            case "DM":
                return new DMQuery();
            case "ClickHouse":
                return new ClickHouseQuery();
        }
        return new MySqlQuery();
    }
}
