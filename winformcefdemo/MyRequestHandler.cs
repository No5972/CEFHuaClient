using CefSharp;
using CefSharp.Callback;
using CefSharp.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace CEFHuaClient
{
    public class MyRequestHandler : RequestHandler
    {
        /// <summary>
        /// List&lt;Dictionary&gt;<br/>
        /// 部位-原资源代码-替换资源代码 （部位命名参考DNF）<br/><br/>
        /// 上衣 coat <br/>
        /// 下装 pants <br/>
        /// 头发 hair <br/>
        /// 腰带 belt <br/>
        /// 鞋子 shoes <br/>
        /// 翅膀 wings <br/>
        /// <br/>
        /// 帽子 cap <br/>
        /// 脸部 face <br/>
        /// 手部 hand <br/>
        /// 道具 item <br/>
        /// 足部 feet <br/>
        /// 项链 neck <br/>
        /// 耳环 earring <br/>
        /// <br/>
        /// 眼睛 eyes <br/>
        /// 眉毛 brow <br/>
        /// 嘴巴 mouth <br/>
        /// <br/>
        /// 
        /// <code>[
        ///     { 'part': 'coat', 'original': '1400152', 'replace': '1400473' },
        ///     { 'part': 'pants', 'original': '1400153', 'replace': '1400474' },
        ///     ...
        /// ]</code>
        /// </summary>
        public List<Dictionary<string, string>> dict = new List<Dictionary<string, string>>();

        public string bgResourceName = "";

        public delegate void InterceptedAnIcon(string iconId);

        public InterceptedAnIcon interceptedAnIcon;

        void interceptedAnIcon1(string iconId)
        {
            this.interceptedAnIcon(iconId);
        }


        protected override bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture,
            bool isRedirect)
        {
            // 先调用基类的实现，断点调试
            return base.OnBeforeBrowse(chromiumWebBrowser, browser, frame, request, userGesture, isRedirect);
        }

        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame,
            IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            MyResourceRequestHandler resourceRequestHandler = new MyResourceRequestHandler(dict, this.bgResourceName);
            resourceRequestHandler.interceptedAnIcon = new MyResourceRequestHandler.InterceptedAnIcon(this.interceptedAnIcon1);
            // 先调用基类的实现，断点调试
            return resourceRequestHandler;
        }
    }

    class MyResourceRequestHandler : ResourceRequestHandler
    {
        private List<Dictionary<string, string>> dict;

        public string bgResourceName = "";

        public delegate void InterceptedAnIcon(string iconId);

        public InterceptedAnIcon interceptedAnIcon;

        public MyResourceRequestHandler(List<Dictionary<string, string>> dict)
        {
            this.dict = dict;
        }

        public MyResourceRequestHandler(List<Dictionary<string, string>> dict, string bgResourceName)
        {
            this.dict = dict;
            this.bgResourceName = bgResourceName;
        }

        public MyResourceRequestHandler(string bgResourceName)
        {
            this.bgResourceName = bgResourceName;
        }

        protected override IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            if (request.Url.Contains("/cloth/icon/"))
            {
                this.interceptedAnIcon(request.Url);
            }

            foreach (Dictionary<string, string> x in this.dict)
            {
                x.TryGetValue("part", out string part);
                x.TryGetValue("original", out string original);
                x.TryGetValue("replace", out string replace);
                switch (part)
                {
                    case "coat":
                    case "pants":
                    case "hair":
                    case "belt":
                    case "shoes":
                    case "wings":

                    case "cap":
                    case "face":
                    case "hand":
                    case "item":
                    case "feet":
                    case "neck":
                    case "earring":

                    case "eyes":
                    case "brow":
                    case "mouth":

                        if (request.Url.Contains(original) &&
                           (request.Url.Contains("cloth/swf/left/") ||
                            request.Url.Contains("cloth/swf/right/") ||
                            request.Url.Contains("cloth/swf/body/") ||
                            request.Url.Contains("cloth/swf/face/") ||
                            request.Url.Contains("cloth/swf/back/") ||
                            request.Url.Contains("cloth/swf/leftSteeve/") ||
                            request.Url.Contains("cloth/swf/rightSteeve/") ||
                            request.Url.Contains("cloth/swf/leftTrouser/") ||
                            request.Url.Contains("cloth/swf/rightTrouser/")))
                        {
                            // MessageBox.Show($@"资源拦截：{request.Url}");

                            string type = request.Url.EndsWith(".js") ? "js" : "css"; // 这里简单判断js还是css，不过多编写
                            string fileName = request.Url.Replace(original + ".swf", replace + ".swf");

                            if (string.IsNullOrWhiteSpace(fileName))
                            {
                                // 没有选择文件，还是走默认的Handler
                                return base.GetResourceHandler(chromiumWebBrowser, browser, frame, request);
                            }
                            // 否则使用选择的资源返回
                            return new MyResourceHandler(fileName);
                        }
                        break;

                    default:
                        break;
                }
            }

            if (request.Url.Contains("cloth/swf/bg/")) // 自定义背景
            {
                if (string.IsNullOrWhiteSpace(this.bgResourceName)) 
                {
                    return base.GetResourceHandler(chromiumWebBrowser, browser, frame, request);
                }
                else
                {
                    return new MyResourceHandler(this.bgResourceName, true);
                }
            }




            return base.GetResourceHandler(chromiumWebBrowser, browser, frame, request);
        }
    }

    class MyResourceHandler : IResourceHandler
    {
        private readonly string _localResourceFileName;
        private readonly string _embedResourceName;
        private readonly bool _isUsingEmbedResource;
        private byte[] _localResourceData;
        private int _dataReadCount;

        public MyResourceHandler(string localResourceFileName)
        {
            this._isUsingEmbedResource = false;
            this._localResourceFileName = localResourceFileName;
            this._dataReadCount = 0;
        }

        public MyResourceHandler(string embedResourceName, bool isUsingEmbedResource)
        {
            this._embedResourceName = embedResourceName;
            this._isUsingEmbedResource = isUsingEmbedResource;
        }

        public void Dispose()
        {

        }

        public bool Open(IRequest request, out bool handleRequest, ICallback callback)
        {
            handleRequest = true;
            return true;
        }

        public bool ProcessRequest(IRequest request, ICallback callback)
        {
            throw new NotImplementedException();
        }

        public void GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl)
        {
            if (_isUsingEmbedResource)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                System.IO.Stream stream = assembly.GetManifestResourceStream("winformcefdemo.Resources." + this._embedResourceName);
                long length = stream.Length;
                this._localResourceData = new byte[length];
                new BinaryReader(stream).Read(this._localResourceData, 0, this._localResourceData.Length);
                responseLength = 0;
                redirectUrl = null;
                return;
            }
            responseLength = this.GetHttpLength(_localResourceFileName);
            redirectUrl = _localResourceFileName;
        }

        public bool Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback)
        {
            throw new NotImplementedException();
        }

        public bool Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback)
        {
            int leftToRead = this._localResourceData.Length - this._dataReadCount;
            if (leftToRead == 0)
            {
                bytesRead = 0;
                return false;
            }

            int needRead = Math.Min((int)dataOut.Length, leftToRead);
            dataOut.Write(this._localResourceData, this._dataReadCount, needRead);
            this._dataReadCount += needRead;
            bytesRead = needRead;
            return true;
        }

        public bool ReadResponse(Stream dataOut, out int bytesRead, ICallback callback)
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {

        }

        private long GetHttpLength(string url)
        {
            var length = 0l;
            try
            {
                var req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Method = "HEAD";
                req.Timeout = 5000;
                var res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    length = res.ContentLength;
                }

                res.Close();
                return length;
            }
            catch (WebException wex)
            {
                return 0;
            }
        }
    }
}