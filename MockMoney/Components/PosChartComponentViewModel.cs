// using Avalonia.Controls;
// using CommunityToolkit.Mvvm.ComponentModel;
//
// namespace MockMoney.Components.Charting;
//
// public partial class PlotChartComponentViewModel : ObservableObject
// {
//     private List<float> _data;
//     private ColorSpectrumComponents _colorSpectrumComponents;
//
//     public List<float> Data
//     {
//         get => _data;
//         set => SetProperty(ref _data, value);
//     }
//
//     public ColorSpectrumComponents ColorSpectrumComponents
//     {
//         get => _colorSpectrumComponents;
//         set => SetProperty(ref _colorSpectrumComponents, value);
//     }
//
//     public PlotChartComponentViewModel()
//     {
//         // Initialize data
//         Data = new List<float>();
//
//         // Initialize color spectrum components
//         ColorSpectrumComponents = new ColorSpectrumComponents
//         {
//             HueStart = 0,
//             HueEnd = 360,
//             SaturationStart = 1,
//             SaturationEnd = 1,
//             BrightnessStart = 1,
//             BrightnessEnd = 1
//         };
//     }
//     public class ColorSpectrumComponents
//     {
//         public double HueStart { get; set; }
//         public double HueEnd { get; set; }
//         public double SaturationStart { get; set; }
//         public double SaturationEnd { get; set; }
//         public double BrightnessStart { get; set; }
//         public double BrightnessEnd { get; set; }
//     }
//
// }
