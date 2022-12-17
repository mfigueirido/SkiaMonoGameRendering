namespace SkiaTest.FormsControls.Screens
{
    public partial class SkiaScreenCopyForms
    {
        private Gum.Wireframe.GraphicalUiElement Visual;
        public object BindingContext
        {
            get
            {
                return Visual.BindingContext;
            }
            set
            {
                Visual.BindingContext = value;
            }
        }
        public SkiaScreenCopyForms () 
        {
            CustomInitialize();
        }
        public SkiaScreenCopyForms (Gum.Wireframe.GraphicalUiElement visual) 
        {
            Visual = visual;
            ReactToVisualChanged();
            CustomInitialize();
        }
        private void ReactToVisualChanged () 
        {
        }
        partial void CustomInitialize();
    }
}
