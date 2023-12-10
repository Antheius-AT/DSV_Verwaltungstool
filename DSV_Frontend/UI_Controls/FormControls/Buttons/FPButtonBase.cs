
namespace DSV_Frontend.UI_Controls.FormControls
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class FPButtonBase : ComponentBase
    {
        [Parameter]
        public Action OnClick { get; set; }

        [Parameter]
        public string BusyText { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string IconName { get; set; }
    }
}
