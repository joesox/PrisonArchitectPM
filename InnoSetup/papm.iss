; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Prison Architect Prison Manager"
#define MyAppVersion "1.8.0.0"
#define MyAppPublisher "JPSIII"
#define MyAppURL "http://PrisonArchitectPM.googlecode.com"
#define MyAppExeName "Prison Architect Prison Manager.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{54AC9511-AA4A-4352-8795-52326AE6C0AB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=C:\Users\Joe\Documents\Visual Studio 2013\Projects\Prison Architect Prison Manager\Prison Architect Prison Manager\ReadMe.txt
OutputDir=C:\Users\Joe\Documents\Visual Studio 2013\Projects\Prison Architect Prison Manager\Prison Architect Prison Manager\InnoSetup
OutputBaseFilename=PrisonArchitectPMsetup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\Joe\Documents\Visual Studio 2013\Projects\Prison Architect Prison Manager\Prison Architect Prison Manager\bin\Release\Prison Architect Prison Manager.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Joe\Documents\Visual Studio 2013\Projects\Prison Architect Prison Manager\Prison Architect Prison Manager\bin\Release\Ionic.Zip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Joe\Documents\Visual Studio 2013\Projects\Prison Architect Prison Manager\Prison Architect Prison Manager\ReadMe.txt"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
