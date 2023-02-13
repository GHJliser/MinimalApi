namespace MinimalApi.Service;

/// <summary>
/// 命令執行 Service
/// </summary>
public interface ICommandService
{
    /// <summary>
    /// 執行
    /// </summary>
    /// <param name="command">指令，可接收的清單定義於 appsettings.json</param>
    Task ExecuteAsync(string command);
}
