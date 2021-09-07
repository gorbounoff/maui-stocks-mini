using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.Maui.Demo.Stocks {
    public class DoubleToImageSourceConverter : IValueConverter {
        public ImageSource ZeroValue { get; set; } = string.Empty;
        public ImageSource PositiveValue { get; set; } = string.Empty;
        public ImageSource NegativeValue { get; set; } = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is double doubleValue) || targetType != typeof(ImageSource)) return null;
            switch (doubleValue) {
                case > 0: return PositiveValue;
                case < 0: return NegativeValue;
                default: return ZeroValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
    public class DoubleToImageSourceConverterExtension : IMarkupExtension<DoubleToImageSourceConverter> {
        public ImageSource PositiveValue { get; set; } = string.Empty;
        public ImageSource NegativeValue { get; set; } = string.Empty;
        public ImageSource ZeroValue { get; set; } = string.Empty;

        public DoubleToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) {
            return new DoubleToImageSourceConverter {
                PositiveValue = this.PositiveValue,
                NegativeValue = this.NegativeValue,
                ZeroValue = this.ZeroValue
            };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) {
            return ProvideValue(serviceProvider);
        }
    }

    public class DoubleToColorConverter : IValueConverter {
        public string ZeroValue { get; set; } = string.Empty;
        public string PositiveValue { get; set; } = string.Empty;
        public string NegativeValue { get; set; } = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is double doubleValue) || targetType != typeof(Color)) return null;
            switch (doubleValue) {
                case > 0: return (Color)Application.Current.Resources[PositiveValue];
                case < 0: return (Color)Application.Current.Resources[NegativeValue];
                default: return (Color)Application.Current.Resources[ZeroValue];
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
    public class DoubleToColorConverterExtension : IMarkupExtension<DoubleToColorConverter> {
        public string PositiveValue { get; set; } = null;
        public string NegativeValue { get; set; } = null;
        public string ZeroValue { get; set; } = null;

        public DoubleToColorConverter ProvideValue(IServiceProvider serviceProvider) {
            return new DoubleToColorConverter {
                PositiveValue = this.PositiveValue,
                NegativeValue = this.NegativeValue,
                ZeroValue = this.ZeroValue
            };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) {
            return ProvideValue(serviceProvider);
        }
    }
}
