using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator" })]
    public class RoleController : BaseController
    {
        private IFRole _iFRole;
        public RoleController(IFRole iFRole)
        {
            _iFRole = iFRole;
        }

        #region Create
        [HttpGet]                                       //added
        public ActionResult Create()                    //added
        {                                               //added
            return View(new Role());                    //added
        }                                           //added
        [HttpPost]                          //added
        public ActionResult Create(Role role)       //added
        {                                           //added
            var createdRole = _iFRole.Create(UserId, role); //added
            return RedirectToAction("Index");   //added
        }                                       //added
        #endregion

        #region Read
        [HttpGet]                           //added
        public ActionResult Index()         //added
        {                                   //added
            return View();                  //added
        }                                   //added
        public JsonResult Read()
        {
            return Json(_iFRole.Read("Name"));
        }

        [HttpPost]
        public JsonResult ReadAssignedRole(int id)
        {
            return Json(_iFRole.Read(id, "Name"));
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)      //added
        {                                       //added
            return View(_iFRole.Read(id));     //added
        }                                       //added
        [HttpPost]                                 //added
        public ActionResult Update(Role role)       //added
        {                                       //added
            var createdRole = _iFRole.Update(UserId, role);     //added
            return RedirectToAction("Index");       //added
        }                                           //added
        #endregion

        #region Delete
        [HttpDelete]                       //added
        public JsonResult Delete(int id)        //added
        {                                       //added
            _iFRole.Delete(id);             //added
            return Json(string.Empty);          //added
        }                       //added
        #endregion
    }
}