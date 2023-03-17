using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models {

    public class Projects {
        //properties
        public int ProjectsId { get; set; }
        [Required(ErrorMessage = "Add project name")]
        [Display(Name = "Project name: ")]       
         public string? ProjectsName { get; set; }
        [Required(ErrorMessage = "Add a description")]
        [Display(Name = "Description: ")]  
        public string? ProjectDescription { get; set; }
        [Required(ErrorMessage = "Add a url")]
        [Display(Name = "Github-link: ")]  
        public string? ProjectUrl { get; set; } 

    }

}

// dotnet aspnet-codegenerator controller -name ProjectsController -m Projects -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

//API controller

// dotnet aspnet-codegenerator controller -name APIController -api -async -m Projects -dc ApplicationDbContext -outDir Controllers