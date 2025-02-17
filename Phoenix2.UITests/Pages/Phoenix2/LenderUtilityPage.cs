using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Phoenix2.UITests.Pages.Phoenix2
{
    class LenderUtilityPage : BaseDriver
    {

        #region driver
        public LenderUtilityPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "Phoenix 2.0";
        protected override string PageUrl => "https://qa-api-v2.ilendingdirect.com/tools/lender-components?lenderId=create&tab=0";
        #endregion

        #region PATH
        private string _addNewLenderButton = "//button[contains(text(), 'Add New Lender')]";
        private string _codeField = "code";
        private string _nameField = "name";
        private string _addressField = "address";
        private string _cityField = "city";
        private string _stateDropDown = "mui-component-select-state";
        private string _aKDataOfStateDropDown = "//*[@data-value='AK']";
        private string _zipField = "postCode";
        private string _kBBRetaliCheckbox = "//*[@name='KBB Retail']";
        private string _maxMileageField = "generalInfo.maxMileageGreen";
        private string _maxAgeField = "generalInfo.maxAgeGreen";
        private string _minPrimaryFICOField = "generalInfo.minPrimaryFicoGreen";
        private string _experianDefaultScoreDropDown = "mui-component-select-generalInfo.experianDefaultScore";
        private string _expV2DataOfExperianDefaultScoreDropDown = "//*[@data-value='ExpV2']";
        private string _primaryBureauDropDown = "mui-component-select-generalInfo.primaryBureau";
        private string _eqfDataOfPrimaryBureauDropDown = "//*[@data-value='Eqf']";
        private string _frontEndCheckBoxLTVType = "//*[@name='Front End']";
        private string _saveButton = "//*[text()='Save']";
        private string _popupCreatedSuccessfully = "//*[@role='alert']";
        private string _lendershouldbeuniquePopup = "notistack-snackbar";
        private string _codeIsRequiredwarningmessage = "code-helper-text";
        private string _lenderDropDown = "//main/div[2]//div[2]";
        private string _lenderFromLenderDropDown = "//*[@id='menu-']/div[3]/ul/li[6]";
        private string _savedSuccessfullypopup = "//*[text()='General - Saved Successfully']";
        private string _addressFieldIsRequiredWarningMessage = "address-helper-text";
        /// Rate Cards
        private string _rateCardsTab = "//*[text()='Rate Cards']";
        private string _fromDateDropDown = "//div[2]/div/div[2]/div[2]/div/div/div/div/div[1]/div";
        private string _toDateDropDown = "//div[2]/div/div[2]/div[2]/div/div/div/div/div[2]/div";
        private string _cardCreatedSuccessfully = "notistack-snackbar";
        private string _addNewTierButton = "//*[text()='Add New Tier']";
        private string _tierLableField = "//div[@data-field='tierLabel']//div//input[@type='text']";
        private string _tierDescriptionField = "//div[@data-field='tierDescription']//div//input[@type='text']";
        private string _minFicoField = "//div[@data-field='minFico']//div//input[@type='number']";
        private string _maxFicoField = "//div[@data-field='maxFico']//div//input[@type='number']";
        private string _saveTierBtn = "//button[normalize-space()='Save']";
        private string _tierSuccesPopup = "//div[@id='notistack-snackbar']";
        private string _deleteIconCard = "(//*[normalize-space(text()) and normalize-space(.)='—'])[1]/following::*[name()='svg'][2]";
        private string _recordInCards = "(//div[@class='sc-bjuIDw cifnIi'])[1]";
        private string _confirmButtonForDeleting = "//button[normalize-space()='Confirm']";
        private string _deletedSuccessfullyPopup = "//*[text()='Card - Deleted Successfully']";
        private string _editIconCards = "(//*[@data-action='edit-row'])[1]";
        private string _dataForFromField = "//*[@data-field='fromDate']//*[@type='date']";
        private string _updateedSuccessfullyPopup = "//*[text()='Card - Updated Successfully']";
        private string _recordInTier = "(//div[@class='sc-bjuIDw cifnIi'])[6]";
        private string _editIconTiers = "(//*[@data-action='edit-row'])[6]";
        private string _updatedSuccessfullyPopup = "//div[contains(., 'Updated Successfully')]";
        private string _deleteIconTier = "(//*[@d='M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16'])[6]";
        private string _tierDeletedSuccessfullyPopup = "//*[text()='Tier - Deleted Successfully']";
        private string _addNewConditionButton = "//button[contains(text(), 'Add New Condition')]";
        private string _rateField = "//*[@data-field='rate']//input[@aria-invalid='false']";
        private string _rateFieldForEditing = "(//*[@data-field='rate' and @aria-colspan='1'])[1]";
        private string _teamGroupField = "//*[@data-field='termGroup']//input[@aria-invalid='false']";
        private string _maxFlatFreeField = "//*[@data-field='maxFlatFeePercent']//input[@aria-invalid='false']";
        private string _minTotalAmountFinanceGreeenField = "//*[@data-field='minTotalAmountFinanceGreen']//input[@aria-invalid='false']";
        private string _minTotalAmountFinanceYellowField = "//*[@data-field='minTotalAmountFinanceYellow']//input[@aria-invalid='false']";
        private string _maxLtvGreenField = "//*[@data-field='maxLtvGreen']//input[@aria-invalid='false']";
        private string _maxLtvYellowField = "//*[@data-field='maxLtvYellow']//input[@aria-invalid='false']";
        private string _maxMarkupField = "//*[@data-field='maxMarkup']//input[@aria-invalid='false']";
        private string _maxAllInLtvField = "//*[@data-field='maxAllInLtv']//input[@aria-invalid='false']";
        private string _maxDtiField = "//*[@data-field='maxDti']//input[@aria-invalid='false']";
        private string _maxPtiField = "//*[@data-field='maxPti']//input[@aria-invalid='false']";
        private string _maxFlatGreenField = "//*[@data-field='maxFlatGreen']//input[@aria-invalid='false']";
        private string _saveButtonConditions = "//button[contains(text(), 'Save')]";
        private string _conditionCreatedSuccessfullyPopup = "//*[text()='Condition - Created Successfully']";
        private string _recordInConditions = "(//*[@role='grid']//*[@data-rowindex='0'])[1]";
        private string _editInonConditions = "(//*[@data-action='edit-row'])[10]";
        private string _conditionUpdatedSuccessfullyPopup = "//*[text()='Condition - Updated Successfully']";
        /// Incs and Excs
        private string _incsAndExcsTab = "//*[text()='Incs and Excs']";
        private string _excludedStatesBlock = "//*[text()='Excluded States']";
        private string _includedZipCodesBlock = "//*[@name='includedZipCodes']";
        private string _includedContactIDsBlock = "//*[@name='includedContactIds']";
        private string _incsAndExcsSuccessfullyPopup = "//*[text()='Incs and Excs - Updated Successfully']";
        private string _warningMessageForIncsAndExcsTab = "//*[text()='Please provide valid zip codes separated by coma']";
        private string _stateCodeCheckBox = "//*[contains(@aria-label,'all rows')]";
        /// Assets
        private string _assetsTab = "//*[text()='Assets']";
        private string _lenderWithDataForAsset = "//*[@id='menu-']/div[3]/ul/li[8]";
        private string _assetTypeNameCheckBox = "//*[contains(@aria-label,'all rows')]";
        private string _assetSuccessfullyPopup = "//*[text()='Assets - Updated Successfully']";
        /// Doc Fees
        private string _docFeesTab = "//button[contains(text(),'Doc Fees')]";
        private string _addNewDocFeeButton = "//button[contains(text(),'Add New Doc Fee')]";
        private string _addNewAdditionalDocFeeButton = "//button[contains(text(),'Add New Additional Doc Fee')]";
        private string _stateDocFeesDropdown = "//em[contains(text(),'None')]";
        private string _aLStateData = "//*[@data-value='AL']";
        private string _amountField = "//*[@data-field='amount']//input[@aria-invalid='false']";
        private string _categoryField = "//*[@data-field='category']//input[@aria-invalid='false']";
        private string _descriptionField = "//*[@data-field='description']//input[@aria-invalid='false']";
        private string _isDocFeeCheckBox = "//*[@data-testid='CheckBoxOutlineBlankIcon']/../input";
        private string _docFeeSuccessfullyPopUp = "//*[text()='DocFee - Created Successfully']";
        private string _docFeeWarningPopUp = "//*[contains(text(),'Something went wrong. ')]";
        private string _recordInDocFeesTable = "//*[@data-rowindex='0']";
        private string _editIconForDocFeesTable = "(//*[@data-action='edit-row'])[1]";
        private string _docFeeUpdatedPopUp = "//*[text()='DocFee - Updated Successfully']";
        private string _deleteIconForDocFeesTable = "//*[@d='M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16'][1]";
        private string _docFeeDeletePopUp = "//*[text()='DocFee - Deleted Successfully']";
        private string _categoryFieldAdditionalTbl = "//*[@data-field='category']//input[@aria-invalid='false']";
        private string _descriptionFieldAdditionalTbl = "//*[@data-field='description']//input[@aria-invalid='false']";
        private string _amountFieldAdditionalTbl = "//*[@data-field='amount']//input[@aria-invalid='false']";
        private string _minFicoFieldAdditionalTbl = "//*[@data-field='minFico']//input[@aria-invalid='false']";
        private string _maxFicoFieldAdditionalTbl = "//*[@data-field='maxFico']//input[@aria-invalid='false']";
        private string _isCurrentCheckBox = "(//*[@data-testid='CheckBoxOutlineBlankIcon']/../input)[1]";
        private string _isIncludedCheckBox = "(//*[@data-testid='CheckBoxOutlineBlankIcon']/../input)[2]";
        private string _isDocFeeCheckBoxAdditionalTbl = "(//*[@data-testid='CheckBoxOutlineBlankIcon']/../input)[3]";
        private string _additionalDocFeeSuccessfullyPopUp = "//*[text()='Additional Doc Fee - Created Successfully']";
        private string _recordInAdditionalDocFeesTable = "(//*[@data-field='createdDate'])[2]";
        private string _editIconForAdditionalDocFeesTable = "(//*[@data-action='edit-row'])[6]";
        private string _additionalDocFeeUpdatedPopUp = "//*[text()='Additional Doc Fee - Updated Successfully']";
        private string _additionalDocFeeDeletePopUp = "//*[text()='Additional Doc Fee - Deleted Successfully']";
        private string _deleteIconForAdditionalDocFeesTable = "//*[@d='M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16'][1]";
        /// Excluded Products
        private string _excludedProductsTab = "//button[contains(text(),'Excluded Products')]";
        private string _addNewExcludedProductButton = "//button[contains(text(),'Add New Excluded Product')]";
        private string _checkBoxForExcludedProducts = "//*[@data-testid='CheckBoxIcon']/../input";
        private string _productTypeNameDropDown = "//em[contains(text(),'None')]";
        private string _nameProductFromDropDown = "//*[@data-value='Gap']";
        private string _excludedProductsSuccessfulyPopUp = "//*[text()='Excluded Products - Updated Successfully']";
        private string _recordInExcludedProductTable = "(//*[@data-field='createdDate'])[2]";
        private string _editIconExcludedProductTable = "(//*[@data-action='edit-row'])[1]";
        private string _excludedProductUpdatedPopUp = "//*[text()='Excluded Products - Updated Successfully']";
        private string _deleteIconForExcludedProductTable = "//*[@d='M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16'][1]";
        /// Credit Rules
        private string _creditRulesTab = "//button[contains(text(),'Credit Rules')]";
        private string _addNewCreditRuleButton = "//button[contains(text(),'Add New Credit Rule')]";
        private string _creditRuleTypeDropdown = "(//*[@aria-haspopup='listbox']//em[contains(text(),'None')])[1]";
        private string _dataOfCreditRuleTypeDropdown = "//*[@role='listbox']//li[2]";
        private string _conditionDropdown = "(//em[contains(text(),'None')])[2]";
        private string _dataOfConditionDropdown = "//*[@data-value='Less']";
        private string _valueField = "//*[@data-field='value']//input[@aria-invalid='false']";
        private string _yellowValueField = "//*[@data-field='yellowValue']//input[@aria-invalid='false']";
        private string _creditRuleSuccessfulyPopUp = "//*[text()='CreditRule - Created Successfully']";
        private string _recordInCreditRuleTable = "(//*[@data-field='createdDate'])[2]";
        private string _editIconCreditRuleTable = "(//*[@data-action='edit-row'])[1]";
        private string _creditRuleUpdatedPopUp = "//*[text()='CreditRule - Updated Successfully']";
        private string _deleteIconForCreditRuleTable = "//*[@d='M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16'][1]";
        private string _creditRuleDeletePopUp = "//*[text()='CreditRule - Deleted Successfully']";
        /// Formulas
        private string _formulasTab = "//button[contains(text(),'Formulas')]";
        private string _addNewFormulaButton = "//button[contains(text(),'Add New Formula')]";
        private string _formulaNameDropdown = "(//div[@aria-expanded='false'])[2]";
        private string _dataOfFormulaNameDropdown = "//*[@data-value='FrontEnd']";
        private string _formulaExpressionField = "//*[@aria-invalid='true']";
        private string _formulaSuccessfulyPopUp = "//*[text()='Formula - Created Successfully']";
        private string _recordInFormulasTable = "(//*[@data-field='options'])[2]";
        private string _editIconFormulasTable = "(//*[@data-action='edit-row'])[1]";
        private string _formulaExpressionFieldForEdit = "//*[@data-field='formulaValue']//*[@aria-invalid='false']";
        private string _formulaUpdatedPopUp = "//*[text()='Formula - Updated Successfully']";
        private string _deleteIconForFormulaTable = "//div[@class='sc-eVQfli gogzNX MuiDataGrid-virtualScrollerRenderZone']//div[1]//div[1]//button[2]";
        private string _formulaDeletePopUp = "//*[text()='Formula - Deleted Successfully']";
        #endregion

        #region ELEMENT
        /// General
        private IWebElement AddNewLenderBtn => FindElementByXpath(_addNewLenderButton);
        private IWebElement CodeField => FindElementById(_codeField);
        private IWebElement NameField => FindElementById(_nameField);
        private IWebElement AddressField => FindElementById(_addressField);
        private IWebElement CityField => FindElementById(_cityField);
        private IWebElement StateDropDown => FindElementById(_stateDropDown);
        private IWebElement AKDataOfStateDropDown => FindElementByXpath(_aKDataOfStateDropDown);
        private IWebElement ZipField => FindElementById(_zipField);
        private IWebElement KBBRetaliCheckbox => FindElementByXpath(_kBBRetaliCheckbox);
        private IWebElement MaxMileageField => FindElementById(_maxMileageField);
        private IWebElement MaxAgeField => FindElementById(_maxAgeField);
        private IWebElement MinPrimaryFICOField => FindElementById(_minPrimaryFICOField);
        private IWebElement ExperianDefaultScoreDropDown => FindElementById(_experianDefaultScoreDropDown);
        private IWebElement ExpV2DataOfExperianDefaultScoreDropDown => FindElementByXpath(_expV2DataOfExperianDefaultScoreDropDown);
        private IWebElement PrimaryBureauDropDown => FindElementById(_primaryBureauDropDown);
        private IWebElement EqfDataOfPrimaryBureauDropDown => FindElementByXpath(_eqfDataOfPrimaryBureauDropDown);
        private IWebElement FrontEndCheckBoxLTVType => FindElementByXpath(_frontEndCheckBoxLTVType);
        private IWebElement SaveButton => FindElementByXpath(_saveButton);
        private IWebElement LenderDropDown => FindElementByXpath(_lenderDropDown);
        private IWebElement LenderFromLenderDropDown => FindElementByXpath(_lenderFromLenderDropDown);
        /// Popup
        private IWebElement PopupCreatedSuccessfully => FindElementByXpath(_popupCreatedSuccessfully);
        private IWebElement LendershouldbeuniquePopup => FindElementById(_lendershouldbeuniquePopup);
        private IWebElement CodeIsRequiredwarningmessage => FindElementById(_codeIsRequiredwarningmessage);
        private IWebElement SavedSuccessfullypopup => FindElementByXpath(_savedSuccessfullypopup);
        private IWebElement AddressFieldIsRequiredWarningMessage => FindElementById(_addressFieldIsRequiredWarningMessage);
        /// Popup for Rate Cards
        private IWebElement CardCreatedSuccessfully => FindElementById(_cardCreatedSuccessfully);
        private IWebElement DeletedSuccessfullyPopup => FindElementById(_deletedSuccessfullyPopup);
        private IWebElement UpdatedSuccessfullyPopup => FindElementById(_updatedSuccessfullyPopup);
        private IWebElement TierDeletedSuccessfullyPopup => FindElementById(_tierDeletedSuccessfullyPopup);
        private IWebElement ConditionCreatedSuccessfullyPopup => FindElementByXpath(_conditionCreatedSuccessfullyPopup);
        private IWebElement ConditionUpdatedSuccessfullyPopup => FindElementByXpath(_conditionUpdatedSuccessfullyPopup);
        /// Rate Cards
        private IWebElement RateCardsTab => FindElementByXpath(_rateCardsTab);
        private IWebElement FromDateDropDown => FindElementByXpath(_fromDateDropDown);
        private IWebElement ToDateDropDown => FindElementByXpath(_toDateDropDown);
        private IWebElement AddNewTierButton => FindElementByXpath(_addNewTierButton);
        private IWebElement TierLableField => FindElementByXpath(_tierLableField);
        private IWebElement TierDescriptionField => FindElementByXpath(_tierDescriptionField);
        private IWebElement MinFicoField => FindElementByXpath(_minFicoField);
        private IWebElement MaxFicoField => FindElementByXpath(_maxFicoField);
        private IWebElement SaveTierButton => FindElementByXpath(_saveTierBtn);
        private IWebElement TierSuccessPopup => FindElementByXpath(_tierSuccesPopup);
        private IWebElement RecordInCards => FindElementByXpath(_recordInCards);
        private IWebElement DeleteIconCard => FindElementByXpath(_deleteIconCard);
        private IWebElement ConfirmButtonForDeleting => FindElementByXpath(_confirmButtonForDeleting);
        private IWebElement EditIconCards => FindElementByXpath(_editIconCards);
        private IWebElement DataForFromField => FindElementByXpath(_dataForFromField);
        private IWebElement UpdateedSuccessfullyPopup => FindElementByXpath(_updateedSuccessfullyPopup);
        private IWebElement RecordInTier => FindElementByXpath(_recordInTier);
        private IWebElement EditIconTiers => FindElementByXpath(_editIconTiers);
        private IWebElement DeleteIconTier => FindElementByXpath(_deleteIconTier);
        private IWebElement AddNewConditionButton => FindElementByXpath(_addNewConditionButton);
        private IWebElement RateField => FindElementByXpath(_rateField);
        private IWebElement TeamGroupField => FindElementByXpath(_teamGroupField);
        private IWebElement MaxFlatFreeField => FindElementByXpath(_maxFlatFreeField);
        private IWebElement MinTotalAmountFinanceGreeenField => FindElementByXpath(_minTotalAmountFinanceGreeenField);
        private IWebElement MinTotalAmountFinanceYellowField => FindElementByXpath(_minTotalAmountFinanceYellowField);
        private IWebElement MaxLtvGreenField => FindElementByXpath(_maxLtvGreenField);
        private IWebElement MaxLtvYellowField => FindElementByXpath(_maxLtvYellowField);
        private IWebElement MaxMarkupField => FindElementByXpath(_maxMarkupField);
        private IWebElement MaxAllInLtvField => FindElementByXpath(_maxAllInLtvField);
        private IWebElement MaxDtiField => FindElementByXpath(_maxDtiField);
        private IWebElement MaxPtiField => FindElementByXpath(_maxPtiField);
        private IWebElement MaxFlatGreenField => FindElementByXpath(_maxFlatGreenField);
        private IWebElement SaveButtonConditions => FindElementByXpath(_saveButtonConditions);
        private IWebElement RecordInConditions => FindElementByXpath(_recordInConditions);
        private IWebElement EditInonConditions => FindElementByXpath(_editInonConditions);
        private IWebElement RateFieldForEditing => FindElementByXpath(_rateFieldForEditing);
        /// Incs and Excs
        private IWebElement IncsAndExcsTab => FindElementByXpath(_incsAndExcsTab);
        private IWebElement ExcludedStatesBlock => FindElementByXpath(_excludedStatesBlock);
        private IWebElement IncludedZipCodesBlock => FindElementByXpath(_includedZipCodesBlock);
        private IWebElement IncludedContactIDsBlock => FindElementByXpath(_includedContactIDsBlock);
        private IWebElement StateCodeCheckBox => FindElementByXpath(_stateCodeCheckBox);
        /// Popup for Incs and Excs
        private IWebElement IncsAndExcsSuccessfullyPopup => FindElementByXpath(_incsAndExcsSuccessfullyPopup);
        private IWebElement WarningMessageForIncsAndExcsTab => FindElementByXpath(_warningMessageForIncsAndExcsTab);
        /// Assets
        private IWebElement AssetsTab => FindElementByXpath(_assetsTab);
        private IWebElement LenderWithDataForAsset => FindElementByXpath(_lenderWithDataForAsset);
        private IWebElement AssetTypeNameCheckBox => FindElementByXpath(_assetTypeNameCheckBox);
        private IWebElement AssetSuccessfullyPopup => FindElementByXpath(_assetSuccessfullyPopup);
        /// Doc Fees
        private IWebElement DocFeesTab => FindElementByXpath(_docFeesTab);
        private IWebElement AddNewDocFeeButton => FindElementByXpath(_addNewDocFeeButton);
        private IWebElement AddNewAdditionalDocFeeButton => FindElementByXpath(_addNewAdditionalDocFeeButton);
        private IWebElement StateDocFeesDropdown => FindElementByXpath(_stateDocFeesDropdown);
        private IWebElement ALStateData => FindElementByXpath(_aLStateData);
        private IWebElement AmountField => FindElementByXpath(_amountField);
        private IWebElement CategoryField => FindElementByXpath(_categoryField);
        private IWebElement DescriptionField => FindElementByXpath(_descriptionField);
        private IWebElement IsDocFeeCheckBox => FindElementByXpath(_isDocFeeCheckBox);
        private IWebElement DocFeeSuccessfullyPopUp => FindElementByXpath(_docFeeSuccessfullyPopUp);
        private IWebElement DocFeeWarningPopUp => FindElementByXpath(_docFeeWarningPopUp);
        private IWebElement RecordInDocFeesTable => FindElementByXpath(_recordInDocFeesTable);
        private IWebElement EditIconForDocFeesTable => FindElementByXpath(_editIconForDocFeesTable);
        private IWebElement DocFeeUpdatedPopUp => FindElementByXpath(_docFeeUpdatedPopUp);
        private IWebElement DeleteIconForDocFeesTable => FindElementByXpath(_deleteIconForDocFeesTable);
        private IWebElement DocFeeDeletePopUp => FindElementByXpath(_docFeeDeletePopUp);
        private IWebElement CategoryFieldAdditionalTbl => FindElementByXpath(_categoryFieldAdditionalTbl);
        private IWebElement DescriptionFieldAdditionalTbl => FindElementByXpath(_descriptionFieldAdditionalTbl);
        private IWebElement AmountFieldAdditionalTbl => FindElementByXpath(_amountFieldAdditionalTbl);
        private IWebElement MinFicoFieldAdditionalTbl => FindElementByXpath(_minFicoFieldAdditionalTbl);
        private IWebElement MaxFicoFieldAdditionalTbl => FindElementByXpath(_maxFicoFieldAdditionalTbl);
        private IWebElement IsIncludedCheckBox => FindElementByXpath(_isIncludedCheckBox);
        private IWebElement IsDocFeeCheckBoxAdditionalTbl => FindElementByXpath(_isDocFeeCheckBoxAdditionalTbl);
        private IWebElement IsCurrentCheckBox => FindElementByXpath(_isCurrentCheckBox);
        private IWebElement AdditionalDocFeeSuccessfullyPopUp => FindElementByXpath(_additionalDocFeeSuccessfullyPopUp);
        private IWebElement RecordInAdditionalDocFeesTable => FindElementByXpath(_recordInAdditionalDocFeesTable);
        private IWebElement EditIconForAdditionalDocFeesTable => FindElementByXpath(_editIconForAdditionalDocFeesTable);
        private IWebElement AdditionalDocFeeUpdatedPopUp => FindElementByXpath(_additionalDocFeeUpdatedPopUp);
        private IWebElement AdditionalDocFeeDeletePopUp => FindElementByXpath(_additionalDocFeeDeletePopUp);
        private IWebElement DeleteIconForAdditionalDocFeesTable => FindElementByXpath(_deleteIconForAdditionalDocFeesTable);
        /// Excluded Products
        private IWebElement ExcludedProductsTab => FindElementByXpath(_excludedProductsTab);
        private IWebElement AddNewExcludedProductButton => FindElementByXpath(_addNewExcludedProductButton);
        private IWebElement CheckBoxForExcludedProducts => FindElementByXpath(_checkBoxForExcludedProducts);
        private IWebElement ProductTypeNameDropDown => FindElementByXpath(_productTypeNameDropDown);
        private IWebElement NameProductFromDropDown => FindElementByXpath(_nameProductFromDropDown);
        private IWebElement ExcludedProductsSuccessfulyPopUp => FindElementByXpath(_excludedProductsSuccessfulyPopUp);
        private IWebElement RecordInExcludedProductTable => FindElementByXpath(_recordInExcludedProductTable);
        private IWebElement EditIconExcludedProductTable => FindElementByXpath(_editIconExcludedProductTable);
        private IWebElement ExcludedProductUpdatedPopUp => FindElementByXpath(_excludedProductUpdatedPopUp);
        private IWebElement DeleteIconForExcludedProductTable => FindElementByXpath(_deleteIconForExcludedProductTable);
        /// Credit Rules 
        private IWebElement CreditRulesTab => FindElementByXpath(_creditRulesTab);
        private IWebElement AddNewCreditRuleButton => FindElementByXpath(_addNewCreditRuleButton);
        private IWebElement CreditRuleTypeDropdown => FindElementByXpath(_creditRuleTypeDropdown);
        private IWebElement ConditionDropdown => FindElementByXpath(_conditionDropdown);
        private IWebElement DataOfCreditRuleTypeDropdown => FindElementByXpath(_dataOfCreditRuleTypeDropdown);
        private IWebElement DataOfConditionDropdown => FindElementByXpath(_dataOfConditionDropdown);
        private IWebElement ValueField => FindElementByXpath(_valueField);
        private IWebElement YellowValueField => FindElementByXpath(_yellowValueField);
        private IWebElement CreditRuleSuccessfulyPopUp => FindElementByXpath(_creditRuleSuccessfulyPopUp);
        private IWebElement RecordInCreditRuleTable => FindElementByXpath(_recordInCreditRuleTable);
        private IWebElement EditIconCreditRuleTable => FindElementByXpath(_editIconCreditRuleTable);
        private IWebElement CreditRuleUpdatedPopUp => FindElementByXpath(_creditRuleUpdatedPopUp);
        private IWebElement DeleteIconForCreditRuleTable => FindElementByXpath(_deleteIconForCreditRuleTable);
        private IWebElement CreditRuleDeletePopUp => FindElementByXpath(_creditRuleDeletePopUp);
        /// Formulas
        private IWebElement FormulasTab => FindElementByXpath(_formulasTab);
        private IWebElement AddNewFormulaButton => FindElementByXpath(_addNewFormulaButton);
        private IWebElement FormulaNameDropdown => FindElementByXpath(_formulaNameDropdown);
        private IWebElement DataOfFormulaNameDropdown => FindElementByXpath(_dataOfFormulaNameDropdown);
        private IWebElement FormulaExpressionField => FindElementByXpath(_formulaExpressionField);
        private IWebElement FormulaSuccessfulyPopUp => FindElementByXpath(_formulaSuccessfulyPopUp);
        private IWebElement RecordInFormulasTable => FindElementByXpath(_recordInFormulasTable);
        private IWebElement EditIconFormulasTable => FindElementByXpath(_editIconFormulasTable);
        private IWebElement FormulaUpdatedPopUp => FindElementByXpath(_formulaUpdatedPopUp);
        private IWebElement FormulaExpressionFieldForEdit => FindElementByXpath(_formulaExpressionFieldForEdit);
        private IWebElement DeleteIconForFormulaTable => FindElementByXpath(_deleteIconForFormulaTable);
        private IWebElement FormulaDeletePopUp => FindElementByXpath(_formulaDeletePopUp);
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
        /// General
        public void ClickAddNewLender()
        {
            AddNewLenderBtn.Click();

        }
        public void FillAllRequiredFields(string Data)
        {
            CodeField.SendKeys("string1");
            NameField.SendKeys("string");
            AddressField.SendKeys("string");
            CityField.SendKeys("string");
            ZipField.SendKeys("123456789");
            MaxMileageField.SendKeys("12");
            MaxAgeField.SendKeys("12");
            MinPrimaryFICOField.SendKeys("13");
        }
        public void FillWithoutRequiredField(string Data)
        {
            NameField.SendKeys("string");
            AddressField.SendKeys("string");
            CityField.SendKeys("string");
            ZipField.SendKeys("123456789");
            MaxMileageField.SendKeys("12");
            MaxAgeField.SendKeys("12");
            MinPrimaryFICOField.SendKeys("13");
        }
        public void EditData(string Data)
        {
            AddressField.Clear();
            AddressField.SendKeys(Data);
        }
        public void CleanData(string Data)
        {
            AddressField.Clear();
        }
        public void SelectDataFromDropdowns()
        {
            StateDropDown.Click();
            AKDataOfStateDropDown.Click();
            ExperianDefaultScoreDropDown.Click();
            ExpV2DataOfExperianDefaultScoreDropDown.Click();
            PrimaryBureauDropDown.Click();
            EqfDataOfPrimaryBureauDropDown.Click();
        }
        public void SelectDataFromLenderDropdown()
        {
            LenderDropDown.Click();
            LenderFromLenderDropDown.Click();

        }
        public void SelectLenderWithDataForAssetsTad()
        {
            LenderDropDown.Click();
            LenderWithDataForAsset.Click();

        }
        public void ClickOnCheckBoxs()
        {
            KBBRetaliCheckbox.Click();
            FrontEndCheckBoxLTVType.Click();
        }
        public void ClickSaveButton()
        {
            SaveButton.Click();

        }
        public void CheckLenderCreatedSuccessfullyPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_popupCreatedSuccessfully)));
        }
        public void CheckWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_lendershouldbeuniquePopup)));
        }
        public void CheckCodeIsRequiredwarningmessage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_codeIsRequiredwarningmessage)));
        }
        public void CheckSavedSuccessfullypopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_savedSuccessfullypopup)));
        }
        public void CheckAddressIsRequiredwarningmessage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_addressFieldIsRequiredWarningMessage)));
        }
        /// Rate Cards
        public void ClickOnRateCardsTab()
        {
            RateCardsTab.Click();
        }
        public void DeleteRecordInCardsTab()
        {
            RecordInCards.Click();
            DeleteIconCard.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void DeleteRecordInTiersTab()
        {
            RecordInTier.Click();
            DeleteIconTier.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void EditRecordInCardsTab()
        {
            RecordInCards.Click();
            EditIconCards.Click();
            FromDateDropDown.Click();
            DataForFromField.Clear();
            DataForFromField.SendKeys("12/12/2022");
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void EditRecordInTiersTab()
        {
            RecordInTier.Click();
            EditIconTiers.Click();
            MaxFicoField.Clear();
            MaxFicoField.SendKeys("4");
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void EditRecordInConditionTab()
        {
            RateFieldForEditing.Click();
            RateFieldForEditing.Click();
            RateFieldForEditing.SendKeys("1");
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ClickOnFromDateDropDown()
        {
            FromDateDropDown.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ClickToDateDropDownDropDown()
        {
            ToDateDropDown.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void CheckardCreatedSuccessfullypopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_cardCreatedSuccessfully)));
        }
        public void ClickOnAddNewTierButton()
        {
            AddNewTierButton.Click();
        }
        public void ClickOnAddNewConditionButton()
        {
            AddNewConditionButton.Click();
        }
        public void FillDataForTierFields()
        {
            TierLableField.SendKeys("string1");
            TierDescriptionField.SendKeys("string");
            MinFicoField.SendKeys("2");
            MaxFicoField.SendKeys("3");
        }
        public void FillDataForConditionFields()
        {
            RateField.SendKeys("11");
            TeamGroupField.SendKeys("12");
            MaxFlatFreeField.SendKeys("13");
            MinTotalAmountFinanceGreeenField.SendKeys("14");
            MinTotalAmountFinanceYellowField.SendKeys("15");
            MaxLtvGreenField.SendKeys("16");
            MaxLtvYellowField.SendKeys("17");
            MaxMarkupField.SendKeys("18");
            MaxAllInLtvField.SendKeys("19");
            MaxDtiField.SendKeys("20");
            MaxPtiField.SendKeys("21");
            MaxFlatGreenField.SendKeys("22");
        }
        public void ClickSaveTierBtn()
        {
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ClickSaveConditionBtn()
        {
            SaveButtonConditions.Click();
        }
        public void VerifyCreation()
        {
            TierSuccessPopup.Click();
        }
        public void VerifyDeleteCard()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_deletedSuccessfullyPopup)));
        }
        public void VerifyCreateCondition()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_conditionCreatedSuccessfullyPopup)));
        }
        public void VerifyEditCard()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_updateedSuccessfullyPopup)));
        }
        public void VerifyEditCondition()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_conditionUpdatedSuccessfullyPopup)));
        }
        public void VerifyEditTiers()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_updatedSuccessfullyPopup)));
        }
        public void VerifyDeleteTier()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_tierDeletedSuccessfullyPopup)));
        }
        /// Incs and Excs <summary>
        public void ClickOnIncsAndExcsTab()
        {
            IncsAndExcsTab.Click();
        }
        public void CheckIncsandExcsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_excludedStatesBlock)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_includedZipCodesBlock)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(_includedContactIDsBlock)));
        }
        public void FillInZip(string Zip)
        {
            IncludedZipCodesBlock.Click();
            IncludedZipCodesBlock.Clear();
            IncludedZipCodesBlock.SendKeys(Zip);
        }
        public void ChangeZip(string Zip)
        {
            IncludedZipCodesBlock.Click();
            IncludedZipCodesBlock.Clear();
            IncludedZipCodesBlock.SendKeys(Zip);
        }
        public void ChangeContact(string Contact)
        {
            IncludedContactIDsBlock.Clear();
            IncludedContactIDsBlock.Clear();
            IncludedContactIDsBlock.SendKeys(Contact);
        }
        public void FillInvalidZip()
        {
            IncludedZipCodesBlock.Click();
            IncludedZipCodesBlock.Clear();
            IncludedZipCodesBlock.SendKeys("555555");
        }
        public void ClickOnStateCodeCheckBox()
        {
            StateCodeCheckBox.Click();
        }
        public void VerifyAddIncsAndExcs()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_incsAndExcsSuccessfullyPopup)));
        }
        public void VerifyWarningMessageForAddIncsAndExcs()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_warningMessageForIncsAndExcsTab)));
        }
        /// Asset 
        public void ClickOnAssetsTab()
        {
            AssetsTab.Click();
        }
        public void ClickOnAssetTypeNameCheckBox()
        {
            AssetTypeNameCheckBox.Click();
        }
        public void VerifyEditsPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_assetSuccessfullyPopup)));
        }
        /// Doc Fees
        public void ClickOnDocFeesTab()
        {
            DocFeesTab.Click();
        }
        public void ClickOnAddNewDocFeeButton()
        {
            AddNewDocFeeButton.Click();
        }
        public void FillDataForDocFee()
        {
            StateDocFeesDropdown.Click();
            ALStateData.Click();
            AmountField.SendKeys("1");
            CategoryField.SendKeys("2");
            DescriptionField.SendKeys("3");
            IsDocFeeCheckBox.Click();
        }
        public void FillInvalidDataForDocFee()
        {
            AmountField.SendKeys("1");
        }
        public void EditRecordInDocFeeTable(string Description)
        {
            RecordInDocFeesTable.Click();
            EditIconForDocFeesTable.Click();
            DescriptionField.SendKeys(Description);
        }
        public void DeleteRecordInDocFees()
        {
            RecordInDocFeesTable.Click();
            DeleteIconForDocFeesTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void VerifyAddDocFeePopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_docFeeSuccessfullyPopUp)));
        }
        public void VerifyAddDocFeeWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_docFeeWarningPopUp)));
        }
        public void VerifyEditDocFeeWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_docFeeUpdatedPopUp)));
        }
        public void VerifyDeleteDocFeeWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_docFeeDeletePopUp)));
        }
        public void ClickOnAddNewAdditionalDocFeeButton()
        {
            AddNewAdditionalDocFeeButton.Click();
        }
        public void FillDataForAdditionalDocFee()
        {
            CategoryFieldAdditionalTbl.SendKeys("11");
            DescriptionFieldAdditionalTbl.SendKeys("22");
            AmountFieldAdditionalTbl.SendKeys("33");
            MinFicoFieldAdditionalTbl.SendKeys("3");
            MaxFicoFieldAdditionalTbl.SendKeys("5");
            IsDocFeeCheckBoxAdditionalTbl.Click();
        }
        public void VerifyAddAdditionalDocFeePopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_additionalDocFeeSuccessfullyPopUp)));
        }
        public void EditRecordInAdditionalDocFeeTable(string Description)
        {
            RecordInAdditionalDocFeesTable.Click();
            EditIconForAdditionalDocFeesTable.Click();
            DescriptionFieldAdditionalTbl.SendKeys(Description);
        }
        public void VerifyEditAdditionalDocFeeWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_additionalDocFeeUpdatedPopUp)));
        }
        public void VerifyDeleteAdditionalDocFeeWarningPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_additionalDocFeeDeletePopUp)));
        }
        public void DeleteRecordInAdditionalDocFees()
        {
            RecordInAdditionalDocFeesTable.Click();
            DeleteIconForAdditionalDocFeesTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        /// Doc Fees
        public void ClickOnExcludedProductsTab()
        {
            ExcludedProductsTab.Click();
        }
        public void ClickOnAddNewExcludedProductButton()
        {
            AddNewExcludedProductButton.Click();
        }
        public void FillDataForExcludedProduct()
        {
            ProductTypeNameDropDown.Click();
            NameProductFromDropDown.Click();
        }
        public void VerifyAddExcludedProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_excludedProductsSuccessfulyPopUp)));
        }
        public void EditRecordInExcludedProduct()
        {
            RecordInExcludedProductTable.Click();
            EditIconExcludedProductTable.Click();
            CheckBoxForExcludedProducts.Click();
        }
        public void VerifyEditExcludedProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_excludedProductUpdatedPopUp)));
        }
        public void DeleteRecordInExcludedProduct()
        {
            RecordInExcludedProductTable.Click();
            DeleteIconForExcludedProductTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        /// Credit Rules
        public void ClickOnCreditRulesTab()
        {
            CreditRulesTab.Click();
        }
        public void ClickOnAddNewCreditRuleButton()
        {
            AddNewCreditRuleButton.Click();
        }
        public void FillDataForCreditRule()
        {
            CreditRuleTypeDropdown.Click();
            ConditionDropdown.Click();
            DataOfCreditRuleTypeDropdown.Click();
            DataOfConditionDropdown.Click();
            ValueField.SendKeys("2");
            YellowValueField.SendKeys("23");
        }
        public void VerifyAddcreditRuleProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_creditRuleSuccessfulyPopUp)));
        }
        public void EditRecordInCreditRule(string Value)
        {
            RecordInCreditRuleTable.Click();
            EditIconCreditRuleTable.Click();
            ValueField.SendKeys(Value);
        }
        public void VerifyEditCreditRuleProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_creditRuleUpdatedPopUp)));
        }
        public void DeleteRecordInCreditRule()
        {
            RecordInCreditRuleTable.Click();
            DeleteIconForCreditRuleTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void VerifyCreditRuleProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_creditRuleDeletePopUp)));
        }
        /// Formulas
        public void ClickOnFormulasTab()
        {
            FormulasTab.Click();
        }
        public void ClickOnAddNewFormulaButton()
        {
            AddNewFormulaButton.Click();
        }
        public void FillDataForFormula()
        {
            FormulaNameDropdown.Click();
            DataOfFormulaNameDropdown.Click();
            FormulaExpressionField.SendKeys("23");
        }
        public void VerifyAddFormulaPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_formulaSuccessfulyPopUp)));
        }
        public void EditRecordInFormula(string Formula)
        {
            RecordInFormulasTable.Click();
            EditIconFormulasTable.Click();
            FormulaExpressionFieldForEdit.Clear();
            FormulaExpressionFieldForEdit.SendKeys(Formula);
        }
        public void VerifyEditFormulasProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_formulaUpdatedPopUp)));
        }
        public void DeleteRecordInFormula()
        {
            RecordInFormulasTable.Click();
            DeleteIconForFormulaTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void VerifyDeleteFormulaProductPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_formulaDeletePopUp)));
        }
        #endregion

    }
}
