using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NetC.JuniorDeveloperExam.Web.ReactConfig), "Configure")]

namespace NetC.JuniorDeveloperExam.Web
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
			JsEngineSwitcher.Current.EngineFactories.AddV8();
		}
	}
}