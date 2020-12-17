using CefSharp;
using CefSharp.Callback;
using CefSharp.DevTools;
using CefSharp.DevTools.Accessibility;
using CefSharp.DevTools.Animation;
using CefSharp.DevTools.ApplicationCache;
using CefSharp.DevTools.Audits;
using CefSharp.DevTools.BackgroundService;
using CefSharp.DevTools.Browser;
using CefSharp.DevTools.CacheStorage;
using CefSharp.DevTools.Cast;
using CefSharp.DevTools.CSS;
using CefSharp.DevTools.Database;
using CefSharp.DevTools.Debugger;
using CefSharp.DevTools.DeviceOrientation;
using CefSharp.DevTools.DOM;
using CefSharp.DevTools.DOMDebugger;
using CefSharp.DevTools.DOMSnapshot;
using CefSharp.DevTools.DOMStorage;
using CefSharp.DevTools.Emulation;
using CefSharp.DevTools.Fetch;
using CefSharp.DevTools.HeadlessExperimental;
using CefSharp.DevTools.HeapProfiler;
using CefSharp.DevTools.IndexedDB;
using CefSharp.DevTools.Input;
using CefSharp.DevTools.Inspector;
using CefSharp.DevTools.IO;
using CefSharp.DevTools.LayerTree;
using CefSharp.DevTools.Log;
using CefSharp.DevTools.Media;
using CefSharp.DevTools.Memory;
using CefSharp.DevTools.Network;
using CefSharp.DevTools.Overlay;
using CefSharp.DevTools.Page;
using CefSharp.DevTools.Performance;
using CefSharp.DevTools.Profiler;
using CefSharp.DevTools.Runtime;
using CefSharp.DevTools.Security;
using CefSharp.DevTools.ServiceWorker;
using CefSharp.DevTools.Storage;
using CefSharp.DevTools.SystemInfo;
using CefSharp.DevTools.Target;
using CefSharp.DevTools.Tethering;
using CefSharp.DevTools.Tracing;
using CefSharp.DevTools.WebAudio;
using CefSharp.DevTools.WebAuthn;
using CefSharp.Internals;
using CefSharp.Internals.Tasks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CEFHuaClient.CefSharp.Example
{
	/// <summary>
	/// DevTool Client 
	/// </summary>
	/// <summary>
	/// Generated DevToolsClient methods
	/// </summary>
	public class DevToolsClientEx : DevToolsClient
	{
		private readonly ConcurrentDictionary<int, SyncContextTaskCompletionSource<DevToolsMethodResponse>> queuedCommandResults = new ConcurrentDictionary<int, SyncContextTaskCompletionSource<DevToolsMethodResponse>>();

		private int lastMessageId;

		private IBrowser browser;

		private IRegistration devToolsRegistration;

		private bool devToolsAttached;

		private SynchronizationContext syncContext;

		/// <summary>
		/// DevToolsEvent
		/// </summary>
		public EventHandler<DevToolsEventArgs> DevToolsEvent;

		private AccessibilityClient _Accessibility;

		private AnimationClient _Animation;

		private ApplicationCacheClient _ApplicationCache;

		private AuditsClient _Audits;

		private BackgroundServiceClient _BackgroundService;

		private BrowserClient _Browser;

		private CSSClient _CSS;

		private CacheStorageClient _CacheStorage;

		private CastClient _Cast;

		private DOMClient _DOM;

		private DOMDebuggerClient _DOMDebugger;

		private DOMSnapshotClient _DOMSnapshot;

		private DOMStorageClient _DOMStorage;

		private DatabaseClient _Database;

		private DeviceOrientationClient _DeviceOrientation;

		private EmulationClient _Emulation;

		private HeadlessExperimentalClient _HeadlessExperimental;

		private IOClient _IO;

		private IndexedDBClient _IndexedDB;

		private InputClient _Input;

		private InspectorClient _Inspector;

		private LayerTreeClient _LayerTree;

		private LogClient _Log;

		private MemoryClient _Memory;

		private NetworkClient _Network;

		private OverlayClient _Overlay;

		private PageClient _Page;

		private PerformanceClient _Performance;

		private SecurityClient _Security;

		private ServiceWorkerClient _ServiceWorker;

		private StorageClient _Storage;

		private SystemInfoClient _SystemInfo;

		private TargetClient _Target;

		private TetheringClient _Tethering;

		private TracingClient _Tracing;

		private FetchClient _Fetch;

		private WebAudioClient _WebAudio;

		private WebAuthnClient _WebAuthn;

		private MediaClient _Media;

		private DebuggerClient _Debugger;

		private HeapProfilerClient _HeapProfiler;

		private ProfilerClient _Profiler;

		private RuntimeClient _Runtime;

		/// <summary>
		/// Capture the current <see cref="T:System.Threading.SynchronizationContext" /> so
		/// continuation executes on the original calling thread. If
		/// <see cref="P:System.Threading.SynchronizationContext.Current" /> is null for
		/// <see cref="M:CefSharp.DevTools.DevToolsClient.ExecuteDevToolsMethodAsync(System.String,System.Collections.Generic.IDictionary{System.String,System.Object})" />
		/// then the continuation will be run on the CEF UI Thread (by default
		/// this is not the same as the WPF/WinForms UI Thread).
		/// </summary>
		public bool CaptureSyncContext
		{
			get;
			set;
		}

		/// <summary>
		/// When not null provided <see cref="T:System.Threading.SynchronizationContext" />
		/// will be used to run the contination. Defaults to null
		/// Setting this property will change <see cref="P:CefSharp.DevTools.DevToolsClient.CaptureSyncContext" />
		/// to false.
		/// </summary>
		public SynchronizationContext SyncContext
		{
			get
			{
				return this.syncContext;
			}
			set
			{
				this.CaptureSyncContext = false;
				this.syncContext = value;
			}
		}

		public AccessibilityClient Accessibility
		{
			get
			{
				if (this._Accessibility == null)
				{
					this._Accessibility = new AccessibilityClient(this);
				}
				return this._Accessibility;
			}
		}

		public AnimationClient Animation
		{
			get
			{
				if (this._Animation == null)
				{
					this._Animation = new AnimationClient(this);
				}
				return this._Animation;
			}
		}

		public ApplicationCacheClient ApplicationCache
		{
			get
			{
				if (this._ApplicationCache == null)
				{
					this._ApplicationCache = new ApplicationCacheClient(this);
				}
				return this._ApplicationCache;
			}
		}

		public AuditsClient Audits
		{
			get
			{
				if (this._Audits == null)
				{
					this._Audits = new AuditsClient(this);
				}
				return this._Audits;
			}
		}

		public BackgroundServiceClient BackgroundService
		{
			get
			{
				if (this._BackgroundService == null)
				{
					this._BackgroundService = new BackgroundServiceClient(this);
				}
				return this._BackgroundService;
			}
		}

		public BrowserClient Browser
		{
			get
			{
				if (this._Browser == null)
				{
					this._Browser = new BrowserClient(this);
				}
				return this._Browser;
			}
		}

		public CSSClient CSS
		{
			get
			{
				if (this._CSS == null)
				{
					this._CSS = new CSSClient(this);
				}
				return this._CSS;
			}
		}

		public CacheStorageClient CacheStorage
		{
			get
			{
				if (this._CacheStorage == null)
				{
					this._CacheStorage = new CacheStorageClient(this);
				}
				return this._CacheStorage;
			}
		}

		public CastClient Cast
		{
			get
			{
				if (this._Cast == null)
				{
					this._Cast = new CastClient(this);
				}
				return this._Cast;
			}
		}

		public DOMClient DOM
		{
			get
			{
				if (this._DOM == null)
				{
					this._DOM = new DOMClient(this);
				}
				return this._DOM;
			}
		}

		public DOMDebuggerClient DOMDebugger
		{
			get
			{
				if (this._DOMDebugger == null)
				{
					this._DOMDebugger = new DOMDebuggerClient(this);
				}
				return this._DOMDebugger;
			}
		}

		public DOMSnapshotClient DOMSnapshot
		{
			get
			{
				if (this._DOMSnapshot == null)
				{
					this._DOMSnapshot = new DOMSnapshotClient(this);
				}
				return this._DOMSnapshot;
			}
		}

		public DOMStorageClient DOMStorage
		{
			get
			{
				if (this._DOMStorage == null)
				{
					this._DOMStorage = new DOMStorageClient(this);
				}
				return this._DOMStorage;
			}
		}

		public DatabaseClient Database
		{
			get
			{
				if (this._Database == null)
				{
					this._Database = new DatabaseClient(this);
				}
				return this._Database;
			}
		}

		public DeviceOrientationClient DeviceOrientation
		{
			get
			{
				if (this._DeviceOrientation == null)
				{
					this._DeviceOrientation = new DeviceOrientationClient(this);
				}
				return this._DeviceOrientation;
			}
		}

		public EmulationClient Emulation
		{
			get
			{
				if (this._Emulation == null)
				{
					this._Emulation = new EmulationClient(this);
				}
				return this._Emulation;
			}
		}

		public HeadlessExperimentalClient HeadlessExperimental
		{
			get
			{
				if (this._HeadlessExperimental == null)
				{
					this._HeadlessExperimental = new HeadlessExperimentalClient(this);
				}
				return this._HeadlessExperimental;
			}
		}

		public IOClient IO
		{
			get
			{
				if (this._IO == null)
				{
					this._IO = new IOClient(this);
				}
				return this._IO;
			}
		}

		public IndexedDBClient IndexedDB
		{
			get
			{
				if (this._IndexedDB == null)
				{
					this._IndexedDB = new IndexedDBClient(this);
				}
				return this._IndexedDB;
			}
		}

		public InputClient Input
		{
			get
			{
				if (this._Input == null)
				{
					this._Input = new InputClient(this);
				}
				return this._Input;
			}
		}

		public InspectorClient Inspector
		{
			get
			{
				if (this._Inspector == null)
				{
					this._Inspector = new InspectorClient(this);
				}
				return this._Inspector;
			}
		}

		public LayerTreeClient LayerTree
		{
			get
			{
				if (this._LayerTree == null)
				{
					this._LayerTree = new LayerTreeClient(this);
				}
				return this._LayerTree;
			}
		}

		public LogClient Log
		{
			get
			{
				if (this._Log == null)
				{
					this._Log = new LogClient(this);
				}
				return this._Log;
			}
		}

		public MemoryClient Memory
		{
			get
			{
				if (this._Memory == null)
				{
					this._Memory = new MemoryClient(this);
				}
				return this._Memory;
			}
		}

		public NetworkClient Network
		{
			get
			{
				if (this._Network == null)
				{
					this._Network = new NetworkClient(this);
				}
				return this._Network;
			}
		}

		public OverlayClient Overlay
		{
			get
			{
				if (this._Overlay == null)
				{
					this._Overlay = new OverlayClient(this);
				}
				return this._Overlay;
			}
		}

		public PageClient Page
		{
			get
			{
				if (this._Page == null)
				{
					this._Page = new PageClient(this);
				}
				return this._Page;
			}
		}

		public PerformanceClient Performance
		{
			get
			{
				if (this._Performance == null)
				{
					this._Performance = new PerformanceClient(this);
				}
				return this._Performance;
			}
		}

		public SecurityClient Security
		{
			get
			{
				if (this._Security == null)
				{
					this._Security = new SecurityClient(this);
				}
				return this._Security;
			}
		}

		public ServiceWorkerClient ServiceWorker
		{
			get
			{
				if (this._ServiceWorker == null)
				{
					this._ServiceWorker = new ServiceWorkerClient(this);
				}
				return this._ServiceWorker;
			}
		}

		public StorageClient Storage
		{
			get
			{
				if (this._Storage == null)
				{
					this._Storage = new StorageClient(this);
				}
				return this._Storage;
			}
		}

		public SystemInfoClient SystemInfo
		{
			get
			{
				if (this._SystemInfo == null)
				{
					this._SystemInfo = new SystemInfoClient(this);
				}
				return this._SystemInfo;
			}
		}

		public TargetClient Target
		{
			get
			{
				if (this._Target == null)
				{
					this._Target = new TargetClient(this);
				}
				return this._Target;
			}
		}

		public TetheringClient Tethering
		{
			get
			{
				if (this._Tethering == null)
				{
					this._Tethering = new TetheringClient(this);
				}
				return this._Tethering;
			}
		}

		public TracingClient Tracing
		{
			get
			{
				if (this._Tracing == null)
				{
					this._Tracing = new TracingClient(this);
				}
				return this._Tracing;
			}
		}

		public FetchClient Fetch
		{
			get
			{
				if (this._Fetch == null)
				{
					this._Fetch = new FetchClient(this);
				}
				return this._Fetch;
			}
		}

		public WebAudioClient WebAudio
		{
			get
			{
				if (this._WebAudio == null)
				{
					this._WebAudio = new WebAudioClient(this);
				}
				return this._WebAudio;
			}
		}

		public WebAuthnClient WebAuthn
		{
			get
			{
				if (this._WebAuthn == null)
				{
					this._WebAuthn = new WebAuthnClient(this);
				}
				return this._WebAuthn;
			}
		}

		public MediaClient Media
		{
			get
			{
				if (this._Media == null)
				{
					this._Media = new MediaClient(this);
				}
				return this._Media;
			}
		}

		public DebuggerClient Debugger
		{
			get
			{
				if (this._Debugger == null)
				{
					this._Debugger = new DebuggerClient(this);
				}
				return this._Debugger;
			}
		}

		public HeapProfilerClient HeapProfiler
		{
			get
			{
				if (this._HeapProfiler == null)
				{
					this._HeapProfiler = new HeapProfilerClient(this);
				}
				return this._HeapProfiler;
			}
		}

		public ProfilerClient Profiler
		{
			get
			{
				if (this._Profiler == null)
				{
					this._Profiler = new ProfilerClient(this);
				}
				return this._Profiler;
			}
		}

		public RuntimeClient Runtime
		{
			get
			{
				if (this._Runtime == null)
				{
					this._Runtime = new RuntimeClient(this);
				}
				return this._Runtime;
			}
		}

		/// <summary>
		/// DevToolsClient
		/// </summary>
		/// <param name="browser">Browser associated with this DevTools client</param>
		public DevToolsClientEx(IBrowser browser) : base (browser)
		{
			this.browser = browser;
			this.lastMessageId = browser.Identifier * 100000;
			this.CaptureSyncContext = true;
		}

		/// <summary>
		/// Store a reference to the IRegistration that's returned when
		/// you register an observer.
		/// </summary>
		/// <param name="devToolsRegistration">registration</param>
		public void SetDevToolsObserverRegistration(IRegistration devToolsRegistration)
		{
			this.devToolsRegistration = devToolsRegistration;
		}

		public DevToolsMethodResponse ExecuteDevToolsMethod(string method, IDictionary<string, object> parameters = null)
        {
			DevToolsMethodResponse result;
			if (this.browser == null || this.browser.IsDisposed)
			{
				result = new DevToolsMethodResponse
				{
					Success = false
				};
			}
			else
			{
				int messageId = Interlocked.Increment(ref this.lastMessageId);
				SyncContextTaskCompletionSource<DevToolsMethodResponse> syncContextTaskCompletionSource = new SyncContextTaskCompletionSource<DevToolsMethodResponse>();
				syncContextTaskCompletionSource.SyncContext = (this.CaptureSyncContext ? SynchronizationContext.Current : this.syncContext);
				if (!this.queuedCommandResults.TryAdd(messageId, syncContextTaskCompletionSource))
				{
					throw new DevToolsClientException(string.Format("Unable to add MessageId {0} to queuedCommandResults ConcurrentDictionary.", messageId));
				}
				IBrowserHost browserHost = this.browser.GetHost();
				if (CefThread.CurrentlyOnUiThread)
				{
					int num = browserHost.ExecuteDevToolsMethod(messageId, method, parameters);
					if (num == 0)
					{
						result = new DevToolsMethodResponse
						{
							Success = false
						};
						return result;
					}
					if (num != messageId)
					{
						throw new DevToolsClientException(string.Format("Generated MessageId {0} doesn't match returned Message Id {1}", num, messageId));
					}
				}
				else
				{
					if (!CefThread.CanExecuteOnUiThread)
					{
						throw new DevToolsClientException("Unable to invoke ExecuteDevToolsMethod on CEF UI Thread.");
					}
					int num2 = browserHost.ExecuteDevToolsMethod(messageId, method, parameters);
					if (num2 == 0)
					{
						result = new DevToolsMethodResponse
						{
							Success = false
						};
						return result;
					}
					if (num2 != messageId)
					{
						// throw new DevToolsClientException(string.Format("1Generated MessageId {0} doesn't match returned Message Id {1}", num2, messageId));
					}
				}
				result = syncContextTaskCompletionSource.Task.Result;
			}
			return result;
		}

		/// <summary>
		/// Execute a method call over the DevTools protocol. This method can be called on any thread.
		/// See the DevTools protocol documentation at https://chromedevtools.github.io/devtools-protocol/ for details
		/// of supported methods and the expected <paramref name="parameters" /> dictionary contents.
		/// </summary>
		/// <param name="method">is the method name</param>
		/// <param name="parameters">are the method parameters represented as a dictionary,
		/// which may be empty.</param>
		/// <returns>return a Task that can be awaited to obtain the method result</returns>
		public new async Task<DevToolsMethodResponse> ExecuteDevToolsMethodAsync(string method, IDictionary<string, object> parameters = null)
		{
			DevToolsMethodResponse result;
			if (this.browser == null || this.browser.IsDisposed)
			{
				result = new DevToolsMethodResponse
				{
					Success = false
				};
			}
			else
			{
				int messageId = Interlocked.Increment(ref this.lastMessageId);
				SyncContextTaskCompletionSource<DevToolsMethodResponse> syncContextTaskCompletionSource = new SyncContextTaskCompletionSource<DevToolsMethodResponse>();
				syncContextTaskCompletionSource.SyncContext = (this.CaptureSyncContext ? SynchronizationContext.Current : this.syncContext);
				if (!this.queuedCommandResults.TryAdd(messageId, syncContextTaskCompletionSource))
				{
					throw new DevToolsClientException(string.Format("Unable to add MessageId {0} to queuedCommandResults ConcurrentDictionary.", messageId));
				}
				IBrowserHost browserHost = this.browser.GetHost();
				if (CefThread.CurrentlyOnUiThread)
				{
					int num = browserHost.ExecuteDevToolsMethod(messageId, method, parameters);
					if (num == 0)
					{
						result = new DevToolsMethodResponse
						{
							Success = false
						};
						return result;
					}
					if (num != messageId)
					{
						throw new DevToolsClientException(string.Format("Generated MessageId {0} doesn't match returned Message Id {1}", num, messageId));
					}
				}
				else
				{
					if (!CefThread.CanExecuteOnUiThread)
					{
						throw new DevToolsClientException("Unable to invoke ExecuteDevToolsMethod on CEF UI Thread.");
					}
					int num2 = await CefThread.ExecuteOnUiThread<int>(() => browserHost.ExecuteDevToolsMethod(messageId, method, parameters)).ConfigureAwait(false);
					if (num2 == 0)
					{
						result = new DevToolsMethodResponse
						{
							Success = false
						};
						return result;
					}
					if (num2 != messageId)
					{
						// throw new DevToolsClientException(string.Format("1Generated MessageId {0} doesn't match returned Message Id {1}", num2, messageId));
					}
				}
				result = await syncContextTaskCompletionSource.Task;
			}
			return result;
		}

		

        
    }
}
