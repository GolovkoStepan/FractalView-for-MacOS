// This file has been autogenerated from a class added in the UI designer.

using System;
using AppKit;
using Foundation;
using FractalViewMac.Model.Common.Classes;
using FractalViewMac.Model.Common.Enums;

namespace FractalView
{
    public partial class GenSettingsViewController : NSViewController
    {
        MainViewController mainViewController = MainClass.mainViewController;
        GenerationSettings generationSettings = MainClass.mainViewController.genSettings;

        public GenSettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (generationSettings.Algorithm == GenerationAlgorithms.OneThreadCalculation)
            {
                GenAlgoComboBox.SelectItem(0);
            }
            else
            {
                GenAlgoComboBox.SelectItem(1);
            }

            var iterCount = generationSettings.IterationCount;
            IterCountLabel.StringValue = $"Число итераций: {iterCount}";
            IterCountSlider.IntValue = iterCount;

            IterCountSlider.Activated += (sender, e) => 
            {
                IterCountLabel.StringValue = $"Число итераций: {IterCountSlider.IntValue}";
            };
        }

        partial void OkButtonClick(NSObject sender)
        {
            generationSettings.IterationCount = IterCountSlider.IntValue;

            if (GenAlgoComboBox.SelectedIndex == 0)
            {
                generationSettings.Algorithm = GenerationAlgorithms.OneThreadCalculation;
            }
            else
            {
                generationSettings.Algorithm = GenerationAlgorithms.MultiThreadCalculation;
            }

            DismissViewController(this);
            mainViewController.Create();
        }

        partial void CancelButtonClick(NSObject sender)
        {
            DismissViewController(this);
        }
    }
}