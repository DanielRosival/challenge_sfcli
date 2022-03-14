using CommandLine;

namespace sfcli.Commands;

/// <summary>
/// 
/// </summary>
[Verb("create", HelpText = "Creates watchlist")]
public class CreateOptions
{
    [Option('d', "displayName", Required = true, HelpText = "Display Name of watchlist")]
    public string DisplayName { get; set; } = string.Empty;

    [Option('n', "fullName", Required = true, HelpText = "Full Name of wachlist")]
    public string FullName { get; set; } = string.Empty;

    [Option('t', "treshold", Required = true, HelpText = "Treshold")]
    public int Treshold { get; set; }

    [Option('c', "previewColor", Required = true, HelpText = "Preview color - hexadecimal string")]
    public string PreviewColor { get; set; } = string.Empty;
}

/// <summary>
/// 
/// </summary>
[Verb("getall", HelpText = "Get all watchlists")]
public class GetOptions
{    
}


/// <summary>
/// 
/// </summary>
[Verb("register", HelpText = "Register person into desired watchlist")]
public class RegisterOptions
{
    [Option('w', "wlist", Required = true, HelpText = "Watchlist Id")]
    public Guid WatchlistId { get; set; }

    [Option('n', "name", Required = true, HelpText = "Name of the member")]
    public string MemberName { get; set; } = string.Empty;

    [Option('p', "path", Required = true, HelpText = "Path to image file")]
    public string PathToFile { get; set; } = string.Empty;
}

/// <summary>
/// 
/// </summary>
[Verb("search", HelpText = "Searches desired watchlist for a match")]
public class SearchOptions
{
    [Option('w', "wlist", Required = true, HelpText = "Watchlist Id")]
    public Guid WatchlistId { get; set; }

    [Option('p', "path", Required = true, HelpText = "Path to image file")]
    public string PathToFile { get; set; } = string.Empty;

    [Option('t', "treshold", Required = false, HelpText = "Treshold", Default = 40)]
    public int Treshold { get; set; }

    [Option("minsize", Required = false, HelpText = "Min Size", Default = 35)]
    public int MinFaceSize { get; set; }

    [Option("maxsize", Required = false, HelpText = "Max Size", Default = 600)]
    public int MaxFaceSize { get; set; }
}
