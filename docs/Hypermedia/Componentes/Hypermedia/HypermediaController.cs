using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia {
    public abstract class HypermediaController : Controller {
        public TypedUrlGenerator UrlGenerator { get; set; }

        protected override void HandleUnknownAction(string actionName) {
            var url = ControllerContext.RequestContext.HttpContext.Request.Url;
            //TODO Logger


            Response.StatusCode = 404;
        }

        protected HttpStatusCodeResult HttpBadRequest(string statusDescription) {
            return new HttpStatusCodeResult(400, statusDescription);
        }

        protected HttpStatusCodeResult NoContent() {
            return new HttpStatusCodeResult(204);
        }

        protected HttpStatusCodeResult Created(string location = null) {
            if (!string.IsNullOrEmpty(location)) {
                Response.RedirectLocation = location;
            }

            return new HttpStatusCodeResult(201);
        }

        protected HttpStatusCodeResult Created(Expression<Action> controllerAction) {
            return Created(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected HttpStatusCodeResult Created<TController>(Expression<Action<TController>> controllerAction) {
            return Created(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected HttpStatusCodeResult Created<TController>(Expression<Func<TController, Task>> controllerAction) {
            return Created(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected HttpUnauthorizedResult HttpUnauthorized() {
            return new HttpUnauthorizedResult();
        }

        // TODO: MVC5
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            UrlGenerator = new TypedUrlGenerator(Url, Request.Url?.Scheme, Request.Url?.Host, RouteData.Values["controller"].ToString());
            filterContext.HttpContext.Items["UrlGenerator"] = UrlGenerator;

            base.OnActionExecuting(filterContext);
        }

        protected RedirectResult Redirect(Expression<Func<Task>> controllerAction) {
            return Redirect(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected RedirectResult Redirect(Expression<Func<Task>> controllerAction, object routeValues) {
            return Redirect(UrlGenerator.Generate(controllerAction, routeValues).AbsoluteUri);
        }

        protected RedirectResult Redirect<TController>(Expression<Func<TController, Task>> controllerAction) {
            return Redirect(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected RedirectResult Redirect(Expression<Action> controllerAction) {
            return Redirect(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected RedirectResult Redirect<TController>(Expression<Action<TController>> controllerAction) {
            return Redirect(UrlGenerator.Generate(controllerAction).AbsoluteUri);
        }

        protected RedirectResult Redirect<TController>(Expression<Action<TController>> controllerAction, object routeValues) {
            return Redirect(UrlGenerator.Generate(controllerAction, routeValues).AbsoluteUri);
        }
    }
}