using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace COC_SCCJ_Evaluation.Models
{
    public class QuestionModel
    {

        private int id;
        private int categoryId;
        private bool hasImage;
        private bool imageUri;
        private string question;
        private string answer;
        private string option1;
        private string option2;
        private string option3;
        private string option4;

        // PROPS
        [DisplayName("Question ID")]
        public int Id { get => id; set => id = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public bool HasImage { get => hasImage; set => hasImage = value; }

        [DisplayName("Question Image")]
        [ConditionalRequired("HasImage", ErrorMessage = "Image is required when HasImage is true")]
        public bool ImageUri { get => imageUri; set => imageUri = value; }


        [DisplayName("Question Name")]
        [Required(ErrorMessage = "Question Can't be empty")]
        [MinLength(3, ErrorMessage = "The question must not be below 3 Characters")]
        public string Question { get => question; set => question = value; }


        [DisplayName("Question Answer")]
        [Required(ErrorMessage = "Answer Can't be empty")]
        [MinLength(3, ErrorMessage = "The answer must not be below 3 Characters")]
        public string Answer { get => answer; set => answer = value; }


        [DisplayName("Option 1")]
        [Required(ErrorMessage = "Option 1 Can't be empty")]
        [MinLength(3, ErrorMessage = "The option 1 must not be below 3 Characters")]
        public string Option1 { get => option1; set => option1 = value; }


        [DisplayName("Option 2")]
        [Required(ErrorMessage = "Option 2 Can't be empty")]
        [MinLength(3, ErrorMessage = "The option 2 must not be below 3 Characters")]
        public string Option2 { get => option2; set => option2 = value; }


        [DisplayName("Option 3")]
        [Required(ErrorMessage = "Option 3 Can't be empty")]
        [MinLength(3, ErrorMessage = "The option 3 must not be below 3 Characters")]
        public string Option3 { get => option3; set => option3 = value; }


        [DisplayName("Option 4")]
        [Required(ErrorMessage = "Option 4 Can't be empty")]
        [MinLength(3, ErrorMessage = "The option 4 must not be below 3 Characters")]
        public string Option4 { get => option4; set => option4 = value; }
    }

    public class ConditionalRequiredAttribute : ValidationAttribute
    {
        private readonly string _dependentPropertyName;

        public ConditionalRequiredAttribute(string dependentPropertyName)
        {
            _dependentPropertyName = dependentPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var dependentProperty = instance.GetType().GetProperty(_dependentPropertyName);

            if (dependentProperty == null)
            {
                throw new ArgumentException($"Property {_dependentPropertyName} not found on type {instance.GetType().Name}");
            }

            var dependentPropertyValue = (bool)dependentProperty.GetValue(instance);

            if (dependentPropertyValue && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
