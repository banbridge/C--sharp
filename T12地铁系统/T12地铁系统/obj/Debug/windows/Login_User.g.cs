﻿#pragma checksum "..\..\..\windows\Login_User.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "060E29B3056715F41D0D7FC4D6448B60"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace T12地铁系统.windows {
    
    
    /// <summary>
    /// Login_User
    /// </summary>
    public partial class Login_User : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textboxUser;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textboxPassword;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Yanzhengma;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok_Login;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_Login;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label user_label;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label password_label;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label yanzhengma_label;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\windows\Login_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn;
        
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
            System.Uri resourceLocater = new System.Uri("/T12地铁系统;component/windows/login_user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\Login_User.xaml"
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
            this.textboxUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textboxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.Yanzhengma = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Ok_Login = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\windows\Login_User.xaml"
            this.Ok_Login.Click += new System.Windows.RoutedEventHandler(this.Ok_Login_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancel_Login = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\windows\Login_User.xaml"
            this.cancel_Login.Click += new System.Windows.RoutedEventHandler(this.cancel_Login_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.user_label = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.password_label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.yanzhengma_label = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\windows\Login_User.xaml"
            this.btn.Click += new System.Windows.RoutedEventHandler(this.btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

