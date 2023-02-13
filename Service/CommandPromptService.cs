using System.Diagnostics;

namespace MinimalApi.Service;

/// <summary>
/// Windows Command Prompt 命令執行 Service
/// </summary>
public class CommandPromptService : ICommandService
{
    /// <summary>
    /// 命令清單
    /// </summary>
    private readonly IEnumerable<Command> commands;

    public CommandPromptService(CommandLoader commandLoader)
    {
        // 讀取命令清單
        commands = commandLoader.LoadCommands();
    }

    public async Task ExecuteAsync(string command)
    {
        // 確定命令存在，否則錯誤
        var cmd = commands.FirstOrDefault(c => c.Name == command) ?? throw new InvalidOperationException($"Command '{command}' not found.");
        // 組合執行路徑，相對於程式根目錄
        var loc = Path.Combine(AppContext.BaseDirectory, cmd.CommandLine);
        Console.WriteLine($"Executing command: '{loc}'");
        var process = Process.Start(loc, string.Join(" ", cmd.args ?? new[] { "" }));
        // 輸出至console
        process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
        await process.WaitForExitAsync();
    }
}