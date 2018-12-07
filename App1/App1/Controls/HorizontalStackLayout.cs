using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1.Controls
{
    public class HorizontalStackLayout : StackLayout
    {
        /// <summary>
        /// Called when the binding context changes
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            CreateStack();
        }

        /// <summary>
        /// Called when the item source property changes
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == ItemsSourceProperty.PropertyName)
            {
                CreateStack();
            }

            base.OnPropertyChanged(propertyName);
        }

        // ------------------------------------------------------------

        #region Public Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(HorizontalStackLayout), null);
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(HorizontalStackLayout), null);
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }


        #endregion

        // ------------------------------------------------------------

        #region Private Methods

        private void CreateStack()
        {
            Children.Clear();
            // Check for data
            if (ItemsSource == null || ItemsSource.Count() == 0 || ItemsSource.First() == null)
            {
                return;
            }

            CreateCells();
        }


        /// <summary>
        /// Creates the cells.
        /// </summary>
        private void CreateCells()
        {
            foreach (var item in ItemsSource)
            {
                Children.Add(CreateCellView(item));
            }
        }

        /// <summary>
        /// Creates the cell view.
        /// </summary>
        /// <returns>The cell view.</returns>
        /// <param name="item">Item.</param>
        private View CreateCellView(object item)
        {
            var view = (View)ItemTemplate.CreateContent();
            var bindableObject = (BindableObject)view;

            if (bindableObject != null)
            {
                bindableObject.BindingContext = item;
            }

            return view;
        }

        #endregion
    }
}
