﻿#pragma checksum "..\..\Scale Recipe.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3D875D3A71486120D552AF476E2CD8AA60FC3621407738987E6CE5FF46F71DEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Part_Three_POE;
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


namespace Part_Three_POE {
    
    
    /// <summary>
    /// Scale_Recipe
    /// </summary>
    public partial class Scale_Recipe : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Scale Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox recipeNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Scale Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox scalingFactorTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Scale Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ScaleRecipe;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Scale Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel scaledRecipePanel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Scale Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/Part Three POE;component/scale%20recipe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Scale Recipe.xaml"
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
            this.recipeNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.scalingFactorTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ScaleRecipe = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Scale Recipe.xaml"
            this.ScaleRecipe.Click += new System.Windows.RoutedEventHandler(this.ScaleRecipe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.scaledRecipePanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.MainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Scale Recipe.xaml"
            this.MainMenu.Click += new System.Windows.RoutedEventHandler(this.MainMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

