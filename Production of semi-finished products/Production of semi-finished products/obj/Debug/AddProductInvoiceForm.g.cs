﻿#pragma checksum "..\..\AddProductInvoiceForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1EE6EBD845728509BBDB0EF267B73F74870136C3FA7C3D42D44BC8D440EB444F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Production_of_semi_finished_products;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Production_of_semi_finished_products {
    
    
    /// <summary>
    /// AddProductInvoiceForm
    /// </summary>
    public partial class AddProductInvoiceForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\AddProductInvoiceForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductNameTB;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddProductInvoiceForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UnitMeasurementTB;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddProductInvoiceForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PricePerUnitMeasurementTB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddProductInvoiceForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CostTB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddProductInvoiceForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Production of semi-finished products;component/addproductinvoiceform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddProductInvoiceForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.UnitMeasurementTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PricePerUnitMeasurementTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CostTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AddProductInvoiceForm.xaml"
            this.AddProduct.Click += new System.Windows.RoutedEventHandler(this.AddProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
