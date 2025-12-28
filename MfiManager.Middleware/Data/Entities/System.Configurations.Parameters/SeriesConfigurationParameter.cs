namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class SeriesConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "BranchIdentifier", description: "Branch series indetifier")]
        public string BranchIdentifier { get; set; }
        [ConfigParam(name: "BranchCode", description: "Branch series last used code", paramType: "int")]
        public string BranchCode { get; set; }
        [ConfigParam(name: "IndividualCustomersIdentifier", description: "Individual customers series indetifier")]
        public string IndividualCustomersIdentifier { get; set; }
        [ConfigParam(name: "IndividualCustomersCode", description: "Business customers series last used code", paramType: "int")]
        public string IndividualCustomersCode { get; set; }
        [ConfigParam(name: "GroupCustomersIdentifier", description: "Group customers series indetifier")]
        public string GroupCustomersIdentifier { get; set; }
        [ConfigParam(name: "GroupCustomersCode", description: "Group customers series last used code", paramType: "int")]
        public string GroupCustomersCode { get; set; }
        [ConfigParam(name: "MemberCustomersIdentifier", description: "Group member series indetifier")]
        public string MemberCustomersIdentifier { get; set; }
        [ConfigParam(name: "MemberCustomersCode", description: "Group member series last used code", paramType: "int")]
        public string MemberCustomersCode { get; set; }
        [ConfigParam(name: "BusinessCustomersIdentifier", description: "Business customers series indetifier")]
        public string BusinessCustomersIdentifier { get; set; }
        [ConfigParam(name: "BusinessCustomersCode", description: "Business customers series last used code", paramType: "int")]
        public string BusinessCustomersCode { get; set; }
        [ConfigParam(name: "TradeCustomersIdentifier", description: "Trade customers series indetifier")]
        public string TradeCustomersIdentifier { get; set; }
        [ConfigParam(name: "TradeCustomersCode", description: "Trade customers series last used code", paramType: "int")]
        public string TradeCustomersCode { get; set; }
        [ConfigParam(name: "CustomerRelativesIdentifier", description: "Customer relative series indetifier")]
        public string CustomerRelativesIdentifier { get; set; }
        [ConfigParam(name: "CustomerRelativesCode", description: "Customer relative series last used code", paramType: "int")]
        public string CustomerRelativesCode { get; set; }
        [ConfigParam(name: "VendorsIdentifier", description: "Vendor series indetifier")]
        public string VendorsIdentifier { get; set; }
        [ConfigParam(name: "VendorsCode", description: "Vendor series last used code", paramType: "int")]
        public string VendorsCode { get; set; }
        [ConfigParam(name: "PurchaseOrdersIdentifier", description: "Purchase order series indetifier")]
        public string PurchaseOrdersIdentifier { get; set; }
        [ConfigParam(name: "PurchaseOrdersCode", description: "Purchase order series last used code", paramType: "int")]
        public string PurchaseOrdersCode { get; set; }
        [ConfigParam(name: "SalesOrdersIdentifier", description: "Sales order series indetifier")]
        public string SalesOrdersIdentifier { get; set; }
        [ConfigParam(name: "SalesOrdersCode", description: "Sales order series last used code", paramType: "int")]
        public string SalesOrdersCode { get; set; }
        [ConfigParam(name: "PurchaseInvoicesIdentifier", description: "Purchase invoice series indetifier")]
        public string PurchaseInvoicesIdentifier { get; set; }
        [ConfigParam(name: "PurchaseInvoicesCode", description: "Purchase invoice series last used code", paramType: "int")]
        public string PurchaseInvoicesCode { get; set; }
        [ConfigParam(name: "SalesInvoicesIdentifier", description: "Sales invoice series indetifier")]
        public string SalesInvoicesIdentifier { get; set; }
        [ConfigParam(name: "SalesInvoicesCode", description: "Sales invoice series last used code", paramType: "int")]
        public string SalesInvoicesCode { get; set; }
        [ConfigParam(name: "FixedAssetsIdentifier", description: "Fixed assets series indetifier")]
        public string FixedAssetsIdentifier { get; set; }
        [ConfigParam(name: "FixedAssetsCode", description: "Fixed assets series last used code", paramType: "int")]
        public string FixedAssetsCode { get; set; }
        [ConfigParam(name: "IntangibleAssetsIdentifier", description: "Intangible assets series indetifier")]
        public string IntangibleAssetsIdentifier { get; set; }
        [ConfigParam(name: "IntangibleAssetsCode", description: "Intangible assets series last used code", paramType: "int")]
        public string IntangibleAssetsCode { get; set; }
        [ConfigParam(name: "LoansIdentifier", description: "Loan series indetifier")]
        public string LoansIdentifier { get; set; }
        [ConfigParam(name: "LoanIndividualPrefix", description: "Individual Loan series indetifier")]
        public string LoanIndividualPrefix { get; set; }
        [ConfigParam(name: "LoanIndividualCode", description: "Individual Loan series last used code", paramType: "int")]
        public string LoanIndividualCode { get; set; }
        [ConfigParam(name: "LoanBusinessPrefix", description: "Business Loan series indetifier", paramType: "int")]
        public string LoanBusinessPrefix { get; set; }
        [ConfigParam(name: "LoanBusinessCode", description: "Business Loan series last used code", paramType: "int")]
        public string LoanBusinessCode { get; set; }
        [ConfigParam(name: "LoanGroupPrefix", description: "Group Loan series indetifier", paramType: "int")]
        public string LoanGroupPrefix { get; set; }
        [ConfigParam(name: "LoanGroupCode", description: "Group Loan series last used code", paramType: "int")]
        public string LoanGroupCode { get; set; }
        [ConfigParam(name: "SavingsAccountIndividualIdentifier", description: "Individual Saving Account series indetifier", paramType: "int")]
        public string SavingsAccountIndividualIdentifier { get; set; }
        [ConfigParam(name: "SavingsAccountIndividualCode", description: "Individual Saving Account series last used code", paramType: "int")]
        public string SavingsAccountIndividualCode { get; set; }
        [ConfigParam(name: "SavingsAccountBusinessIdentifier", description: "Business Saving Account series indetifier", paramType: "int")]
        public string SavingsAccountBusinessIdentifier { get; set; }
        [ConfigParam(name: "SavingsAccountBusinessCode", description: "Business Saving Account series last used code", paramType: "int")]
        public string SavingsAccountBusinessCode { get; set; }
        [ConfigParam(name: "SavingsAccountMemberIdentifier", description: "Member Saving Account series indetifier", paramType: "int")]
        public string SavingsAccountMemberIdentifier { get; set; }
        [ConfigParam(name: "SavingsAccountMemberCode", description: "Member Saving Account series last used code", paramType: "int")]
        public string SavingsAccountMemberCode { get; set; }
        [ConfigParam(name: "SavingsAccountJointIdentifier", description: "Joint Saving Account series indetifier", paramType: "int")]
        public string SavingsAccountJointIdentifier { get; set; }
        [ConfigParam(name: "SavingsAccountJointCode", description: "Joint Saving Account series last used code", paramType: "int")]
        public string SavingsAccountJointCode { get; set; }
        [ConfigParam(name: "VouchersIdentifier", description: "Voucher indentifier series indetifier")]
        public string VouchersIdentifier { get; set; }
        [ConfigParam(name: "VouchersCode", description: "Voucher series last used code", paramType: "int")]
        public string VouchersCode { get; set; }
        [ConfigParam(name: "JournalsIdentifier", description: "Journal indentifier series indetifier")]
        public string JournalsIdentifier { get; set; }
        [ConfigParam(name: "JournalsCode", description: "Journal series last used code", paramType: "int")]
        public string JournalsCode { get; set; }
        [ConfigParam(name: "BusinessPostingsIdentifier", description: "Business Poasting indentifier series indetifier")]
        public string BusinessPostingsIdentifier { get; set; }
        [ConfigParam(name: "BusinessPostingsCode", description: "Business Poasting series last used code", paramType: "int")]
        public string BusinessPostingsCode { get; set; }
        [ConfigParam(name: "GeneralPostingsIdentifier", description: "General Poasting indentifier series indetifier")]
        public string GeneralPostingsIdentifier { get; set; }
        [ConfigParam(name: "GeneralPostingsCode", description: "General Poasting series last used code", paramType: "int")]
        public string GeneralPostingsCode { get; set; }
        [ConfigParam(name: "ProductTypeIdentifier", description: "Product Type series indetifier")]
        public string ProductTypeIdentifier { get; set; }
        [ConfigParam(name: "ProductTypeCode", description: "Product Type series last used code", paramType: "int")]
        public string ProductTypeCode { get; set; }
        [ConfigParam(name: "SavingProductPrefix", description: "Saving Product series indetifier")]
        public string SavingProductPrefix { get; set; }
        [ConfigParam(name: "SavingProductCode", description: "Saving Product series last used code", paramType: "int")]
        public string SavingProductCode { get; set; }
        [ConfigParam(name: "LoanProductPrefix", description: "Loan Product series indetifier")]
        public string LoanProductPrefix { get; set; }
        [ConfigParam(name: "LoanProductCode", description: "Loan Product series last used code", paramType: "int")]
        public string LoanProductCode { get; set; }
        [ConfigParam(name: "ShareProductPrefix", description: "Share Product series indetifier")]
        public string ShareProductPrefix { get; set; }
        [ConfigParam(name: "ShareProductCode", description: "Share Product series last used code", paramType: "int")]
        public string ShareProductCode { get; set; }
        [ConfigParam(name: "InsuranceProductPrefix", description: "Insurance Product series indetifier")]
        public string InsuranceProductPrefix { get; set; }
        [ConfigParam(name: "InsuranceProductCode", description: "Insurance Product series last used code", paramType: "int")]
        public string InsuranceProductCode { get; set; }
        [ConfigParam(name: "TimedepositProductPrefix", description: "Timedeposit Product series indetifier")]
        public string TimedepositProductPrefix { get; set; }
        [ConfigParam(name: "TimedepositProductCode", description: "Timedeposit Product series last used code", paramType: "int")]
        public string TimedepositProductCode { get; set; }
        [ConfigParam(name: "RevenueCenterPrefix", description: "Revenue Center series indetifier")]
        public string RevenueCenterPrefix { get; set; }
        [ConfigParam(name: "RevenueCenterCode", description: "Revenue Center series last used code", paramType: "int")]
        public string RevenueCenterCode { get; set; }
        [ConfigParam(name: "CostCenterPrefix", description: "Cost Center series indetifier")]
        public string CostCenterPrefix { get; set; }
        [ConfigParam(name: "CostCenterCode", description: "Cost Center series last used code", paramType: "int")]
        public string CostCenterCode { get; set; }
        [ConfigParam(name: "Departmentdentifier", description: "Department series indetifier")]
        public string Departmentdentifier { get; set; }
        [ConfigParam(name: "DepartmentCode", description: "Department series last used code", paramType: "int")]
        public string DepartmentCode { get; set; }
        [ConfigParam(name: "ReferenceIdentifier", description: "Reference series indetifier")]
        public string ReferenceIdentifier { get; set; }
        [ConfigParam(name: "ReferenceCode", description: "Reference series last used code", paramType: "int")]
        public string ReferenceCode { get; set; }
        [ConfigParam(name: "ReferenceValueIdentifier", description: "Reference value series indetifier")]
        public string ReferenceValueIdentifier { get; set; }
        [ConfigParam(name: "ReferenceValueCode", description: "Reference value series last used code", paramType: "int")]
        public string ReferenceValueCode { get; set; }
        [ConfigParam(name: "ChargeGroupsIdentifier", description: "Charge group indentifier series indetifier")]
        public string ChargeGroupsIdentifier { get; set; }
        [ConfigParam(name: "ChargeGroupsCode", description: "Charge group series last used code", paramType: "int")]
        public string ChargeGroupsCode { get; set; }
        [ConfigParam(name: "SavingProductChargeItemPrefix", description: "Saving Product Charge series indetifier")]
        public string SavingProductChargeItemPrefix { get; set; }
        [ConfigParam(name: "SavingProductChargeCode", description: "Saving Product Charge series last used code", paramType: "int")]
        public string SavingProductChargeCode { get; set; }
        [ConfigParam(name: "LoanProductChargeItemPrefix", description: "Loan Product Charge series indetifier")]
        public string LoanProductChargeItemPrefix { get; set; }
        [ConfigParam(name: "LoanProductChargeCode", description: "Loan Product Charge series last used code", paramType: "int")]
        public string LoanProductChargeCode { get; set; }
        [ConfigParam(name: "ShareProductChargeItemPrefix", description: "Share Product Charge series indetifier")]
        public string ShareProductChargeItemPrefix { get; set; }
        [ConfigParam(name: "ShareProductChargeCode", description: "Share Product Charge series last used code", paramType: "int")]
        public string ShareProductChargeCode { get; set; }
        [ConfigParam(name: "InsuranceProductChargeItemPrefix", description: "Insurance Product series indetifier")]
        public string InsuranceProductChargeItemPrefix { get; set; }
        [ConfigParam(name: "InsuranceProductChargeCode", description: "Insurance Product Charge series last used code", paramType: "int")]
        public string InsuranceProductChargeCode { get; set; }
        [ConfigParam(name: "TimedepositProductChargeItemPrefix", description: "Timedeposit Product Charge series indetifier")]
        public string TimedepositProductChargeItemPrefix { get; set; }
        [ConfigParam(name: "TimedepositProductChargeCode", description: "Timedeposit Product Charge series last used code", paramType: "int")]
        public string TimedepositProductChargeCode { get; set; }
        [ConfigParam(name: "RegistrationChargePrefix", description: "Registration charge series indetifier")]
        public string RegistrationChargePrefix { get; set; }
        [ConfigParam(name: "RegistrationChargeCode", description: "Registration charge series last used code", paramType: "int")]
        public string RegistrationChargeCode { get; set; }
        [ConfigParam(name: "AdministrationChargePrefix", description: "Administration charge series indetifier")]
        public string AdministrationChargePrefix { get; set; }
        [ConfigParam(name: "RegistrationChargeCode", description: "Administration charge series last used code", paramType: "int")]
        public string AdministrationChargeCode { get; set; }
        [ConfigParam(name: "StationeryChargePrefix", description: "Stationery charge series indetifier")]
        public string StationeryChargePrefix { get; set; }
        [ConfigParam(name: "RegistrationChargeCode", description: "Stationery charge series last used code", paramType: "int")]
        public string StationeryChargeCode { get; set; }
        [ConfigParam(name: "CommissionChargePrefix", description: "Commission charge series indetifier")]
        public string CommissionChargePrefix { get; set; }
        [ConfigParam(name: "CommissionChargeCode", description: "Commission charge series last used code", paramType: "int")]
        public string CommissionChargeCode { get; set; }
        [ConfigParam(name: "SurchargePrefix", description: "Surcharge charge series indetifier")]
        public string SurchargePrefix { get; set; }
        [ConfigParam(name: "SurchargeCode", description: "Surcharge charge series last used code", paramType: "int")]
        public string SurchargeCode { get; set; }
        [ConfigParam(name: "DevelopmentChargePrefix", description: "Developement charge series indetifier")]
        public string DevelopmentChargePrefix { get; set; }
        [ConfigParam(name: "DevelopmentChargeCode", description: "Developement charge series last used code", paramType: "int")]
        public string DevelopmentChargeCode { get; set; }
        [ConfigParam(name: "RefinanceChargePrefix", description: "Refinance charge series indetifier")]
        public string RefinanceChargePrefix { get; set; }
        [ConfigParam(name: "RefinanceChargeCode", description: "Refinance charge series last used code", paramType: "int")]
        public string RefinanceChargeCode { get; set; }
        [ConfigParam(name: "ProcessingChargePrefix", description: "Processing charge series indetifier")]
        public string ProcessingChargePrefix { get; set; }
        [ConfigParam(name: "ProcessingChargeCode", description: "Processing charge series last used code", paramType: "int")]
        public string ProcessingChargeCode { get; set; }
        [ConfigParam(name: "PenaltyChargePrefix", description: "Penalty charge series indetifier")]
        public string PenaltyChargePrefix { get; set; }
        [ConfigParam(name: "PenaltyChargeCode", description: "Penalty charge series last used code", paramType: "int")]
        public string PenaltyChargeCode { get; set; }
        [ConfigParam(name: "StandingOrderChargePrefix", description: "Standing Order charge series indetifier")]
        public string StandingOrderChargePrefix { get; set; }
        [ConfigParam(name: "StandingOrderChargeCode", description: "Standing Order charge series last used code", paramType: "int")]
        public string StandingOrderChargeCode { get; set; }
        [ConfigParam(name: "SmsChargePrefix", description: "SMS charge series indetifier")]
        public string SmsChargePrefix { get; set; }
        [ConfigParam(name: "SmsChargeCode", description: "SMS charge series last used code", paramType: "int")]
        public string SmsChargeCode { get; set; }
        [ConfigParam(name: "CardChargePrefix", description: "Card charge series indetifier")]
        public string CardChargePrefix { get; set; }
        [ConfigParam(name: "CardChargeCode", description: "Card charge series last used code", paramType: "int")]
        public string CardChargeCode { get; set; }
        [ConfigParam(name: "OverdraftChargePrefix", description: "Overdraft charge series indetifier")]
        public string OverdraftChargePrefix { get; set; }
        [ConfigParam(name: "OverdraftChargeCode", description: "Overdraft charge series last used code", paramType: "int")]
        public string OverdraftChargeCode { get; set; }
        [ConfigParam(name: "TaxGroupIdentifier", description: "Tax group series indetifier")]
        public string TaxGroupIdentifier { get; set; }
        [ConfigParam(name: "TaxGroupCode", description: "Tax group series last used code", paramType: "int")]
        public string TaxGroupCode { get; set; }
        [ConfigParam(name: "IncomeTaxIdentifier", description: "Income Tax series indetifier")]
        public string IncomeTaxIdentifier { get; set; }
        [ConfigParam(name: "IncomeTaxCode", description: "Income Tax series last used code", paramType: "int")]
        public string IncomeTaxCode { get; set; }
        [ConfigParam(name: "WithHoldingTaxIdentifier", description: "Withholding Tax series indetifier")]
        public string WithHoldingTaxIdentifier { get; set; }
        [ConfigParam(name: "WithHoldingTaxCode", description: "Withholding Tax series last used code", paramType: "int")]
        public string WithHoldingTaxCode { get; set; }
        [ConfigParam(name: "VatIdentifier", description: "VAT Tax series indetifier")]
        public string VatIdentifier { get; set; }
        [ConfigParam(name: "VatCode", description: "VAT Tax series last used code", paramType: "int")]
        public string VatCode { get; set; }
        [ConfigParam(name: "VatOnSavingsIdentifier", description: "VAT On Saving series indetifier")]
        public string VatOnSavingsIdentifier { get; set; }
        [ConfigParam(name: "VatOnSavingsCode", description: "VAT On Saving series last used code", paramType: "int")]
        public string VatOnSavingsCode { get; set; }
        [ConfigParam(name: "VatOnSharesIdentifier", description: "VAT On Share series indetifier")]
        public string VatOnSharesIdentifier { get; set; }
        [ConfigParam(name: "VatOnShareCode", description: "VAT On Share series last used code", paramType: "int")]
        public string VatOnShareCode { get; set; }
        [ConfigParam(name: "VatOnInsuranceIdentifier", description: "VAT On Insurance series indetifier")]
        public string VatOnInsuranceIdentifier { get; set; }
        [ConfigParam(name: "VatOnInsuranceCode", description: "VAT On Insurance series last used code", paramType: "int")]
        public string VatOnInsuranceCode { get; set; }
        [ConfigParam(name: "VatOnTimedepositIdentifier", description: "VAT On Timedeposit series indetifier")]
        public string VatOnTimedepositIdentifier { get; set; }
        [ConfigParam(name: "VatOnTimedepositCode", description: "VAT On Timedeposit series last used code", paramType: "int")]
        public string VatOnTimedepositCode { get; set; }
        [ConfigParam(name: "VatOnLoansIdentifier", description: "VAT On Loan series indetifier")]
        public string VatOnLoansIdentifier { get; set; }
        [ConfigParam(name: "VatOnLoanCode", description: "VAT On Loan series last used code", paramType: "int")]
        public string VatOnLoanCode { get; set; }
        [ConfigParam(name: "ExciseDutyIdentifier", description: "Excise Duty series indetifier")]
        public string ExciseDutyIdentifier { get; set; }
        [ConfigParam(name: "ExciseDutyCode", description: "Excise Duty series last used code", paramType: "int")]
        public string ExciseDutyCode { get; set; }
        [ConfigParam(name: "StampDutyIdentifier", description: "Stamp Duty series indetifier")]
        public string StampDutyIdentifier { get; set; }
        [ConfigParam(name: "StampDutyCode", description: "Stamp Duty series last used code", paramType: "int")]
        public string StampDutyCode { get; set; }
        [ConfigParam(name: "CustomsDutyIdentifier", description: "Customs Duty series indetifier")]
        public string CustomsDutyIdentifier { get; set; }
        [ConfigParam(name: "CustomsDutyCode", description: "Customs Duty series last used code", paramType: "int")]
        public string CustomsDutyCode { get; set; }
        [ConfigParam(name: "ImportDutyIdentifier", description: "Import Duty series indetifier")]
        public string ImportDutyIdentifier { get; set; }
        [ConfigParam(name: "ImportDutyCode", description: "Import Duty series last used code", paramType: "int")]
        public string ImportDutyCode { get; set; }
        [ConfigParam(name: "LocalServiceTaxIdentifier", description: "Local Service Tax series indetifier")]
        public string LocalServiceTaxIdentifier { get; set; }
        [ConfigParam(name: "LocalServiceTaxCode", description: "Local Service Tax series last used code", paramType: "int")]
        public string LocalServiceTaxCode { get; set; }
        [ConfigParam(name: "Filter1Identifier", description: "Customer filter 1 series indetifier")]
        public string Filter1Identifier { get; set; }
        [ConfigParam(name: "Filter1Code", description: "Customer filter 1 series last used code", paramType: "int")]
        public string Filter1Code { get; set; }
        [ConfigParam(name: "Filter2Identifier", description: "Customer filter 2 series indetifier")]
        public string Filter2Identifier { get; set; }
        [ConfigParam(name: "Filter2Code", description: "Customer filter 2 series last used code", paramType: "int")]
        public string Filter2Code { get; set; }
        [ConfigParam(name: "Filter3Identifier", description: "Customer filter 3 series indetifier")]
        public string Filter3Identifier { get; set; }
        [ConfigParam(name: "Filter3Code", description: "Customer filter 3 series last used code", paramType: "int")]
        public string Filter3Code { get; set; }
        [ConfigParam(name: "Filter4Identifier", description: "Customer filter 4 series indetifier")]
        public string Filter4Identifier { get; set; }
        [ConfigParam(name: "Filter4Code", description: "Customer filter 4 series last used code", paramType: "int")]
        public string Filter4Code { get; set; }
        [ConfigParam(name: "Filter5Identifier", description: "Customer filter 5 series indetifier")]
        public string Filter5Identifier { get; set; }
        [ConfigParam(name: "Filter5Code", description: "Customer filter 5 series last used code", paramType: "int")]
        public string Filter5Code { get; set; }
        [ConfigParam(name: "GroupFilter1Identifier", description: "Group filter 1 series last used code", paramType: "int")]
        public string GroupFilter1Identifier { get; set; }
        [ConfigParam(name: "GroupFilter1Code", description: "Group filter 1 series indetifier")]
        public string GroupFilter1Code { get; set; }
        [ConfigParam(name: "GroupFilter2Identifier", description: "Group filter 2 series last used code", paramType: "int")]
        public string GroupFilter2Identifier { get; set; }
        [ConfigParam(name: "GroupFilter2Code", description: "Group filter 2 series last used code", paramType: "int")]
        public string GroupFilter2Code { get; set; }
        [ConfigParam(name: "MemberFilter1Identifier", description: "Member filter 1 series indetifier")]
        public string MemberFilter1Identifier { get; set; }
        [ConfigParam(name: "MemberFilter1Code", description: "Member filter 1 series last used code", paramType: "int")]
        public string MemberFilter1Code { get; set; }
        [ConfigParam(name: "MemberFilter2Identifier", description: "Member filter 2 series indetifier")]
        public string MemberFilter2Identifier { get; set; }
        [ConfigParam(name: "MemberFilter2Code", description: "Member filter 2 series last used code", paramType: "int")]
        public string MemberFilter2Code { get; set; }
        [ConfigParam(name: "BusinessFilter1Identifier", description: "Business filter 1 series indetifier")]
        public string BusinessFilter1Identifier { get; set; }
        [ConfigParam(name: "BusinessFilter1Code", description: "Business filter 1 series last used code", paramType: "int")]
        public string BusinessFilter1Code { get; set; }
        [ConfigParam(name: "BusinessFilter2Identifier", description: "Business filter 2 series indetifier")]
        public string BusinessFilter2Identifier { get; set; }
        [ConfigParam(name: "BusinessFilter2Code", description: "Business filter 2 series last used code", paramType: "int")]
        public string BusinessFilter2Code { get; set; }
    }

}
