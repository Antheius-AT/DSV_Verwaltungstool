using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DSV_Frontend.UI_Controls
{
    public abstract class FPEditFormBase : FPControlBase
    {
        private ValidationMessageStore messageStore;

        protected override Task OnInitializedAsync()
        {
            if (this.EditContext == null)
            {
                throw new InvalidOperationException(
                     $"{nameof(FPEditFormBase)} requires a cascading " +
                     $"parameter of type {nameof(EditContext)}. " +
                     $"For example, you can use {nameof(FPEditFormBase)} " +
                     $"inside an {nameof(EditForm)}.");
            }

            this.messageStore = new ValidationMessageStore(this.EditContext);
            this.EditContext.OnValidationRequested += (s, e) =>
                            messageStore.Clear();
            this.EditContext.OnFieldChanged += (s, e) =>
                messageStore.Clear(e.FieldIdentifier); return base.OnInitializedAsync();
        }

        [CascadingParameter]
        public EditContext EditContext { get; set; }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var item in errors)
            {
                this.messageStore.Add(this.EditContext.Field(item.Key), item.Value);
            }

            this.EditContext.NotifyValidationStateChanged();
        }

        public void ClearErrors()
        {
            this.messageStore.Clear();
            this.EditContext.NotifyValidationStateChanged();
        }
    }
}
