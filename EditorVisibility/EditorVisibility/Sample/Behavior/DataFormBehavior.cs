using Syncfusion.Maui.DataForm;
using System.ComponentModel;

namespace EditorVisibility
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm dataForm;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            if (dataForm != null)
            {
                dataForm.DataObject = new DataFormModel();

                dataForm.GenerateDataFormItem += OnGenerateDataFormItem;
                dataForm.ValidateProperty += OnValidateProperty;
                dataForm.ItemsSourceProvider = new ItemSourceProvider();
                dataForm.RegisterEditor("Country", DataFormEditorType.AutoComplete);
            }
        }
        private void OnValidateProperty(object sender, DataFormValidatePropertyEventArgs e)
        {
            string propertyName = e.PropertyName;
            object value = e.NewValue;
            if (propertyName != null && propertyName == "Password")
            {
                if (value != null && value.ToString().Length < 8)
                {
                    e.ErrorMessage = "Password should be minimum 8 characters";
                    e.IsValid = false;
                }
                else
                {
                    var confirmPassword = dataForm.GetDataFormItem("ConfirmPassword");
                    confirmPassword.IsVisible = true;
                }
            }
        }
        private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
        {
           
            if (e.DataFormItem != null )
            {
                if (e.DataFormItem.FieldName == "ConfirmPassword")
                {
                    e.DataFormItem.IsVisible = false;
                }
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (dataForm != null)
            {
                dataForm.ValidateProperty -= OnValidateProperty;
                dataForm.GenerateDataFormItem -= OnGenerateDataFormItem;
            }

            dataForm = null;
        }
    }
}