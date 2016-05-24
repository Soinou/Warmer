#define MyAppName "Warmer"
#define MyProjectName "Warmer"
#define MyAppVersion GetFileVersion(MyProjectName)
#define MyAppPublisher "Abricot Soinou"
#define MyAppURL "https://github.com/Soinou/Warmer"
#define MyAppExeName "Warmer.exe"

[Setup]
AppId={{e76116e8-a4d2-4b02-9f1d-c37215674ef6}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
CloseApplications=yes
DefaultDirName={userappdata}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=..\LICENSE
OutputDir=Releases\
OutputBaseFilename={#MyAppName}.Setup
Compression=lzma2/ultra64
SetupIconFile=..\{#MyProjectName}\Icon.ico
SolidCompression=yes
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\{#MyProjectName}\build\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\{#MyProjectName}\build\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commonstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Flags: nowait runhidden

[UninstallRun]
Filename: "{sys}\taskkill.exe"; Parameters: "/f /im {#MyAppExeName}"; Flags: runhidden

[UninstallDelete]
Type: filesandordirs; Name: "{app}\data"

[Registry]
Root: HKLM; Subkey: "Software\Microsoft\Windows NT\CurrentVersion\ICM"; ValueType: dword; ValueName: "GdiIcmGammaRange"; ValueData: "00000100"; Flags: createvalueifdoesntexist
