using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Areas.Administrator.Models;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Providers;

namespace MvcPL.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMailService _mailService;
        private readonly IPupilService _pupilService;
        private readonly IParentService _parentService;
        private readonly ITeacherService _teacherService;
        private readonly IFullUserService _fullUserService;
        

        public UserController(IUserService userService, IRoleService roleService, IMailService mailService, IPupilService pupilService, IParentService parentService, ITeacherService teacherService, IFullUserService fullUserService)
        {
            _userService = userService;
            _roleService = roleService;
            _mailService = mailService;
            _pupilService = pupilService;
            _parentService = parentService;
            _teacherService = teacherService;
            _fullUserService = fullUserService;
        }

        #region Index

        [ActionName("Index")]
        public ActionResult Index()
        {
            return View(_userService.GetAll().Select(s=>s.ToUserModel()));
        }

        #endregion
        
        #region Full User information

        #region Create information

        #region user

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Error while registration");
                }
                else
                {
                    var provider = (CustomMembershipProvider)Membership.Provider;

                    if (provider.GetUser(model.Login, false) != null)
                    {
                        ModelState.AddModelError("", "Login already exist");
                        return View(model);
                    }
                    provider.CreateUser(model);
                    var user = _userService.GetUserByLogin(model.Login);
                    return RedirectToAction("DetailsCreateUser", user);
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }


        #endregion

        #region role

        public ActionResult AddRoleUserLink(string role, int idUser)
        {
            _userService.AddUserRole(idUser,_roleService.GetRoleByName(role).Id);
            ViewBag.Info = "Role " + role + "added for user";
            var user = _userService.GetById(idUser);
            return RedirectToAction("DetailsCreateUser", user);
        }

        #endregion

        #region email

        public ActionResult AddEmail(int idUser)
        {
            return View(new MailModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddEmail(MailModel model)
        {
            _mailService.Create(model.ToBllMail());
            ViewBag.Info = "Mail " + model.Email + "added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("DetailsCreateUser", user);
        }

        #endregion

        #region pupil

        public ActionResult AddPupil(int idUser)
        {
            return View(new PupilModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddPupil(PupilModel model)
        {
            var role = "Pupil";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _pupilService.Create(model.ToBllPupil());
            ViewBag.Info = "Role Pupil added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("DetailsCreateUser", user);
        }

        #endregion

        #region parent

        public ActionResult AddParent(int idUser)
        {
            return View(new ParentModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddParent(ParentModel model)
        {
            var role = "Parent";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _parentService.Create(model.ToBllParent());
            ViewBag.Info = "Role parent added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("DetailsCreateUser", user);
        }

        #endregion

        #region teacher

        public ActionResult AddTeacher(int idUser)
        {
            return View(new TeacherModel(){ IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddTeacher(TeacherModel model)
        {
            var role = "Teacher";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _teacherService.Create(model.ToBlllTeacher());
            ViewBag.Info = "Role Pupil added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("DetailsCreateUser", user);
        }

        #endregion

        #endregion

        #region edit

        #region UserInformation

        public ActionResult UserInformation(int idUser)
        {
            try
            {
                return View(_fullUserService.SetFullUserEntity(idUser).ToFullUserModel());
            }
            catch (Exception)
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult UserInformation(FullUserModel model)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region mail

        public ActionResult _Mail(IEnumerable<MailModel> model)
        {
            return PartialView(model);
        } 

        public ActionResult EditMailUser(int id)
        {
            return View(_mailService.GetById(id).ToMailModel());
        }

        [HttpPost]
        public ActionResult EditMailUser(MailModel model)
        {
            _mailService.Update(model.ToBllMail());
            return RedirectToAction("UserInformation", new { idUser = model.IdUser});
        }
        #endregion

        #region user

        public ActionResult _User(UserModel model)
        {
            return PartialView(model);
        }

        public ActionResult EditUser(int idUser)
        {
            return View(_userService.GetById(idUser).ToUserModel());
        }

        [HttpPost]
        public ActionResult EditUser(UserModel model)
        {
            _userService.Update(model.ToDalUser());
            return RedirectToAction("UserInformation", new { idUser = model.Id });
        }

        #endregion

        #region parent

        public ActionResult _Parent(ParentModel model)
        {
            return PartialView(model);
        }

        public ActionResult EditParentUser(int idParent)
        {
            return View(_parentService.GetById(idParent).ToParentModel());
        }

        [HttpPost]
        public ActionResult EditParentUser(ParentModel model)
        {
            _parentService.Update(model.ToBllParent());
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }

        #endregion

        #region pupil

        public ActionResult _Pupil(PupilModel model)
        {
            return PartialView(model);
        }

        public ActionResult EditPupilUser(int idPupil)
        {
            return View(_pupilService.GetById(idPupil).ToPupilModel());
        }

        [HttpPost]
        public ActionResult EditPupilUser(PupilModel model)
        {
            _pupilService.Update(model.ToBllPupil());
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }

        #endregion

        #region teacher

        public ActionResult _Teacher(TeacherModel model)
        {
            return PartialView(model);
        }

        public ActionResult EditTeacherUser(int idTeacher)
        {
            return View(_teacherService.GetById(idTeacher).ToTeacherModel());
        }

        [HttpPost]
        public ActionResult EditTeacherUser(TeacherModel model)
        {
            _teacherService.Update(model.ToBlllTeacher());
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }
        #endregion

        #region role

        public ActionResult _Role(IEnumerable<RoleModel> model)
        {
            return PartialView(model);
        }

        public ActionResult AddRoleUser(int idRole, int idUser)
        {
           _userService.AddUserRole(idUser, idRole);
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }

        #endregion
        
        #region add information

        #region role

        public ActionResult AddRoleUserLinkEdit(string role, int idUser)
        {
            _userService.AddUserRole(idUser, _roleService.GetRoleByName(role).Id);
            ViewBag.Info = "Role " + role + "added for user";
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }

        #endregion

        #region email

        public ActionResult AddEmailEdit(int idUser)
        {
            return View(new MailModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddEmailEdit(MailModel model)
        {
            _mailService.Create(model.ToBllMail());
            ViewBag.Info = "Mail " + model.Email + "added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("UserInformation", new { idUser = user.Id });
        }

        #endregion

        #region pupil

        public ActionResult AddPupilEdit(int idUser)
        {
            return View(new PupilModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddPupilEdit(PupilModel model)
        {
            var role = "Pupil";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _pupilService.Create(model.ToBllPupil());
            ViewBag.Info = "Role Pupil added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }

        #endregion

        #region parent

        public ActionResult AddParentEdit(int idUser)
        {
            return View(new ParentModel { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddParentEdit(ParentModel model)
        {
            var role = "Parent";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _parentService.Create(model.ToBllParent());
            ViewBag.Info = "Role parent added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }

        #endregion

        #region teacher

        public ActionResult AddTeacherEdit(int idUser)
        {
            return View(new TeacherModel() { IdUser = idUser });
        }

        [HttpPost]
        public ActionResult AddTeacherEdit(TeacherModel model)
        {
            var role = "Teacher";
            _userService.AddUserRole(model.IdUser, _roleService.GetRoleByName(role).Id);
            _teacherService.Create(model.ToBlllTeacher());
            ViewBag.Info = "Role Pupil added for user";
            var user = _userService.GetById(model.IdUser);
            return RedirectToAction("UserInformation", new { idUser = model.IdUser });
        }

        #endregion 

        #endregion
        
        #endregion

        #region details

        public ActionResult DetailsCreateUser(UserModel model)
        {
            ViewBag.InfoMassage = ViewBag.Info;
            return View(model);
        }

        public ActionResult DetailUser(int idUser)
        {
            return View(_fullUserService.SetFullUserEntity(idUser).ToFullUserModel());
        }

        #endregion
        
        #region delete

        public ActionResult DeleteUser(int idUser)
        {
            try
            {
                return View(_fullUserService.SetFullUserEntity(idUser).ToFullUserModel());
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(FullUserModel model)
        {
            try
            {
                model = _fullUserService.SetFullUserEntity(model.User.Id).ToFullUserModel();
                _fullUserService.Delete(_fullUserService.SetFullUserEntity(model.User.Id));
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteRoleEdit(int idRole, int idUser)
        {
            _roleService.DeleteUserToRole(idUser, idRole);
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }

        public ActionResult DeleteMailEdit(int idMail, int idUser)
        {
            _mailService.Delete(_mailService.GetById(idMail));
            return RedirectToAction("UserInformation", new { idUser = idUser});
        }


        public ActionResult DeleteParentEdit(int idParent)
        {
            var idUser = _parentService.GetById(idParent).IdUser;
            var role = _roleService.GetRoleByName("Parent").Id;
            _roleService.DeleteUserToRole(idUser, role);
            _parentService.Delete(_parentService.GetById(idParent));
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }

        public ActionResult DeletePupilEdit(int idPupil)
        {
            var idUser = _pupilService.GetById(idPupil).IdUser;
            var role = _roleService.GetRoleByName("Pupil").Id;
            _roleService.DeleteUserToRole(idUser, role);
            _pupilService.Delete(_pupilService.GetById(idPupil));
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }

        public ActionResult DeleteTeacherEdit(int idTeacher)
        {
            var idUser = _teacherService.GetById(idTeacher).IdUser.Value;
            var role = _roleService.GetRoleByName("Teacher").Id;
            _roleService.DeleteUserToRole(idUser, role);
            _teacherService.Delete(_teacherService.GetById(idTeacher));
            return RedirectToAction("UserInformation", new { idUser = idUser });
        }


        #endregion
        
        #endregion

    }
}
