// Licensed under WTFPL（Do What The Fuck You Want To Public License）where applicable && if necessary
// 
// BroserChooserHTM stolen from https://stackoverflow.com/questions/68071144/set-notepad-as-default-browser-on-win10
// TextBox sample stolen from https://qiita.com/kob58im/items/bde46d18339d031f2cab
//
// Compilation instruction: 
// `C:\Windows\Microsoft.NET\Framework64\v3.5\csc.exe /target:winexe main.cs`
// If above is not found, search your system for `csc.exe`. Chances are you have couples.
//
// Usage: 
// 1) Run register_as_browser.reg 
// 2) Go to HKEY_CLASSES_ROOT\BrowserChooserHTM\shell\open\command and \runas\command
// 3) Fix path in DEFAULT key to point to main.exe, e.g. [ "C:\main.exe" "%1" ]
// 4) Set BrowserChooserHTM as your "browser"
// 5) All URLs open in this "default browser" so you can copy paste that URL
//
// Architecture:
// Gets last argument and prints it in a textbox to copy.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

class main : Form
{
    TextBox txt;
    Label label;

    main()
    {
        ClientSize = new Size(500, 100);
        
        Controls.Add(label = new Label(){
            Location = new Point(20, 15),
            Width = 250,
            Text = "Ctrl+C to copy",
        });

        Controls.Add(txt = new TextBox(){
            Location = new Point(20, 40),
            Width = 450,
            ReadOnly = true,
            Anchor = (AnchorStyles.Left | AnchorStyles.Right),
            BackColor = Color.Gray,
            ForeColor = Color.White
        });
        txt.Text = System.Environment.GetCommandLineArgs().Last();
    }

    [STAThread]
    static void Main()
    {
        
        Application.Run(new main());
    }
}
