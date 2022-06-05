using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using FengShuiNumber.Repositories;
using FengShuiNumber.Services.ValidationServices;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FengShuiNumber.Services
{
    public class PhoneNumberService: IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IFengShuiNumberValidation _validation;

        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository, IFengShuiNumberValidation validation)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _validation = validation;
        }

        public async Task<string> GetAllFengShuiNumberToDocx()
        {
            this.SetUpFengshuiValidator(_validation);

            var phoneNumbers = _phoneNumberRepository.GetAll();

            var valid_phoneNumber = new List<PhoneNumber>();

            foreach(var phonenumber in phoneNumbers)
            {
                if (_validation.Validate(phonenumber)) valid_phoneNumber.Add(phonenumber);
            }

            return CreateFengShuiNumberDocx(valid_phoneNumber);
        }

        private void SetUpFengshuiValidator(IFengShuiNumberValidation validation)
        {
            if (validation == null) return;

            validation.AddRuleValidation(new StringLengthValidation());
            validation.AddRuleValidation(new NetWorkProviderValidation());
            validation.AddRuleValidation(new Last2DigitsValidation());
            validation.AddRuleValidation(new SumCaculateValidation());
        }
    
        private string CreateFengShuiNumberDocx(List<PhoneNumber> phoneNumbers)
        {

            var contextPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (contextPath == null)
            {
                return null;
            }

            string folder_path = Path.Combine(contextPath, "Data");

            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }

            var filePath = Path.Combine(folder_path, "FengShuiNumber.docx");

            Document document = new Document();

            Paragraph paragraph = document.AddSection().AddParagraph();

            paragraph.ApplyStyle(BuiltinStyle.Heading1);
            paragraph.AppendText($"FengShui Number (total: {phoneNumbers.Count})");

            Paragraph paragraph_body = document.Sections[0].AddParagraph();

            var phones_text = "";

            int count = 0;

            foreach (var phoneNumber in phoneNumbers)
            {
                count++;
                phones_text += phoneNumber.Number + Environment.NewLine;
                if(count == 1000)
                {
                    paragraph_body.AppendText(phones_text);
                    count = 0;
                    phones_text = "";
                }
            }

            if(count < 1000 && count > 0) paragraph_body.AppendText(phones_text);



            document.SaveToFile(filePath);

            return filePath;
        }
    }
}
