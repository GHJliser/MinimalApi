namespace MinimalApi.Service;

/// <summary>
/// 命令讀取器
/// </summary>
public class CommandLoader
{
    private readonly IConfiguration configuration;

    public CommandLoader(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    /// <summary>
    /// 讀取命令(從appsettings.json)
    /// </summary>
    public IEnumerable<Command> LoadCommands() => configuration.GetSection("Commands").Get<Command[]>();
}

/// <summary>
/// 命令 模型
/// </summary>
public class Command
{
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 命令內容
    /// </summary>
    public string CommandLine { get; set; }

    /// <summary>
    /// 命令参数
    /// </summary>
    public string[]? args { get; set; }
}