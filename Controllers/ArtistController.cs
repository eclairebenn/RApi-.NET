using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        public List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [Route("artists")]
        [HttpGet]
        public JsonResult displayAll(){

            return Json(allArtists);
        }

        [Route("artists/name/{name}")]
        [HttpGet]
        public JsonResult artistName(string name){
            List<Artist> artistMatch = allArtists.Where(performer => performer.RealName.Contains($"{name}") || performer.ArtistName.Contains($"{name}")).ToList();
            return Json(artistMatch);
        }

        [Route("artists/realname/{name}")]
        [HttpGet]
        public JsonResult artistRealName(string name){
            List<Artist> artistMatch = allArtists.Where(performer => performer.RealName.Contains($"{name}")).ToList();
            return Json(artistMatch);
        }

        [Route("artists/hometown/{town}")]
        [HttpGet]
        public JsonResult artistHomeTown(string town){
            List<Artist> artistMatch = allArtists.Where(performer => performer.Hometown.Contains($"{town}")).ToList();
            return Json(artistMatch);
        }

        [Route("artists/groupid/{id}")]
        [HttpGet]
        public JsonResult artistGroup(int id){
            List<Artist> artistMatch = allArtists.Where(performer => performer.GroupId == id).ToList();
            return Json(artistMatch);
        }


        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
    }
}