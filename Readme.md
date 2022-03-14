# sfcli

sfcli is a simple cli tool to test smartface api.<br>
Please use ```dotnet``` to run commands.

## Commands:
### create
Creates watchlist
```
dotnet run -- create -d Watchlist -n Watchlist -t 75 -c "#012abc"
```
```
Options:
  -d|--displayName  Watchlist display name
  -n|--fullName Fullname of watchlist
  -t|--threshold Threshold
  -c|--previewColor Preview color, must be hex string (#bada55)
  --help  Show help information
```
### getall
Gets all watchlists
```
dotnet run -- getall
```
### register
Register person into watchlist
```
dotnet run -- register -w {id} -n Name -p test1.jpg
```
```
Options:
  -w|--wlist  Watchlist Id
  -n|--name Name
  -p|--path Path to image ile
  --help  Show help information
```
### search
Searches for a person on picture in watchlist
```
dotnet run -- search -w {id} -p test1.jpg -t 40
```
```
Options:
  -w|--wlist  Watchlist Id
  -p|--path Path to image ile
  -t|--threshold Threshold, default 40, optional
    |--minsize Min size, default 35, optional
    |--maxsize Max size, default 600, optional
  --help  Show help information
```

## Settings:
Specify api url (BaseUrl) in ```appsettings.json```