//-----------------------------------------------------------------------
// <copyright file="FPControlBase.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace DSV_Frontend.UI_Controls
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// Represents the base class for all UI components.
    /// </summary>
    public abstract class FPControlBase : ComponentBase
    {
        /// <summary>
        /// Gets or sets the control's label.
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to hide the label when displaying the control.
        /// </summary>
        [Parameter]
        public bool HideLabel { get; set; }

        [Parameter]
        public bool IsVisible { get; set; }

        protected override Task OnInitializedAsync()
        {
            this.IsVisible = true;
            return base.OnInitializedAsync();
        }
    }
}
