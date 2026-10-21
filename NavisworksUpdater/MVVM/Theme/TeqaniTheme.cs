using System.Windows;
using System.Windows.Media;

namespace NavisworksUpdater.MVVM.Theme
{
    /// <summary>
    /// Teqani brand theme for WPF applications
    /// Complete design system extracted from Teqani Hub web platform
    /// </summary>
    public static class TeqaniTheme
    {
        // Primary Colors
        public static Color PrimaryGreen = Color.FromRgb(154, 205, 50);      // #9ACD32
        public static Color PrimaryText = Color.FromRgb(38, 38, 38);          // #262626
        
        // Accent Colors
        public static Color AccentNavy = Color.FromRgb(0, 31, 63);           // #001F3F
        public static Color AccentText = Color.FromRgb(250, 250, 250);       // #FAFAFA
        
        // Neutral Colors (Light Mode)
        public static Color Background = Color.FromRgb(255, 255, 255);       // #FFFFFF
        public static Color Foreground = Color.FromRgb(60, 60, 58);          // #3C3C3A
        public static Color Card = Color.FromRgb(255, 255, 255);             // #FFFFFF
        public static Color Muted = Color.FromRgb(247, 247, 247);            // #F7F7F7
        public static Color MutedForeground = Color.FromRgb(141, 141, 140);  // #8D8D8C
        public static Color Border = Color.FromRgb(235, 235, 234);           // #EBEBEA
        
        // Status Colors
        public static Color Success = Color.FromRgb(154, 205, 50);           // #9ACD32
        public static Color Error = Color.FromRgb(220, 38, 38);              // #DC2626
        public static Color Warning = Color.FromRgb(245, 158, 11);           // #F59E0B
        public static Color Info = Color.FromRgb(59, 130, 246);              // #3B82F6
        
        // Hover States (Primary Green variations)
        public static Color PrimaryGreenHover = Color.FromRgb(138, 184, 45); // ~5% darker
        public static Color PrimaryGreenActive = Color.FromRgb(122, 163, 40); // ~10% darker
        
        // Hover States (Navy variations)
        public static Color AccentNavyHover = Color.FromRgb(0, 40, 80);      // ~5% lighter
        
        // Brushes
        public static SolidColorBrush PrimaryBrush = new SolidColorBrush(PrimaryGreen);
        public static SolidColorBrush PrimaryTextBrush = new SolidColorBrush(PrimaryText);
        public static SolidColorBrush AccentBrush = new SolidColorBrush(AccentNavy);
        public static SolidColorBrush AccentTextBrush = new SolidColorBrush(AccentText);
        public static SolidColorBrush BackgroundBrush = new SolidColorBrush(Background);
        public static SolidColorBrush ForegroundBrush = new SolidColorBrush(Foreground);
        public static SolidColorBrush CardBrush = new SolidColorBrush(Card);
        public static SolidColorBrush MutedBrush = new SolidColorBrush(Muted);
        public static SolidColorBrush MutedForegroundBrush = new SolidColorBrush(MutedForeground);
        public static SolidColorBrush BorderBrush = new SolidColorBrush(Border);
        
        // Spacing (4px base unit)
        public static Thickness SpacingXS = new Thickness(4);
        public static Thickness SpacingSM = new Thickness(8);
        public static Thickness SpacingMD = new Thickness(12);
        public static Thickness SpacingBase = new Thickness(16);
        public static Thickness SpacingLG = new Thickness(24);
        public static Thickness SpacingXL = new Thickness(32);
        public static Thickness Spacing2XL = new Thickness(48);
        public static Thickness Spacing3XL = new Thickness(64);
        
        // Padding
        public static Thickness SmallPadding = new Thickness(8);
        public static Thickness MediumPadding = new Thickness(12, 24, 12, 24);  // 12px vertical, 24px horizontal
        public static Thickness LargePadding = new Thickness(24);
        public static Thickness InputPadding = new Thickness(10, 12, 10, 12);
        
        // Border Radius
        public static CornerRadius RadiusSM = new CornerRadius(6);
        public static CornerRadius RadiusMD = new CornerRadius(8);
        public static CornerRadius RadiusBase = new CornerRadius(10);
        public static CornerRadius RadiusLG = new CornerRadius(12);
        public static CornerRadius RadiusXL = new CornerRadius(16);
        
        // Font Sizes
        public const double FontSizeSmall = 14;      // 0.875rem
        public const double FontSizeBase = 16;      // 1rem
        public const double FontSizeLarge = 18;     // 1.125rem
        public const double FontSizeXL = 20;        // 1.25rem
        public const double FontSize2XL = 24;       // 1.5rem
        public const double FontSize3XL = 30;       // 1.875rem
        
        // Font Weights
        public static FontWeight FontWeightRegular = FontWeights.Regular;      // 400
        public static FontWeight FontWeightMedium = FontWeights.Medium;        // 500
        public static FontWeight FontWeightSemibold = FontWeights.SemiBold;   // 600
        public static FontWeight FontWeightBold = FontWeights.Bold;           // 700
    }
}
