using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phoenix2.APITests.DTO.AuthorizationModels
{
    public class Phoenix2AppOptions
    {
        public string ApplicationInsightsKey { get; set; }
        public string ServiceBasePath { get; set; }


        #region leadService

        public string GetLeadServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "lead-service/";

            }
            else
            {
                throw new Exception("Base path is null");
            }
        }

        public Uri GetLeadServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "lead-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region dealService
        public string GetDealServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "deal-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetDealServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "deal-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region assetService
        public string GetAssetServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "asset-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetAssetServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "asset-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region productService
        public string GetProductServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "product-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetProductServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "product-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region lenderService
        public string GetLenderServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "lender-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetLenderServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "lender-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region documentServicePath
        public string GetDocumentServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "document-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetDocumentServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "document-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region contactServicePath
        public string GetContactServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "contact-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetContactServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return new Uri(this.ServiceBasePath + "contact-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region userServicePath

        public string GetUserServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "user-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetUserServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "user-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }

        #endregion

        #region configurationServicePath
        public string GetConfigurationServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "configuration-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetConfigurationServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "configuration-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region workflowServicePath
        public string GetWorkflowServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "workflow-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetWorkflowServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "workflow-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region searchServicePath
        public string GetSearchServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "search-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetSearchServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "search-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region accountingServicePath
        public string GetAccountingServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "accounting-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetAccountingServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "accounting-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region paymentServicePath
        public string GetPaymentServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "payment-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetPaymentServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "payment-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        #region paymentServicePath
        public string GetCommunicationServicePath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {

                CheckBasePath();
                return this.ServiceBasePath + "communication-service/";
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        public Uri GetCommunicationServiceUriPath()
        {
            if (!string.IsNullOrWhiteSpace(this.ServiceBasePath))
            {
                CheckBasePath();
                return new Uri(this.ServiceBasePath + "communication-service/", UriKind.RelativeOrAbsolute);
            }
            else
            {
                throw new Exception("Base path is null");
            }
        }
        #endregion

        private void CheckBasePath()
        {
            this.ServiceBasePath = this.ServiceBasePath.Trim();
            var doesHaveEndSlash = string.Equals(this.ServiceBasePath.Substring(this.ServiceBasePath.Length - 1), "/",
                StringComparison.OrdinalIgnoreCase);

            if (!doesHaveEndSlash)
                this.ServiceBasePath += "/";
        }
    }
}
