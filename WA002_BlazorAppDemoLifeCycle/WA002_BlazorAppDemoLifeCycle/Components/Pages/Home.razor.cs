using Microsoft.AspNetCore.Components;

namespace WA002_BlazorAppDemoLifeCycle.Components.Pages
{
    public partial class Home
    {
        public string Valor { get; set; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Valor = "Ejecucion de SetParametersAsync";
            System.Diagnostics.Debug.WriteLine(Valor);
            await base.SetParametersAsync(parameters);
        }

        protected override Task OnInitializedAsync()
        {
            Valor = "OnInitializedAsync";
            System.Diagnostics.Debug.WriteLine(Valor);
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            Valor = "OnParametersSetAsync";
            System.Diagnostics.Debug.WriteLine(Valor);
            return base.OnParametersSetAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Valor = "OnAfterRenderAsync";
                System.Diagnostics.Debug.WriteLine(Valor);
                StateHasChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
