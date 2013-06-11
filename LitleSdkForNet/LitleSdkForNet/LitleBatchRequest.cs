﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Litle.Sdk
{
    public partial class litleBatchRequest
    {

        public string id;

        public string merchantId;

        //TODO ask what is this
        public int numAccountUpdates;
        public string reportGroup;

        public Dictionary<String, String> config;

        public string batchFilePath;
        private string tempBatchFilePath;
        private litleFileGenerator litleFileGenerator;
        private litleTime litleTime;

        private int numAuthorization;
        private int numCapture;
        private int numCredit;
        private int numSale;
        private int numAuthReversal;
        private int numEcheckCredit;
        private int numEcheckVerification;
        private int numEcheckSale;
        private int numRegisterTokenRequest;
        private int numForceCapture;
        private int numCaptureGivenAuth;
        private int numEcheckRedeposit;
        private int numUpdateCardValidationNumOnToken;

        private long sumOfAuthorization;
        private long sumOfAuthReversal;
        private long sumOfCapture;
        private long sumOfCredit;
        private long sumOfSale;
        private long sumOfForceCapture;
        private long sumOfEcheckSale;
        private long sumOfEcheckCredit;
        private long sumOfEcheckVerification;
        private long sumOfCaptureGivenAuth;

        public litleBatchRequest()
        {
            config = new Dictionary<String, String>();

            config["url"] = Properties.Settings.Default.url;
            config["reportGroup"] = Properties.Settings.Default.reportGroup;
            config["username"] = Properties.Settings.Default.username;
            config["printxml"] = Properties.Settings.Default.printxml;
            config["timeout"] = Properties.Settings.Default.timeout;
            config["proxyHost"] = Properties.Settings.Default.proxyHost;
            config["merchantId"] = Properties.Settings.Default.merchantId;
            config["password"] = Properties.Settings.Default.password;
            config["proxyPort"] = Properties.Settings.Default.proxyPort;
            config["sftpUrl"] = Properties.Settings.Default.sftpUrl;
            config["sftpUsername"] = Properties.Settings.Default.sftpUsername;
            config["sftpPassword"] = Properties.Settings.Default.sftpPassword;
            config["knownHostsFile"] = Properties.Settings.Default.knownHostsFile;

            litleFileGenerator = new litleFileGenerator();
            litleTime = new litleTime();

            numAuthorization = 0;
            numAuthReversal = 0;
            numCapture = 0;
            numCaptureGivenAuth = 0;
            numCredit = 0;
            numEcheckCredit = 0;
            numEcheckRedeposit = 0;
            numEcheckSale = 0;
            numEcheckVerification = 0;
            numForceCapture = 0;
            numRegisterTokenRequest = 0;
            numSale = 0;
            numUpdateCardValidationNumOnToken = 0;

            sumOfAuthorization = 0;
            sumOfAuthReversal = 0;
            sumOfCapture = 0;
            sumOfCredit = 0;
            sumOfSale = 0;
            sumOfForceCapture = 0;
            sumOfEcheckSale = 0;
            sumOfEcheckCredit = 0;
            sumOfEcheckVerification = 0;
            sumOfCaptureGivenAuth = 0;
        }

        public litleBatchRequest(Dictionary<String, String> config)
        {
            this.config = config;

            //authentication = new authentication();

            //authentication.user = config["username"];
            //authentication.password = config["password"];
        }

        public void addAuthorization(authorization authorization)
        {
            numAuthorization++;
            sumOfAuthorization += authorization.amount;
            fillInReportGroup(authorization);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, authorization);
        }

        public void addCapture(capture capture)
        {
            numCapture++;
            sumOfCapture += capture.amount;
            fillInReportGroup(capture);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, capture);
        }

        public void addCredit(credit credit)
        {
            numCredit++;
            sumOfCredit += credit.amount;
            fillInReportGroup(credit);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, credit);
        }

        public void addSale(sale sale)
        {
            numSale++;
            sumOfSale += sale.amount;
            fillInReportGroup(sale);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, sale);
        }

        public void addAuthReversal(authReversal authReversal)
        {
            numAuthReversal++;
            sumOfAuthReversal += authReversal.amount;
            fillInReportGroup(authReversal);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, authReversal);
        }

        public void addEcheckCredit(echeckCredit echeckCredit)
        {
            numEcheckCredit++;
            sumOfEcheckCredit += echeckCredit.amount;
            fillInReportGroup(echeckCredit);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, echeckCredit);
        }

        public void addEcheckVerification(echeckVerification echeckVerification)
        {
            numEcheckVerification++;
            sumOfEcheckVerification += echeckVerification.amount;
            fillInReportGroup(echeckVerification);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, echeckVerification);
        }

        public void addEcheckSale(echeckSale echeckSale)
        {
            numEcheckSale++;
            sumOfEcheckSale += echeckSale.amount;
            fillInReportGroup(echeckSale);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, echeckSale);
        }

        public void addRegisterTokenRequest(registerTokenRequestType registerTokenRequestType)
        {
            numRegisterTokenRequest++;
            fillInReportGroup(registerTokenRequestType);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, registerTokenRequestType);
        }

        public void addForceCapture(forceCapture forceCapture)
        {
            numForceCapture++;
            sumOfForceCapture += forceCapture.amount;
            fillInReportGroup(forceCapture);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, forceCapture);
        }

        public void addCaptureGivenAuth(captureGivenAuth captureGivenAuth)
        {
            numCaptureGivenAuth++;
            sumOfCaptureGivenAuth += captureGivenAuth.amount;
            fillInReportGroup(captureGivenAuth);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, captureGivenAuth);
        }

        public void addEcheckRedeposit(echeckRedeposit echeckRedeposit)
        {
            numEcheckRedeposit++;
            fillInReportGroup(echeckRedeposit);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, echeckRedeposit);
        }

        public void addUpdateCardValidationNumOnToken(updateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            numUpdateCardValidationNumOnToken++;
            fillInReportGroup(updateCardValidationNumOnToken);
            tempBatchFilePath = saveElement(litleFileGenerator, litleTime, tempBatchFilePath, updateCardValidationNumOnToken);
        }

        public String Serialize()
        {
            string xmlHeader = "\r\n<batchRequest " +
                "id=\"" + id + "\"\r\n";

            if (numAuthorization != 0)
            {
                xmlHeader += "numAuths=\"" + numAuthorization + "\"\r\n";
                xmlHeader += "authAmount=\"" + sumOfAuthorization + "\"\r\n";
            }

            if (numAuthReversal != 0)
            {
                xmlHeader += "numAuthReversals=\"" + numAuthReversal + "\"\r\n";
                xmlHeader += "authReversalAmount=\"" + sumOfAuthReversal + "\"\r\n";
            }

            if (numCapture != 0)
            {
                xmlHeader += "numCaptures=\"" + numCapture + "\"\r\n";
                xmlHeader += "captureAmount=\"" + sumOfCapture + "\"\r\n";
            }

            if (numCredit != 0)
            {

                xmlHeader += "numCredits=\"" + numCredit + "\"\r\n";
                xmlHeader += "creditAmount=\"" + sumOfCredit + "\"\r\n";
            }

            if (numForceCapture != 0)
            {

                xmlHeader += "numForceCaptures=\"" + numForceCapture + "\"\r\n";
                xmlHeader += "forceCaptureAmount=\"" + sumOfForceCapture + "\"\r\n";
            }

            if (numSale != 0)
            {

                xmlHeader += "numSales=\"" + numSale + "\"\r\n";
                xmlHeader += "saleAmount=\"" + sumOfSale + "\"\r\n";
            }

            if (numCaptureGivenAuth != 0)
            {

                xmlHeader += "numCaptureGivenAuths=\"" + numCaptureGivenAuth + "\"\r\n";
                xmlHeader += "captureGivenAuthAmount=\"" + sumOfCaptureGivenAuth + "\"\r\n";
            }

            if (numEcheckSale != 0)
            {

                xmlHeader += "numEcheckSales=\"" + numEcheckSale + "\"\r\n";
                xmlHeader += "echeckSalesAmount=\"" + sumOfEcheckSale + "\"\r\n";
            }

            if (numEcheckCredit != 0)
            {

                xmlHeader += "numEcheckCredit=\"" + numEcheckCredit + "\"\r\n";
                xmlHeader += "echeckCreditAmount=\"" + sumOfEcheckCredit + "\"\r\n";
            }

            if (numEcheckVerification != 0)
            {

                xmlHeader += "numEcheckVerification=\"" + numEcheckVerification + "\"\r\n";
                xmlHeader += "echeckVerificationAmount=\"" + sumOfEcheckVerification + "\"\r\n";
            }

            if (numEcheckRedeposit != 0)
            {
                xmlHeader += "numEcheckRedeposit=\"" + numEcheckRedeposit + "\"\r\n";
            }

            xmlHeader += "numAccountUpdates=\"" + numAccountUpdates + "\"\r\n";

            if (numRegisterTokenRequest != 0)
            {
                xmlHeader += "numTokenRegistrations=\"" + numRegisterTokenRequest + "\"\r\n";
            }

            if (numUpdateCardValidationNumOnToken != 0)
            {
                xmlHeader += "numUpdateCardValidationNumOnTokens=\"" + numUpdateCardValidationNumOnToken + "\"\r\n";
            }

            xmlHeader += "merchantId=\"" + config["merchantId"] + "\">\r\n";

            string xmlFooter = "</batchRequest>\r\n";

            batchFilePath = litleFileGenerator.createRandomFile(null, litleTime, "_batchRequest.xml");

            using (FileStream fs = new FileStream(batchFilePath, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(xmlHeader);
            }

            using (FileStream fs = new FileStream(batchFilePath, FileMode.Append))
            using (FileStream fsr = new FileStream(tempBatchFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[16];

                int bytesRead = 0;

                do
                {
                    bytesRead = fsr.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, bytesRead);
                }
                while (bytesRead > 0);
            }

            using (FileStream fs = new FileStream(batchFilePath, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(xmlFooter);
            }

            File.Delete(tempBatchFilePath);

            tempBatchFilePath = null;

            return batchFilePath;
        }

        private string saveElement(litleFileGenerator litleFileGenerator, litleTime litleTime, string filePath, transactionType element)
        {
            string fPath;
            fPath = litleFileGenerator.createRandomFile(filePath, litleTime, "_temp_batchRequest.xml");

            using (FileStream fs = new FileStream(fPath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(element.Serialize());
                }
            }

            return fPath;
        }

        private void fillInReportGroup(transactionTypeWithReportGroup txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = config["reportGroup"];
            }
        }

        private void fillInReportGroup(transactionTypeWithReportGroupAndPartial txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = config["reportGroup"];
            }
        }
    }
}
