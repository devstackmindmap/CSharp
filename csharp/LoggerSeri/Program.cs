// See https://aka.ms/new-console-template for more information

using LoggerSeri;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Slack.Models;
using Serilog.Sinks.Slack;
using Serilog.Core;

// Todo : 구조화된 로깅, 로그 비동기화 
// Log Level 수정

var levelSwitch = new LoggingLevelSwitch();

// 동적 레벨

levelSwitch.MinimumLevel = LogEventLevel.Debug;
Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Debug()
    .MinimumLevel.ControlledBy(levelSwitch)
    .WriteTo.Console()
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
    //.WriteTo.File("log.txt",
    //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.Slack(new SlackSinkOptions
    {
        WebHookUrl = "https://hooks.slack.com/services/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",
        BatchSizeLimit = 20,
        QueueLimit = 1000,
        CustomUserName = "Slack Logger",
        CustomIcon = ":ghost:",
        Period = TimeSpan.FromSeconds(10),
        ShowDefaultAttachments = false,
        ShowExceptionAttachments = true,
        MinimumLogEventLevel = LogEventLevel.Debug,
        PropertyDenyList = new List<string> { "Level", "SourceContext" }
    })
    .CreateLogger();

Log.Information("INFO Hello");
Log.Warning("WAR Hello");

levelSwitch.MinimumLevel = LogEventLevel.Verbose;

Log.Information("INFO Hello");
Log.Warning("WAR Hello");

var player = new Player();
player.Attack();

Log.CloseAndFlush();


class 