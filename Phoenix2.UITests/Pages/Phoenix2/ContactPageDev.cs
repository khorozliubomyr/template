using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;

namespace Phoenix2.UITests.Pages.Phoenix2
{
    class ContactPageDev : BaseDriver
    {
        #region driver
        public ContactPageDev(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "Phoenix 2.0";
        protected override string PageUrl => "https://dev-api-v2.ilendingdirect.com/admin-tools";
        #endregion

        #region PATH

         #region ContactTab
        private string _recordOnAllContactsTable = "(//div[@class='MuiDataGrid-cell'])[1]";
        private string _contactTab = "//button[text()='Contact']";
        private string _assetTab = "//button[text()='Assets']";
        private string _leadsTab = "//button[text()='Leads']";
        private string _dealsTab = "//button[text()='Deals']";
        private string _filesTab = "//button[text()='Files']";
        private string _headerOfContactPage = "//div[@class='sc-bHfcXc vdJHX']";
        private string _leadCommentsSection = "//div[@class='sc-eVBRet cfAazg MuiBox-root']//div[@class='sc-eVBRet cfAazg MuiBox-root']";
        private string _saveButton = "//button[text()='Save']";
        private string _dataReviewButton = "//button[text()='Data Review']";
        private string _addCoAplicantButton = "//button[text()='Add Co-Applicant']";
        #endregion

         #region Perconal Information
        private string _firstNameField = "firstName";
        private string _lastNameField = "lastName";
        private string _middleNameField = "middleInitial";
        private string _suffixDropDown = "//*[@Name='suffix']";
        private string _dataOfSuffixDropDown = "//*[@data-value='Jr.']";
        private string _dOBField = "//*[@aria-describedby=':r8b:-helper-text']";
        private string _sSNField = "ssn";
        private string _personalEmailField = "email";
        private string _homePhoneField = "homePhone";
        private string _workPhoneField = "workPhone";
        private string _cellPhoneField = "cellPhone";
        private string _dLNumberField = "driverLicenseNumber";
        private string _successfulyPopup = "//div[contains(text(),'Successfully')]";
        private string _warningPopup = "//div[contains(text(),'Something went wrong')]";
        private string _requiredHint = "//p[text()='First Name is required']";
        private string _confirmButtonForDeleting = "//button[normalize-space()='Confirm']";
        #endregion

         #region Address
        private string _addNewAddressButton = "//div[text()='Add New Address']";
        private string _streetField = "//*[@data-field='streetLine1']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _unitField = "//*[@data-field='unit']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _cityField = "//*[@data-field='city']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _countryField = "//*[@data-field='county']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _stateDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[1]";
        private string _dataOfStateDropDown = "//*[@data-value='AK']";
        private string _zipField = "(//*[@data-field='zip']//*[@type='text'])[2]";
        private string _typeDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[2]";
        private string _dataOfTypeDropDown = "//*[@data-value='NotSet']";
        private string _yrsField = "//*[@data-field='yrs']//*[@class='sc-gXmSlM sc-cTQhss dQfRFz ilRpvi MuiOutlinedInput-root MuiInputBase-root MuiInputBase-colorPrimary MuiInputBase-fullWidth MuiInputBase-formControl']";
        private string _moField = "//*[@data-field='mo']//*[@class='sc-iAvgwm dFRxZH sc-jOrMOR bEHqIo MuiOutlinedInput-notchedOutline']";
        private string _cancelButton = "//button[text()='Cancel']";
        private string _saveButtonAddressSection = "//*[@data-field='options']//button[text()='Save']";
        private string _fieldForEdit = "(//*[@data-field='streetLine1'])[4]";
        private string _deleteIconAddressSection = "(//*[@data-field='options']//*[@stroke='currentColor'])[5]";
        #endregion

         #region Employments 
        private string _addNewEmploymentButton = "//*[@class='sc-kOZHUs kojTYP']//div[text()='Add New Employment']";
        private string _currentEmploymentCheckBox = "//*[@data-field='isCurrent']//*[@data-testid='CheckBoxOutlineBlankIcon']";
        private string _primaryCheckBox = "//*[@data-field='isPrimary']//*[@data-testid='CheckBoxOutlineBlankIcon']";
        private string _companyField = "//*[@data-field='companyName']//input[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _positionField = "//*[@data-field='jobTitle']//input[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _typeOfEmploymentDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[1]";
        private string _fullTimeRecordOfTypeDropDown = "//*[@data-value='FullTime']";
        private string _monthlyIncomeField = "//*[@data-field='monthlyIncomeAmount']//*[@class='sc-gXmSlM sc-cTQhss dQfRFz ilRpvi MuiOutlinedInput-root MuiInputBase-root MuiInputBase-colorPrimary MuiInputBase-fullWidth MuiInputBase-formControl']";
        private string _yrsOfEmploymentField = "//*[@data-field='yrs']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _moOfEmploymentField = "//*[@data-field='mo']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _phomeField = "//*[@value='(___) ___-____']";
        private string _streetOfEmploymentField = "//*[@data-field='streetLine1']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _unitOfEmploymentField = "//*[@data-field='unit']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _cityOfEmploymentField = "//*[@data-field='city']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _stateOfEmploymentDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[2]";
        private string _zipOfEmploymentField = "//*[@data-field='zip']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _saveButtonEmploymentSection = "//*[@data-field='options']//*[text()='Save']";
        private string _fieldForEditEmploumentSection = "(//*[@data-field='companyName' and @role='cell'])[1]";
        private string _recordForDelete = "(//*[text()='Employments']/../../..//*[@data-field='zip' and @role='cell'])[1]";
        private string _deleteIconEmploymentSection = "(//*[@data-id='0']//*[@data-field='options']//span[@class='sc-ftvSup cbIzGX MuiTouchRipple-root'])[3]";
        #endregion

         #region Other Incomes 
        private string _addNewOtherIncomeButton = "//div[contains(text(),'Add New Reference')]";
        private string _currentOtherIncomeCheckBox = "//*[@data-field='isCurrent']//*[@class='sc-kjEcyX lnExge PrivateSwitchBase-input']";
        private string _monthlyAmountField = "//*[@data-field='monthlyAmount']//input[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _yrsOfOtherIncomesField = "//*[@data-field='yrs']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _moOfOtherIncomesField = "//*[@data-field='mo']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _fieldForEditOtherIncomesSection = "(//*[@data-field='monthlyAmount'])[2]";
        #endregion

         #region References 
        private string _addNewReferenceButton = "//div[text()='Add New Reference']";
        private string _fullNameField = "//*[@data-field='fullName']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _phomeOfReferenceField = "//*[@value='(___) ___-____']";
        private string _emailAddressField = "//*[@data-field='emailAddress']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _addressField = "//*[@data-field='streetLine1']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _cityOfReferenceField = "//*[@data-field='city']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _stateOfReferenceDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[1]";
        private string _zipOfReferenceField = "//*[@data-field='zip']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _typeOfReferenceDropDown = "(//*[@class='sc-bxSTMQ fvbjgQ']//*[@aria-haspopup='listbox'])[2]";
        private string _dataOfReferenceDropDown = "//li[text()='Not Set']";
        private string _relationshipField = "//*[@data-field='relationshipType']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _recordForEditField = "//*[@type='tel']/../../../div[@data-field='phoneNumber']//input[@value]";
        private string _fieldForEditReferenceSection = "(//*[@data-field='fullName'])[2]";
        #endregion

         #region Co-AplicantPopUp
        private string _saveButtonCoAplicantPopUp = "//*[@role='dialog']//button[text()='Save']";
        private string _firstNameFieldCoAplicantPopUp = "//*[@role='dialog']//*[@id='firstName']";
        private string _addNewAddressCoAplicantPopUp = "//*[@role='dialog']//div[text()='Add New Address']";
        private string _addNewEmploymentCoAplicantPopUp = "//*[@role='dialog']//div[text()='Add New Employment']";
        private string _addNewOtherIncomeCoAplicantPopUp = "//*[@role='dialog']//div[text()='Add New Other Income']";
        private string _addNewReferenceCoAplicantPopUp = "//*[@role='dialog']//div[text()='Add New Reference']";
        private string _relationshipTypeDropDown = "//*[@role='dialog']//*[@id='mui-component-select-relationshipType']";
        private string _dataOfRelationshipType = "//li[@data-value='Parent']";
        private string _lastNameFieldCoAplicantPopUp = "//*[@role='dialog']//*[@id='lastName']";
        private string _homePhoneFieldCoAplicantPopUp = "//*[@role='dialog']//*[@id='homePhone']";
        private string _workPhoneFieldCoAplicantPopUp = "//*[@role='dialog']//*[@id='workPhone']";
        private string _cellPhoneFieldCoAplicantPopUp = "//*[@role='dialog']//*[@id='cellPhone']";
        private string _canselButtonCoAplicantPopUp = "//*[@role='dialog']//button[text()='Cancel']";
        private string _recordCoAplicantForEdit = "(//div[@class='sc-bJsHXV eEFjG']//*[text()='Man'])[1]";
        private string _renoveButtonCoApplicantSection = "(//div[@class='sc-bJsHXV eEFjG']//*[text()='Man']/../button)[1]";
        #endregion

         #region Contact Users Section
        private string _leadCommentField = "//*[@placeholder='Type your comment here']";
        private string _addCommentButton = "//button[text()='Add Comment']";
        private string _recordInContactUsers = "(//*[@class='sc-jNxMLV dvTDhD']//span[contains(text(),'Test')])[1]";
        #endregion

         #region Asset Tab
        private string _addAssetButton = "//button[text()='Add Asset']";
        private string _seveAssetButton = "//button[text()='Save Asset']";
        private string _headerOfAssetTab = "//div[text()='FirstName 11']";
        private string _assetDropDown = "(//div[@role='button']//em[text()='None'])[1]";
        private string _recordOfAssetDropDown = "//li[@class='sc-jqUVSM kRfUwV MuiMenuItem-root MuiMenuItem-gutters MuiButtonBase-root sc-fHsOPI kmmPGN'][1]";
        private string _odometerField = "mileage";
        private string _vINField = "vin";
        private string _yearDropDown = "//*[@id='mui-component-select-year']";
        private string _recordOfYearDropDown = "//*[@data-value='2000']";
        private string _makeDropDown = "//*[@name='make']";
        private string _recordOfMakeDropDown = "//*[@data-value='BMW']";
        private string _modelDropDown = "//*[@class='sc-gXmSlM sc-cTQhss ftRTIU ilRpvi MuiOutlinedInput-root MuiInputBase-root MuiInputBase-colorPrimary Mui-error sc-ckMVTt sc-jZiqTT gXGpYR']//*[@id]";
        private string _recordOfModelDropDown = "//*[@data-value='X5']";
        private string _lienHolderDropDown = "//div[@name='assetLienHolder.lienHolderId']//input[@placeholder='Lien Holder']";
        private string _accountNumberField = "assetLienHolder.accountNumber";
        private string _assetColumn = "//div[@class='sc-jOhDuK edprTA MuiGrid-root MuiGrid-item MuiGrid-grid-xs-3']//*[text()='Asset']";
        private string _lienColumn = "//div[@class='sc-jOhDuK edprTA MuiGrid-root MuiGrid-item MuiGrid-grid-xs-3']//*[text()='Lien']";
        private string _valuationColumn = "//div[@class='sc-jOhDuK edprTA MuiGrid-root MuiGrid-item MuiGrid-grid-xs-3']//*[text()='Valuation']";
        private string _registrationColumn = "//div[@class='sc-jOhDuK edprTA MuiGrid-root MuiGrid-item MuiGrid-grid-xs-3']//*[text()='Registration']";
        private string _requiredHintOfAssetTab = "//p[text()='Lien Holder is required']";
        private string _requiredHintOfAssetTabForOdmeterField = "//p[text()='Odometer is required']";
        private string _recordOfAssetDropDownForEdit = "//li[contains(text(),'BMW')]";
        #endregion

         #region Leads Tab
        private string _addNewLeadButton = "//button[text()='Add New Lead']";
        private string _leadsTable = "//div[@class='sc-iuStju jgYFsR MuiDataGrid-columnHeaders']";
        private string _addNewPopUp = "//div[@class='sc-kIKDeO dIbWDe']";
        private string _assetDropDownOfLeadTab = "//*[@id='mui-component-select-assetId']//*";
        private string _recordOfAssetDropDownAddNewPopUp = "//li[contains(text(),'BMW')][1]";
        private string _secondarySourceDropDownOfLeadTab = "//*[@id='mui-component-select-secondarySourceId']//*";
        private string _recordOfSecondarySourceDropDownOfLeadTab = "(//*[text()='Testing'])[2]";
        private string _saveButtonOfLeadTab = "//button[text()='Save']";
        private string _requiredHintOfLeadTabForAssetDropDown = "//p[text()='Please select asset']";

        #endregion

        #region Fiels Tab
        private string _downloadAllButton = "//button[text()='Download All']";
        private string _uploadButton = "//button[text()='Upload Files']";
        private string _assetDropDownOfFielsTab = "//*[@data-testid='ArrowDropDownIcon']/../../..//*[@class='sc-bxSTMQ fvbjgQ']";
        private string _tableFiles = "//*[@class='sc-ddcaxn cYDEBW MuiDataGrid-columnHeadersInner MuiDataGrid-columnHeadersInner--scrollable']";
        private string _recordOfAssetDropDownForFilesTab = "//li[contains(text(),'INFINITI')]";
        private string _recordFilesTable = "(//*[@class='MuiDataGrid-row MuiDataGrid-row--editable'])[1]";
        private string _selectDealDropDown = "//em[text()='Select Deal']";
        private string _typeDropDownOfFielTable = "(//*[@data-testid='ArrowDropDownIcon']/../../..//*[@class='sc-bxSTMQ fvbjgQ'])[3]";
        private string _recordOfTypeDropDown = "//li[text()='Batch Label']";
        private string _recordForEditOfTypeDropDown = "//li[text()='Bookout']";
        private string _fileName = "(//button[contains(text(),'BookoutSheet')])[1]";
        private string _openInNewWondowIcon = "//*[@data-testid='OpenInNewIcon']";
        private string _downloanIcon = "//*[@data-testid='DownloadIcon']";
        private string _fileOfSelectedFileName = "//*[@data-testid='core__text-layer-0']";
        private string _pendingRadioButton = "//*[@name='Pending']";
        private string _approveRadioButton = "//*[@name='Approve']";
        private string _approveConditionRadioButton = "//*[@name='Approve Condition']";
        private string _denyConditionRadioButton = "//*[@name='Deny']";

        #endregion
        #endregion

        #region ELEMENT
        #region ContactTab
        private IWebElement RecordOnAllContactsTable => FindElementByXpath(_recordOnAllContactsTable);
        private IWebElement ContactTab => FindElementByXpath(_contactTab);
        private IWebElement AssetTab => FindElementByXpath(_assetTab);
        private IWebElement LeadsTab => FindElementByXpath(_leadsTab);
        private IWebElement DealsTab => FindElementByXpath(_dealsTab);
        private IWebElement FilesTab => FindElementByXpath(_filesTab);
        private IWebElement HeaderOfContactPage => FindElementByXpath(_headerOfContactPage);
        private IWebElement LeadCommentsSection => FindElementByXpath(_leadCommentsSection);
        private IWebElement SaveButton => FindElementByXpath(_saveButton);
        private IWebElement DataReviewButton => FindElementByXpath(_dataReviewButton);
        private IWebElement SuccessfulyPopup => FindElementByXpath(_successfulyPopup);
        private IWebElement WarningPopup => FindElementByXpath(_warningPopup);
        #endregion

         #region Perconal Information
        private IWebElement FirstNameField => FindElementById(_firstNameField);
        private IWebElement LastNameField => FindElementById(_lastNameField);
        private IWebElement MiddleNameField => FindElementById(_middleNameField);
        private IWebElement SuffixDropDown => FindElementByXpath(_suffixDropDown);
        private IWebElement DataOfSuffixDropDown => FindElementByXpath(_dataOfSuffixDropDown);
        private IWebElement DOBField => FindElementByXpath(_dOBField);
        private IWebElement SSNField => FindElementById(_sSNField);
        private IWebElement PersonalEmailField => FindElementById(_personalEmailField);
        private IWebElement HomePhoneField => FindElementById(_homePhoneField);
        private IWebElement WorkPhoneField => FindElementById(_workPhoneField);
        private IWebElement CellPhoneField => FindElementById(_cellPhoneField);
        private IWebElement BLNumberField => FindElementById(_dLNumberField);
        private IWebElement AddCoAplicantButton => FindElementByXpath(_addCoAplicantButton);
        private IWebElement RequiredHint => FindElementById(_requiredHint);
        private IWebElement DeleteIconAddressSection => FindElementByXpath(_deleteIconAddressSection);
        private IWebElement ConfirmButtonForDeleting => FindElementByXpath(_confirmButtonForDeleting);
        #endregion

         #region Address
        private IWebElement AddNewAddressButton => FindElementByXpath(_addNewAddressButton);
        private IWebElement StreetField => FindElementByXpath(_streetField);
        private IWebElement UnitField => FindElementByXpath(_unitField);
        private IWebElement CityField => FindElementByXpath(_cityField);
        private IWebElement CountryField => FindElementByXpath(_countryField);
        private IWebElement StateDropDown => FindElementByXpath(_stateDropDown);
        private IWebElement DataOfStateDropDown => FindElementByXpath(_dataOfStateDropDown);
        private IWebElement ZipField => FindElementByXpath(_zipField);
        private IWebElement TypeDropDown => FindElementByXpath(_typeDropDown);
        private IWebElement DataOfTypeDropDown => FindElementByXpath(_dataOfTypeDropDown);
        private IWebElement YrsField => FindElementByXpath(_yrsField);
        private IWebElement MoField => FindElementByXpath(_moField);
        private IWebElement CancelButton => FindElementByXpath(_cancelButton);
        private IWebElement SaveButtonAddressSection => FindElementByXpath(_saveButtonAddressSection);
        private IWebElement FieldForEdit => FindElementByXpath(_fieldForEdit);
        #endregion

         #region Employments
        private IWebElement AddNewEmploymentButton => FindElementByXpath(_addNewEmploymentButton);
        private IWebElement CurrentEmploymentCheckBox => FindElementByXpath(_currentEmploymentCheckBox);
        private IWebElement PrimaryCheckBox => FindElementByXpath(_primaryCheckBox);
        private IWebElement CompanyField => FindElementByXpath(_companyField);
        private IWebElement PositionField => FindElementByXpath(_positionField);
        private IWebElement TypeOfEmploymentDropDown => FindElementByXpath(_typeOfEmploymentDropDown);
        private IWebElement FullTimeRecordOfTypeDropDown => FindElementByXpath(_fullTimeRecordOfTypeDropDown);
        private IWebElement MonthlyIncomeField => FindElementByXpath(_monthlyIncomeField);
        private IWebElement YrsOfEmploymentField => FindElementByXpath(_yrsOfEmploymentField);
        private IWebElement MoOfEmploymentField => FindElementByXpath(_moOfEmploymentField);
        private IWebElement PhomeField => FindElementByXpath(_phomeField);
        private IWebElement StreetOfEmploymentField => FindElementByXpath(_streetOfEmploymentField);
        private IWebElement UnitOfEmploymentField => FindElementByXpath(_unitOfEmploymentField);
        private IWebElement CityOfEmploymentField => FindElementByXpath(_cityOfEmploymentField);
        private IWebElement StateOfEmploymentDropDown => FindElementByXpath(_stateOfEmploymentDropDown);
        private IWebElement ZipOfEmploymentField => FindElementByXpath(_zipOfEmploymentField);
        private IWebElement SaveButtonEmploymentSection => FindElementByXpath(_saveButtonEmploymentSection);
        private IWebElement FieldForEditEmploumentSection => FindElementByXpath(_fieldForEditEmploumentSection);
        private IWebElement RecordForDelete => FindElementByXpath(_recordForDelete);
        private IWebElement DeleteIconEmploymentSection => FindElementByXpath(_deleteIconEmploymentSection);
        #endregion

         #region Other Incomes
        private IWebElement AddNewOtherIncomeButton => FindElementByXpath(_addNewOtherIncomeButton);
        private IWebElement CurrentOtherIncomeCheckBox => FindElementByXpath(_currentOtherIncomeCheckBox);
        private IWebElement MonthlyAmountField => FindElementByXpath(_monthlyAmountField);
        private IWebElement YrsOfOtherIncomesField => FindElementByXpath(_yrsOfOtherIncomesField);
        private IWebElement MoOfOtherIncomesField => FindElementByXpath(_moOfOtherIncomesField);
        private IWebElement FieldForEditOtherIncomesSection => FindElementByXpath(_fieldForEditOtherIncomesSection);
        #endregion

         #region References
        private IWebElement AddNewReferenceButton => FindElementByXpath(_addNewReferenceButton);
        private IWebElement FullNameField => FindElementByXpath(_fullNameField);
        private IWebElement PhomeOfReferenceField => FindElementByXpath(_phomeOfReferenceField);
        private IWebElement EmailAddressField => FindElementByXpath(_emailAddressField);
        private IWebElement AddressField => FindElementByXpath(_addressField);
        private IWebElement CityOfReferenceField => FindElementByXpath(_cityOfReferenceField);
        private IWebElement StateOfReferenceDropDown => FindElementByXpath(_stateOfReferenceDropDown);
        private IWebElement ZipOfReferenceField => FindElementByXpath(_zipOfReferenceField);
        private IWebElement TypeOfReferenceDropDown => FindElementByXpath(_typeOfReferenceDropDown);
        private IWebElement DataOfReferenceDropDown => FindElementByXpath(_dataOfReferenceDropDown);
        private IWebElement RelationshipField => FindElementByXpath(_relationshipField);
        private IWebElement FieldForEditReferenceSection => FindElementByXpath(_fieldForEditReferenceSection);
        private IWebElement RecordForEditField => FindElementByXpath(_recordForEditField);
        #endregion

         #region Co-AplicantPopUp
        private IWebElement SaveButtonCoAplicantPopUp => FindElementByXpath(_saveButtonCoAplicantPopUp);
        private IWebElement FirstNameFieldCoAplicantPopUp => FindElementByXpath(_firstNameFieldCoAplicantPopUp);
        private IWebElement AddNewAddressCoAplicantPopUp => FindElementByXpath(_addNewAddressCoAplicantPopUp);
        private IWebElement AddNewEmploymentCoAplicantPopUp => FindElementByXpath(_addNewEmploymentCoAplicantPopUp);
        private IWebElement AddNewOtherIncomeCoAplicantPopUp => FindElementByXpath(_addNewOtherIncomeCoAplicantPopUp);
        private IWebElement AddNewReferenceCoAplicantPopUp => FindElementByXpath(_addNewReferenceCoAplicantPopUp);
        private IWebElement RelationshipTypeDropDown => FindElementByXpath(_relationshipTypeDropDown);
        private IWebElement DataOfRelationshipType => FindElementByXpath(_dataOfRelationshipType);
        private IWebElement LastNameFieldCoAplicantPopUp => FindElementByXpath(_lastNameFieldCoAplicantPopUp);
        private IWebElement HomePhoneFieldCoAplicantPopUp => FindElementByXpath(_homePhoneFieldCoAplicantPopUp);
        private IWebElement WorkPhoneFieldCoAplicantPopUp => FindElementByXpath(_workPhoneFieldCoAplicantPopUp);
        private IWebElement CellPhoneFieldCoAplicantPopUp => FindElementByXpath(_cellPhoneFieldCoAplicantPopUp);
        private IWebElement CanselButtonCoAplicantPopUp => FindElementByXpath(_canselButtonCoAplicantPopUp);
        private IWebElement RecordCoAplicantForEdit => FindElementByXpath(_recordCoAplicantForEdit);
        private IWebElement RenoveButtonCoApplicantSection => FindElementByXpath(_renoveButtonCoApplicantSection);

        #endregion

         #region Contact Users
        private IWebElement LeadCommentField => FindElementByXpath(_leadCommentField);
        private IWebElement AddCommentButton => FindElementByXpath(_addCommentButton);
        private IWebElement RecordInContactUsers => FindElementByXpath(_recordInContactUsers);
        #endregion

         #region Asset Tab
        private IWebElement AddAssetButton => FindElementByXpath(_addAssetButton);
        private IWebElement SeveAssetButton => FindElementByXpath(_seveAssetButton);
        private IWebElement HeaderOfAssetTab => FindElementByXpath(_headerOfAssetTab);
        private IWebElement AssetDropDown => FindElementByXpath(_assetDropDown);
        private IWebElement RecordOfAssetDropDown => FindElementByXpath(_recordOfAssetDropDown);
        private IWebElement OdometerField => FindElementById(_odometerField);
        private IWebElement VINField => FindElementById(_vINField);
        private IWebElement YearDropDown => FindElementByXpath(_yearDropDown);
        private IWebElement RecordOfYearDropDown => FindElementByXpath(_recordOfYearDropDown);
        private IWebElement MakeDropDown => FindElementByXpath(_makeDropDown);
        private IWebElement RecordOfMakeDropDown => FindElementByXpath(_recordOfMakeDropDown);
        private IWebElement ModelDropDown => FindElementByXpath(_modelDropDown);
        private IWebElement RecordOfModelDropDown => FindElementByXpath(_recordOfModelDropDown);
        private IWebElement LienHolderDropDown => FindElementByXpath(_lienHolderDropDown);
        private IWebElement AccountNumberField => FindElementById(_accountNumberField);
        private IWebElement AssetColumn => FindElementByXpath(_assetColumn);
        private IWebElement LienColumn => FindElementByXpath(_lienColumn);
        private IWebElement ValuationColumn => FindElementByXpath(_valuationColumn);
        private IWebElement RegistrationColumn => FindElementByXpath(_registrationColumn);
        private IWebElement RequiredHintOfAssetTab => FindElementByXpath(_requiredHintOfAssetTab);
        private IWebElement RecordOfAssetDropDownForEdit => FindElementByXpath(_recordOfAssetDropDownForEdit);
        #endregion

         #region Leads Tab
        private IWebElement AddNewLeadButton => FindElementByXpath(_addNewLeadButton);
        private IWebElement LeadsTable => FindElementByXpath(_leadsTable);
        private IWebElement AddNewPopUp => FindElementByXpath(_addNewPopUp);
        private IWebElement AssetDropDownOfLeadTab => FindElementByXpath(_assetDropDownOfLeadTab);
        private IWebElement SecondarySourceDropDownOfLeadTab => FindElementByXpath(_secondarySourceDropDownOfLeadTab);
        private IWebElement RecordOfAssetDropDownAddNewPopUp => FindElementByXpath(_recordOfAssetDropDownAddNewPopUp);
        private IWebElement RecordOfSecondarySourceDropDownOfLeadTab => FindElementByXpath(_recordOfSecondarySourceDropDownOfLeadTab);
        private IWebElement SaveButtonOfLeadTab => FindElementByXpath(_saveButtonOfLeadTab);
        private IWebElement RequiredHintOfLeadTabForAssetDropDown => FindElementByXpath(_requiredHintOfLeadTabForAssetDropDown);

        #endregion

        #region Fiels Tab
        private IWebElement DownloadAllButton => FindElementByXpath(_downloadAllButton);
        private IWebElement UploadButton => FindElementByXpath(_uploadButton);
        private IWebElement AssetDropDownOfFielsTab => FindElementByXpath(_assetDropDownOfFielsTab);
        private IWebElement TableFiles => FindElementByXpath(_tableFiles);
        private IWebElement RecordOfAssetDropDownForFilesTab => FindElementByXpath(_recordOfAssetDropDownForFilesTab);
        private IWebElement RecordFilesTable => FindElementByXpath(_recordFilesTable);
        private IWebElement SelectDealDropDown => FindElementByXpath(_selectDealDropDown);
        private IWebElement TypeDropDownOfFielTable => FindElementByXpath(_typeDropDownOfFielTable);
        private IWebElement RecordOfTypeDropDown => FindElementByXpath(_recordOfTypeDropDown);
        private IWebElement RecordForEditOfTypeDropDown => FindElementByXpath(_recordForEditOfTypeDropDown);
        private IWebElement FileName => FindElementByXpath(_fileName);
        private IWebElement OpenInNewWondowIcon => FindElementByXpath(_openInNewWondowIcon);
        private IWebElement DownloanIcon => FindElementByXpath(_downloanIcon);
        private IWebElement FileOfSelectedFileName => FindElementByXpath(_fileOfSelectedFileName);
        private IWebElement PendingRadioButton => FindElementByXpath(_pendingRadioButton);
        private IWebElement ApproveRadioButton => FindElementByXpath(_approveRadioButton);
        private IWebElement ApproveConditionRadioButton => FindElementByXpath(_approveConditionRadioButton);
        private IWebElement DenyConditionRadioButton => FindElementByXpath(_denyConditionRadioButton);

        #endregion
        #endregion

        #region METHOD
        public void NavigateTo()
        {
            if (PageTitle == "")
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
            }
            else
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
                EnsurePageLoaded();
            }
        }
        public void SelectContactInAllContactPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_recordOnAllContactsTable)));
            RecordOnAllContactsTable.Click();
        }
          #region Contact tab
        public void VerifyContactPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_contactTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_leadsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_dealsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_filesTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_headerOfContactPage)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_leadCommentsSection)));
        }
        public void EditMiddleName()
        {
            MiddleNameField.Click();
            MiddleNameField.Clear();
            MiddleNameField.SendKeys("Test");
        }
        public void ClickOnSaveButton()
        {
            SaveButton.Click();
        }
        public void VerifyChanges()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
        }
        public void VerifyWarningPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_warningPopup)));
        }
        public void ClearFirstName()
        {
            FirstNameField.Click();
            FirstNameField.Clear();
        }
        public void ClickOnNextField()
        {
            LastNameField.Click();
        }
        public void VerifyRequiredHint()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_requiredHint)));
        }
        public void AddInfoForEditing()
        {
            PersonalEmailField.Click();
            PersonalEmailField.Clear();
            PersonalEmailField.SendKeys("test@test.com");
            SSNField.Click();
            SSNField.Clear();
            SSNField.SendKeys("123456789");
        }
        public void ClickOnAddNewAddress()
        {
            Actions.MoveToElement(AddNewAddressButton).Click().Build().Perform();
        }
        public void FillAllFieldForAddressInfo()
        {
            AddNewAddressButton.Click();
            StreetField.Click();
            StreetField.SendKeys("123 Test");
            UnitField.Click();
            UnitField.SendKeys("123 Test");
            CityField.Click();
            CityField.SendKeys("CityTest");
            CountryField.Click();
            CountryField.SendKeys("CountryTest");
            StateDropDown.Click();
            DataOfStateDropDown.Click();
            TypeDropDown.Click();
            DataOfTypeDropDown.Click();
        }
        public void CilckOnSaveAddressButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_saveButtonAddressSection)));
            SaveButtonAddressSection.Click();
        }
        public void SelectRecordForEdit()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_fieldForEdit)));
            FieldForEdit.Click();
            FieldForEdit.Click();
        }
        public void FillWithoutRequiredField()
        {
            AddNewAddressButton.Click();
            StreetField.Click();
            StreetField.SendKeys("123 Test");
        }
        public void MakeChanges()
        {
            FieldForEdit.Click();
            FieldForEdit.SendKeys("Test");
        }
        public void DeleteRequiredField()
        {
            StreetField.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_fieldForEdit)));
            FieldForEdit.Clear();
        }
        public void DeleteRecordFormAddressSection()
        {
            Actions.MoveToElement(DeleteIconAddressSection).Click().Build().Perform();
            ConfirmButtonForDeleting.Click();
        }

        /// Employments
        public void ClickOnAddNewEmploymentButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addNewEmploymentButton)));
            Actions.MoveToElement(AddNewEmploymentButton).Click().Build().Perform();
            AddNewEmploymentButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_companyField)));
        }
        public void FillAllFieldForAddingNewEmployment()
        {
            CompanyField.Click();
            CompanyField.SendKeys("CompanyTest");
            PositionField.Click();
            PositionField.SendKeys("PositionTest");
            TypeOfEmploymentDropDown.Click();
            FullTimeRecordOfTypeDropDown.Click();
            YrsOfEmploymentField.Click();
            YrsOfEmploymentField.SendKeys("3");
            MoOfEmploymentField.Click();
            MoOfEmploymentField.SendKeys("23");
            PhomeField.Click();
            PhomeField.SendKeys("123456789");
            StreetOfEmploymentField.Click();
            StreetOfEmploymentField.SendKeys("StreetTest");
            UnitOfEmploymentField.Click();
            UnitOfEmploymentField.SendKeys("1234");
            CityOfEmploymentField.Click();
            CityOfEmploymentField.SendKeys("CityTest");
            StateOfEmploymentDropDown.Click();
            DataOfStateDropDown.Click();
            ZipOfEmploymentField.Click();
            ZipOfEmploymentField.SendKeys("12345");
        }
        public void CilckOnSaveEmploymentButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonEmploymentSection)));
            Actions.MoveToElement(SaveButtonEmploymentSection).Click().Build().Perform();
            SaveButtonEmploymentSection.Click();
        }
        public void FillWithoutRequiredFieldsEmploymentSection()
        {
            MoOfEmploymentField.Click();
            MoOfEmploymentField.SendKeys("23");
            PhomeField.Click();
            PhomeField.SendKeys("123456789");
            StreetOfEmploymentField.Click();
            StreetOfEmploymentField.SendKeys("StreetTest");
            UnitOfEmploymentField.Click();
            UnitOfEmploymentField.SendKeys("1234");
            CityOfEmploymentField.Click();
            CityOfEmploymentField.SendKeys("CityTest");
            StateOfEmploymentDropDown.Click();
            DataOfStateDropDown.Click();
            ZipOfEmploymentField.Click();
            ZipOfEmploymentField.SendKeys("12345");
        }
        public void SelectRecordForEditEmploymentSection()
        {
            Actions.DoubleClick(FieldForEditEmploumentSection).Click().Build().Perform();
        }
        public void MakeChangesForEmploymentSection()
        {
            CompanyField.Click();
            CompanyField.Clear();
            CompanyField.SendKeys("CompanyTest");
            CompanyField.SendKeys(Keys.Enter);
        }
        public void RemoveRequiredFieldForEmploymentSection()
        {
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Backspace);
            CompanyField.SendKeys(Keys.Enter);
        }
        public void DeleteRecordFormEmploymentSection()
        {
            Actions.MoveToElement(RecordForDelete).Click().Build().Perform();
            Actions.MoveToElement(DeleteIconEmploymentSection).Click().Build().Perform();
            ConfirmButtonForDeleting.Click();
        }

        /// Other Incomes 
        public void ClickOnAddNewOtherIncomeButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addNewOtherIncomeButton)));
            Actions.MoveToElement(AddNewOtherIncomeButton).Click().Build().Perform();
            AddNewOtherIncomeButton.Click();
        }
        public void FillAllFieldForAddingNewOtherIncome()
        {
            CurrentOtherIncomeCheckBox.Click();
            MonthlyAmountField.Click();
            MonthlyAmountField.SendKeys("100");
            YrsOfOtherIncomesField.Click();
            YrsOfOtherIncomesField.SendKeys("1999");
            MoOfOtherIncomesField.Click();
            MoOfOtherIncomesField.SendKeys("9");
        }
        public void FillwithoutRequiredFieldForAddingNewOtherIncome()
        {
            CurrentOtherIncomeCheckBox.Click();
        }
        public void CilckOnSaveOtherIncomeButton()
        {
            SaveButtonEmploymentSection.Click();
        }
        public void SelectRecordForEditOtherIncomeSection()
        {
            Actions.DoubleClick(FieldForEditOtherIncomesSection).Click().Build().Perform();
        }
        public void MakeChangesForOtherIncomeSection()
        {
            MonthlyAmountField.Click();
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys(Keys.Backspace);
            MonthlyAmountField.SendKeys("323");
        }
        public void RemoveRequiredFieldForOtherIncomeSection()
        {
            MonthlyAmountField.Click();
            for (int i = 0; i < 9; ++i)
            {
                MonthlyAmountField.SendKeys(Keys.Backspace);
            }
        }
        public void DeleteRecordFormOtherIncomesSection()
        {
            Actions.MoveToElement(FieldForEditOtherIncomesSection).Click().Build().Perform();
            Actions.MoveToElement(DeleteIconEmploymentSection).Click().Build().Perform();
            ConfirmButtonForDeleting.Click();
        }

        /// Reference
        public void ClickOnAddNewReferenceButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addNewReferenceButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_addNewReferenceButton)));
            AddNewReferenceButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_fullNameField)));
        }
        public void FillAllFieldForAddingNewReference()
        {
            FullNameField.Click();
            FullNameField.SendKeys("NameTest");
            PhomeOfReferenceField.Click();
            PhomeOfReferenceField.SendKeys("123456789");
            EmailAddressField.Click();
            EmailAddressField.SendKeys("Test@Test.com");
            AddressField.Click();
            AddressField.SendKeys("AddressTest");
            CityOfReferenceField.Click();
            CityOfReferenceField.SendKeys("CityTest");
            StateOfReferenceDropDown.Click();
            DataOfStateDropDown.Click();
            ZipOfReferenceField.Click();
            ZipOfReferenceField.SendKeys("12345");
            TypeOfReferenceDropDown.Click();
            DataOfReferenceDropDown.Click();
            RelationshipField.Click();
            RelationshipField.SendKeys("RelationshpTest");
        }
        public void FillwithoutReuiredFieldForAddingNewReference()
        {
            FullNameField.Click();
            FullNameField.SendKeys("NameTest");
            EmailAddressField.Click();
            EmailAddressField.SendKeys("Test@Test.com");
            AddressField.Click();
            AddressField.SendKeys("AddressTest");
            CityOfReferenceField.Click();
            CityOfReferenceField.SendKeys("CityTest");
            StateOfReferenceDropDown.Click();
            DataOfStateDropDown.Click();
            ZipOfReferenceField.Click();
            ZipOfReferenceField.SendKeys("12345");
            TypeOfReferenceDropDown.Click();
            DataOfReferenceDropDown.Click();
            RelationshipField.Click();
            RelationshipField.SendKeys("RelationshpTest");
        }
        public void SelectRecordForEditReferenceSection()
        {
            Actions.DoubleClick(FieldForEditReferenceSection).Click().Build().Perform();
        }
        public void MakeChangesForReferenceSection()
        {
            RecordForEditField.Click();
            for (int i = 0; i < 9; ++i)
            {
                RecordForEditField.SendKeys(Keys.Backspace);
            }
            RecordForEditField.SendKeys("987654321");
        }
        public void RemoveRequiredFieldForReferenceSection()
        {
            RecordForEditField.Click();
            for (int i = 0; i < 9; ++i)
            {
                RecordForEditField.SendKeys(Keys.Backspace);
            }
        }
        public void DeleteRecordFormReferenceSection()
        {
            Actions.MoveToElement(DeleteIconEmploymentSection).Click().Build().Perform();
            ConfirmButtonForDeleting.Click();
        }

        /// Co-Aplicant 
        public void ClickOnAddCoaplicantButton()
        {
            AddCoAplicantButton.Click();
        }
        public void VerifyCoAplicantPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_saveButtonCoAplicantPopUp)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewAddressCoAplicantPopUp)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewEmploymentCoAplicantPopUp)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewOtherIncomeCoAplicantPopUp)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewReferenceCoAplicantPopUp)));
        }
        public void FillAllRequiredFieldForCoAplicant()
        {
            RelationshipTypeDropDown.Click();
            DataOfRelationshipType.Click();
            FirstNameFieldCoAplicantPopUp.Click();
            FirstNameFieldCoAplicantPopUp.SendKeys("TestLB");
            LastNameFieldCoAplicantPopUp.Click();
            LastNameFieldCoAplicantPopUp.SendKeys("StringLB");
            HomePhoneFieldCoAplicantPopUp.Click();
            HomePhoneFieldCoAplicantPopUp.SendKeys("9889889988");
            WorkPhoneFieldCoAplicantPopUp.Click();
            WorkPhoneFieldCoAplicantPopUp.SendKeys("9779778778");
            CellPhoneFieldCoAplicantPopUp.Click();
            CellPhoneFieldCoAplicantPopUp.SendKeys("9797878787");
        }
        public void CilckOnSaveButtonCoAplicant()
        {
            SaveButtonCoAplicantPopUp.Click();
        }
        public void FillallDataWithoutFirstNameForCoAplicant()
        {
            RelationshipTypeDropDown.Click();
            DataOfRelationshipType.Click();
            LastNameFieldCoAplicantPopUp.Click();
            LastNameFieldCoAplicantPopUp.SendKeys("StringLB");
            HomePhoneFieldCoAplicantPopUp.Click();
            HomePhoneFieldCoAplicantPopUp.SendKeys("9889889988");
            WorkPhoneFieldCoAplicantPopUp.Click();
            WorkPhoneFieldCoAplicantPopUp.SendKeys("9779778778");
            CellPhoneFieldCoAplicantPopUp.Click();
            CellPhoneFieldCoAplicantPopUp.SendKeys("9797878787");
        }
        public void SelectRecordForEditCoaplicant()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_recordCoAplicantForEdit)));
            RecordCoAplicantForEdit.Click();
        }
        public void MakeSomeForEditCoaplicant()
        {
            FirstNameFieldCoAplicantPopUp.Click();
            for (int i = 0; i < 9; ++i)
            {
                FirstNameFieldCoAplicantPopUp.SendKeys(Keys.Backspace);
            }
            FirstNameFieldCoAplicantPopUp.SendKeys("TestLb");
        }
        public void RemoveRequiredFieldForCoaplicant()
        {
            FirstNameFieldCoAplicantPopUp.Click();
            for (int i = 0; i < 9; ++i)
            {
                FirstNameFieldCoAplicantPopUp.SendKeys(Keys.Backspace);
            }
        }
        public void DeleteRecordFormCoApplicantSection()
        {
            Actions.MoveToElement(RenoveButtonCoApplicantSection).Click().Build().Perform();
            ConfirmButtonForDeleting.Click();
        }
        public void VerifyContactUsersSection()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_leadCommentField)));
            LeadCommentField.Click();
            LeadCommentField.SendKeys("TestLb");
        }
        public void ClickOnAddCommentButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_addCommentButton)));
            AddCommentButton.Click();
        }
        #endregion

          #region Asset Tab
        public void NavigateToAssetsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_assetTab)));
            AssetTab.Click();
        }
        public void VerifyAssetTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addAssetButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_headerOfAssetTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetDropDown)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetColumn)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_lienColumn)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_valuationColumn)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_registrationColumn)));
        }
        public void FillAllRequiredFieldForCreateAsset()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addAssetButton)));
            AddAssetButton.Click();
            OdometerField.Click();
            OdometerField.Clear();
            OdometerField.SendKeys("1000");
            VINField.Click();
            VINField.SendKeys("1000");
            YearDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfYearDropDown)));
            RecordOfYearDropDown.Click();
            RecordOfYearDropDown.SendKeys(Keys.Enter);
            Actions.MoveToElement(MakeDropDown).Click().Build().Perform();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfMakeDropDown)));
            RecordOfMakeDropDown.Click();
            RecordOfMakeDropDown.SendKeys(Keys.Enter);
            LienHolderDropDown.Click();
            LienHolderDropDown.SendKeys("Test");
            LienHolderDropDown.SendKeys(Keys.Up);
            LienHolderDropDown.SendKeys(Keys.Enter);
            AccountNumberField.Click();
            AccountNumberField.SendKeys("1000");
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_modelDropDown)));
            ModelDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_recordOfModelDropDown)));
            RecordOfModelDropDown.Click();
            RecordOfModelDropDown.SendKeys(Keys.Enter);
            LienHolderDropDown.Click();
            LienHolderDropDown.SendKeys("Test");
            LienHolderDropDown.SendKeys(Keys.Up);
            LienHolderDropDown.SendKeys(Keys.Enter);
        }
        public void ClickOnSaveAssetButton()
        {
            SeveAssetButton.Click();
        }
        public void FillWithoutLienHolderRequiredField()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addAssetButton)));
            AddAssetButton.Click();
            OdometerField.Click();
            OdometerField.Clear();
            OdometerField.SendKeys("1000");
            VINField.Click();
            VINField.SendKeys("1000");
            YearDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfYearDropDown)));
            RecordOfYearDropDown.Click();
            RecordOfYearDropDown.SendKeys(Keys.Enter);
            Actions.MoveToElement(MakeDropDown).Click().Build().Perform();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfMakeDropDown)));
            RecordOfMakeDropDown.Click();
            RecordOfMakeDropDown.SendKeys(Keys.Enter);
            LienHolderDropDown.Click();
            LienHolderDropDown.SendKeys("Test");
            LienHolderDropDown.SendKeys(Keys.Up);
            LienHolderDropDown.SendKeys(Keys.Enter);
            AccountNumberField.Click();
            AccountNumberField.SendKeys("1000");
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_modelDropDown)));
            ModelDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_recordOfModelDropDown)));
            RecordOfModelDropDown.Click();
            RecordOfModelDropDown.SendKeys(Keys.Enter);

        }
        public void VerifyRequiredHintOfAssetTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_requiredHintOfAssetTab)));
        }
        public void MakeSoneChengesForAssetTab()
        {
            OdometerField.Click();
            for (int i = 0; i < 10; i++)
            {
                OdometerField.SendKeys(Keys.Backspace);
            }
            OdometerField.SendKeys("10000");
        }
        public void SelectRecordForEditOfAssetTab()
        {
            AssetDropDown.Click();
            RecordOfAssetDropDownForEdit.Click();
        }
        public void VerifyRequiredHintOfAssetTabForOdmeterField()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_requiredHintOfAssetTabForOdmeterField)));
        }
        public void RemoveOdmeterRequiredField()
        {
            OdometerField.Click();
            for (int i = 0; i < 10; i++)
            {
                OdometerField.SendKeys(Keys.Backspace);
            }
        }
        #endregion

          #region Leads Tab
        public void NavigateToLeadsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_leadsTab)));
            LeadsTab.Click();
        }
        public void VerifyLeadsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewLeadButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_headerOfAssetTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_leadsTable)));
        }
        public void ClickOnAddNewLeadButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewLeadButton)));
            AddNewLeadButton.Click();

        }
        public void ClickOnAddNewLeadButtonOfLeadTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addNewLeadButton)));
            AddNewLeadButton.Click();
            CancelButton.Click();
            AddNewLeadButton.Click();
        }
        public void VerifyAddNewLeadPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetDropDownOfLeadTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_secondarySourceDropDownOfLeadTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_saveButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_cancelButton)));
        }
        public void FillAllRequiredDataForCreateNewLead()
        {
            //Thread.Sleep(3000);
            AssetDropDownOfLeadTab.Click();
            RecordOfAssetDropDownAddNewPopUp.Click();
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_secondarySourceDropDownOfLeadTab)));
            SecondarySourceDropDownOfLeadTab.Click();
            Actions.MoveToElement(RecordOfSecondarySourceDropDownOfLeadTab).Click().Build().Perform();
            //RecordOfSecondarySourceDropDownOfLeadTab.Click();
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_assetDropDownOfLeadTab)));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfAssetDropDownAddNewPopUp)));

        }
        public void ClickOnSaveLeadButton()
        {
            SaveButtonOfLeadTab.Click();
        }
        public void FillDatawithoutRequiredAssetField()
        {
            SecondarySourceDropDownOfLeadTab.Click();
            Actions.MoveToElement(RecordOfSecondarySourceDropDownOfLeadTab).Click().Build().Perform();
        }
        public void VerifyRequiredHintOfLeadTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_requiredHintOfLeadTabForAssetDropDown)));
        }
        #endregion

        #region Fiels Tab
        public void NavigateToFilesTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_filesTab)));
            FilesTab.Click();
        }
        public void VerifyFilesTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_downloadAllButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_uploadButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetDropDownOfFielsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_tableFiles)));
        }
        public void SelectRecordInAssetDropDown()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_assetDropDownOfFielsTab)));
            AssetDropDownOfFielsTab.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfAssetDropDownForFilesTab)));
            RecordOfAssetDropDownForFilesTab.Click();
        }
        public void VerifyFilesTable()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_recordFilesTable)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_selectDealDropDown)));
        }
        public void ChangeTypeInSelectedFile()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_typeDropDownOfFielTable)));
            TypeDropDownOfFielTable.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordOfTypeDropDown)));
            RecordOfTypeDropDown.Click();
        }
        public void VerifyChangesFilesTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_typeDropDownOfFielTable)));
            TypeDropDownOfFielTable.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_recordForEditOfTypeDropDown)));
            RecordForEditOfTypeDropDown.Click();
        }
        public void ClickOnFileName()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fileName)));
            FileName.Click();
        }
        public void VerifySTIPSReviewPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_openInNewWondowIcon)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_downloanIcon)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fileOfSelectedFileName)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_pendingRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_approveRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_approveConditionRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_denyConditionRadioButton)));
        }
        public void ChangeStatusOfSTIPS()
        {
            Actions.MoveToElement(PendingRadioButton).Click().Build().Perform();
            SaveButton.Click();
        }
        public void VerifyChangesSTIPSReviewPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
            Thread.Sleep(3000);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_approveRadioButton)));
            ApproveRadioButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButton)));
            SaveButton.Click();
        }
        public void ClickOnOpenInNewWindowButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_openInNewWondowIcon)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_downloanIcon)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fileOfSelectedFileName)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_pendingRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_approveRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_approveConditionRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_denyConditionRadioButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_openInNewWondowIcon)));
            OpenInNewWondowIcon.Click();
        }
        public void VerifyIfNewTabIsOpened()
        {
            SwitchTab();
        }
        #endregion
        #endregion
    }
}
