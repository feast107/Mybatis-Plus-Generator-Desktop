package com.feast.mybatisplus.generator.models;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class ConfigModel {
    DataSourceConfig dataSourceConfig;
}
