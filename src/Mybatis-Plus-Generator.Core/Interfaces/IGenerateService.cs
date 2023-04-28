using Mybatis_Plus_Generator.Definition.Abstractions;

namespace Mybatis_Plus_Generator.Core.Interfaces;

public interface IGenerateService<in TConfigRecord, TConfigInfo, TConfigItemInfo>
    where TConfigRecord : ConfigRecord<TConfigInfo, TConfigItemInfo>
    where TConfigInfo : ConfigInfo<TConfigItemInfo>
    where TConfigItemInfo : ConfigItemInfo
{
    Task Generate(TConfigRecord record);
}