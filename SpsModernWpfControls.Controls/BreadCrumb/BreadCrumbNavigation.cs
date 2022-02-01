using SpsModernWpfControls.Controls.BreadCrumb.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace SpsModernWpfControls.Controls.BreadCrumb
{
    [ContentProperty("NavigationItems")]
    public class BreadcrumbNavigation : Control
    {
        //public delegate void NavigationItemsCollectionChangedEventHandler();
        //public delegate void NavigationItemsChangedEventHandler();
        public static readonly RoutedEvent NavigationItemsCollectionChangedEvent;
        public static readonly RoutedEvent NavigationItemsChangedEvent;
        static BreadcrumbNavigation()
        {
            // Mit dem OverrideMetadata-Aufruf wird dem System mitgeteilt, dass das Element einen Stil bereitstellen möchte, der sich von seiner Basisklasse unterscheidet.
            // Dieser Stil ist unter "Themes\Generic.xaml" definiert.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbNavigation), new FrameworkPropertyMetadata(typeof(BreadcrumbNavigation)));

            NavigationItemsCollectionChangedEvent = EventManager.RegisterRoutedEvent("NavigationItemsCollectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(BreadcrumbNavigation));
            NavigationItemsChangedEvent = EventManager.RegisterRoutedEvent("NavigationItemsChanged", RoutingStrategy.Bubble, typeof(RoutedEventArgs), typeof(BreadcrumbNavigation));
        }

        private static readonly ArrayList Handlers = new ArrayList();
        public static event EventHandler<NotifyCollectionChangedEventArgs> NavigationItemsCollectionChanged
        {
            add
            {
                Handlers.Add(value);
            }
            remove
            {
                Handlers.Remove(value);
            }
        }
        void OnNavigationItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (EventHandler<NotifyCollectionChangedEventArgs> h in Handlers)
                h.Invoke(sender, e);
        }

        private static readonly ArrayList Handlers1 = new ArrayList();
        public static event EventHandler NavigationItemsChanged
        {
            add
            {
                Handlers1.Add(value);
            }
            remove
            {
                Handlers1.Remove(value);
            }
        }
        void OnNavigationItemsChanged(object sender, EventArgs e)
        {
            foreach (EventHandler h in Handlers1)
                h.Invoke(sender, e);
        }


        public ObservableCollection<IBreadCrumbItem> NavigationItems
        {
            get
            {
                return (ObservableCollection<IBreadCrumbItem>)GetValue(NavigationItemsProperty);
            }

            set
            {
                SetValue(NavigationItemsProperty, value);
            }
        }

        public static readonly DependencyProperty NavigationItemsProperty = DependencyProperty.Register("NavigationItems", typeof(ObservableCollection<IBreadCrumbItem>), typeof(BreadcrumbNavigation), new PropertyMetadata(new ObservableCollection<IBreadCrumbItem>(), NavigationItems_Changed));

        private static void NavigationItems_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
                ((ObservableCollection<IBreadCrumbItem>)e.OldValue).CollectionChanged -= NavigationItems_CollectionChanged;
            if (e.NewValue != null)
            {
                ((ObservableCollection<IBreadCrumbItem>)e.NewValue).CollectionChanged += NavigationItems_CollectionChanged;
                //OnNavigationItemsChanged(d, new EventArgs());

                RoutedEventArgs newEventArgs = new RoutedEventArgs(NavigationItemsChangedEvent);
                ((BreadcrumbNavigation)d).RaiseEvent(newEventArgs);

            }
        }

        private static void NavigationItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(NavigationItemsCollectionChangedEvent);
            ((BreadcrumbNavigation)sender).RaiseEvent(newEventArgs);
            
        }


        public Thickness ItemsPadding
        {
            get
            {
                return (Thickness)GetValue(ItemsPaddingProperty);
            }

            set
            {
                SetValue(ItemsPaddingProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsPaddingProperty = DependencyProperty.Register("ItemsPadding", typeof(Thickness), typeof(BreadcrumbNavigation), new PropertyMetadata(new Thickness(1)));



        public Thickness ItemsMargin
        {
            get
            {
                return (Thickness)GetValue(ItemsMarginProperty);
            }

            set
            {
                SetValue(ItemsMarginProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsMarginProperty = DependencyProperty.Register("ItemsMargin", typeof(Thickness), typeof(BreadcrumbNavigation), new PropertyMetadata(new Thickness(0)));



        public Brush ItemsBackgroundBrush
        {
            get
            {
                return (Brush)GetValue(ItemsBackgroundBrushProperty);
            }

            set
            {
                SetValue(ItemsBackgroundBrushProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsBackgroundBrushProperty = DependencyProperty.Register("ItemsBackgroundBrush", typeof(Brush), typeof(BreadcrumbNavigation), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));



        public Brush SelectedItemBackgroundbrush
        {
            get
            {
                return (Brush)GetValue(SelectedItemBackgroundbrushProperty);
            }

            set
            {
                SetValue(SelectedItemBackgroundbrushProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemBackgroundbrushProperty = DependencyProperty.Register("SelectedItemBackgroundbrush", typeof(Brush), typeof(BreadcrumbNavigation), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(106, 91, 10))));



        public Brush ItemsBorderBrush
        {
            get
            {
                return (Brush)GetValue(ItemsBorderBrushProperty);
            }

            set
            {
                SetValue(ItemsBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty = DependencyProperty.Register("ItemsBorderBrush", typeof(Brush), typeof(BreadcrumbNavigation), new PropertyMetadata(new SolidColorBrush(Colors.Black)));



        public Brush DisabledItemForegroundBrush
        {
            get
            {
                return (Brush)GetValue(DisabledItemForegroundBrushProperty);
            }

            set
            {
                SetValue(DisabledItemForegroundBrushProperty, value);
            }
        }

        public static readonly DependencyProperty DisabledItemForegroundBrushProperty = DependencyProperty.Register("DisabledItemForegroundBrush", typeof(Brush), typeof(BreadcrumbNavigation), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));



        public double ItemsJointWidth
        {
            get
            {
                return System.Convert.ToDouble(GetValue(ItemsJointWidthProperty));
            }

            set
            {
                SetValue(ItemsJointWidthProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsJointWidthProperty = DependencyProperty.Register("ItemsJointWidth", typeof(double), typeof(BreadcrumbNavigation), new PropertyMetadata(System.Convert.ToDouble(15)));



        public new IBreadCrumbItem SelectedItem
        {
            get
            {
                return (IBreadCrumbItem)GetValue(SelectedItemProperty);
            }

            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(IBreadCrumbItem), typeof(BreadcrumbNavigation), new PropertyMetadata(null));



        private ICommand _chooseContentCommand;
        public ICommand ChooseContentCommand
        {
            get
            {
                if (_chooseContentCommand == null)
                    _chooseContentCommand = new RelayCommand(ChooseContentCommand_Execute, ChooseContentCommand_CanExecute);
                return _chooseContentCommand;
            }
            set
            {
                _chooseContentCommand = value;
            }
        }

        private void ChooseContentCommand_Execute(object obj)
        {
            SetValue(SelectedItemProperty, obj);
        }

        private bool ChooseContentCommand_CanExecute(object obj)
        {
            return obj != null;
        }



        public bool HideImages
        {
            get
            {
                return System.Convert.ToBoolean(GetValue(HideImagesProperty));
            }

            set
            {
                SetValue(HideImagesProperty, value);
            }
        }

        public static readonly DependencyProperty HideImagesProperty = DependencyProperty.Register("HideImages", typeof(bool), typeof(BreadcrumbNavigation), new PropertyMetadata(false));
    }

}
