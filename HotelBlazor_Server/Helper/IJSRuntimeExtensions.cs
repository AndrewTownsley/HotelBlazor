using Microsoft.JSInterop;

namespace HotelBlazor_Server.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        public static async ValueTask ToastrError(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
