using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppKit;
using Foundation;
using FractalViewMac.Model.Fractals;
using SkiaSharp.Views.Mac;

namespace FractalView
{
    [Register("AppDelegate")]
    public partial class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        partial void CreateMenuButtonClick(NSObject sender)
        {
            MainClass.mainViewController.Create();
        }

        partial void ReDrawMenuButtonClick(NSObject sender)
        {
            MainClass.mainViewController.ReDraw();
        }

        partial void ResetMenuButtonClick(NSObject sender)
        {
            MainClass.mainViewController.Reset();
        }

        partial void OpenDataButtonClick(NSObject sender)
        {
            var dlg = new NSOpenPanel
            {
                Title = "Открыть файл"

            };

            dlg.BeginSheet(MainClass.mainViewController.View.Window, (result) =>
            {
                if (result == 1)
                {
                    string path = dlg.Url.Path;

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        MainClass.mainViewController.fractalData = (AbstractFractal)formatter.Deserialize(fs);
                        MainClass.mainViewController.creator.FractalData = MainClass.mainViewController.fractalData;
                        MainClass.mainViewController.Create();
                    }

                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "Данные были успешно загружены из файла",
                        MessageText = "Открытие"
                    };
                    alert.RunModal();
                }
            });
        }

        partial void SaveDataButtonClick(NSObject sender)
        {
            var dlg = new NSSavePanel
            {
                Title = "Сохранить данные"

            };

            dlg.BeginSheet(MainClass.mainViewController.View.Window, (result) =>
            {
                if(result == 1) 
                {
                    var path = dlg.Url.Path;
                    MainClass.mainViewController.creator.SaveFractalInfo(path);

                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "Данные текущей позиции были сохранены в бинарный файл.",
                        MessageText = "Сохранено"
                    };
                    alert.RunModal();
                }
            });
        }

        partial void SaveImageButtonClick(NSObject sender)
        {
            var dlg = new NSSavePanel
            {
                Title = "Сохранить изображение"

            };

            dlg.BeginSheet(MainClass.mainViewController.View.Window, (result) =>
            {
                if (result == 1)
                {
                    var path = dlg.Url.Path;

                    using (var imageToSave = MainClass.mainViewController.CurrentImage.ToSKImage())
                    using (var data = imageToSave.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100)) 
                    {
                        using (var stream = File.OpenWrite(path))
                        {
                            data.SaveTo(stream);
                        }
                    }

                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "Текущее изображение было сохранено.",
                        MessageText = "Сохранено",
                    };
                    alert.RunModal();
                }
            });
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
