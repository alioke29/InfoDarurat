(function(self, ns){
    var GENERIC_BUNDLE_URL = "https://fast.appcues.com/generic/main/4.24.6/appcues.main.413ca542c319c3e847e8236a3fd94ffe1d978277.js";
    var ACCOUNT_DETAILS = {"GENERIC_BUNDLE_DOMAIN":"https://fast.appcues.com","GENERIC_BUNDLE_PATH":"/generic/main/4.24.6/appcues.main.413ca542c319c3e847e8236a3fd94ffe1d978277.js","RELEASE_ID":"413ca542c319c3e847e8236a3fd94ffe1d978277","VERSION":"4.24.6","account":{"buffer":0,"isTrial":true,"isTrialExpired":true,"stripePlanId":""},"accountId":"87116","custom_events":[],"integrations":null,"styling":{"globalBeaconColor":"#1fb6ff","globalBeaconStyle":"hotspot","globalHotspotAnimation":"hotspot-animation-pulse","globalHotspotStyling":"","globalStyling":"\n@import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i');\n\n\n@import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i');\n\n\n.appcues-actions-right > .appcues-button.appcues-button-success, .appcues-progress-bar-success {\n    background-color: #60d2c9;\n}\n.appcues-actions-right > .appcues-button.appcues-button-success:hover {\n    background-color: #7cdad2;\n}\n\n\n.appcues-actions-right .appcues-button {\n    color: #ffffff;\n}\n\n\n.appcues-actions-right .appcues-button:hover {\n    color: #ffffff !important;\n}\n\n\n.appcues-actions-left >  .appcues-button {\n    background-color: #E5E5E5;\n}\n.appcues-actions-left > .appcues-button:hover {\n    background-color: #f7f7f7;\n}\n\n\n.appcues-actions-left .appcues-button {\n    color: #555555;\n}\n\n\n.appcues-actions-left .appcues-button:hover {\n    color: #555555 !important;\n}\n\n\n.appcues-actions-right .appcues-button, .appcues-actions-left .appcues-button {\n    border-radius: 1000px;\n}\n\n\nbody, appcues cue, .tooltip .content {\n    font-family: 'Open Sans', sans-serif;\n}\n\n\nbody h1, body h2, body h3, body h4, body h5,\nappcues cue h1, appcues cue h2, appcues cue h3, appcues cue h4, appcues cue h5,\n.tooltip .content h1, .tooltip .content h2, .tooltip .content h3, .tooltip .content h4, .tooltip .content h5 {\n    font-family: 'Open Sans', sans-serif;\n}\n\n\n  body, appcues cue, .tooltip .content {\n      color: #0c1014;\n  }\n  \n\n.tooltip .content .panel {\n  background-color: #ffffff;\n  border-color: #ffffff;\n}\n\n.tooltip .content .panel:before, .tooltip .content .panel:after {\n  height: 13px;\n  width: 13px;\n  background-color: #ffffff;\n  border-radius: 2px;\n  border: none;\n  transform: rotate(45deg);\n}\n\n.tooltip .content .panel:after {\n  position: absolute;\n  content: \"\";\n  z-index: -1;\n}\n\n.tooltip .content.content-top .panel:before, .tooltip .content.content-top .panel:after {\n  margin-left: -7px;\n}\n\n.tooltip .content.content-top .panel:before,\n.tooltip .content.content-top .panel:after,\n.tooltip .content.content-top-left .panel:before,\n.tooltip .content.content-top-left .panel:after,\n.tooltip .content.content-top-right .panel:before,\n.tooltip .content.content-top-right .panel:after {\n  margin-top: -6px;\n}\n\n.tooltip .content.content-bottom .panel:before, .tooltip .content.content-bottom .panel:after {\n  margin-left: -7px;\n}\n\n.tooltip .content.content-bottom .panel:before,\n.tooltip .content.content-bottom .panel:after,\n.tooltip .content.content-bottom-left .panel:before,\n.tooltip .content.content-bottom-left .panel:after,\n.tooltip .content.content-bottom-right .panel:before,\n.tooltip .content.content-bottom-right .panel:after {\n  margin-bottom: -6px;\n}\n\n.tooltip .content.content-right .panel:before, .tooltip .content.content-right .panel:after {\n  margin-top: -7px;\n}\n\n.tooltip .content.content-right .panel:before,\n.tooltip .content.content-right .panel:after,\n.tooltip .content.content-right-top .panel:before,\n.tooltip .content.content-right-top .panel:after,\n.tooltip .content.content-right-bottom .panel:before,\n.tooltip .content.content-right-bottom .panel:after {\n  margin-right: -6px;\n}\n\n.tooltip .content.content-left .panel:before, .tooltip .content.content-left .panel:after {\n  margin-top: -7px;\n}\n\n.tooltip .content.content-left .panel:before,\n.tooltip .content.content-left .panel:after,\n.tooltip .content.content-left-top .panel:before,\n.tooltip .content.content-left-top .panel:after,\n.tooltip .content.content-left-bottom .panel:before,\n.tooltip .content.content-left-bottom .panel:after {\n  margin-left: -6px;\n}\n\n.tooltip .content.content-top-left .panel:before,\n.tooltip .content.content-top-left .panel:after,\n.tooltip .content.content-bottom-left .panel:before,\n.tooltip .content.content-bottom-left .panel:after {\n  right: 10px;\n}\n\n.tooltip .content.content-top-right.panel:before,\n.tooltip .content.content-top-right .panel:after,\n.tooltip .content.content-bottom-right .panel:before,\n.tooltip .content.content-bottom-right .panel:after {\n  left: 10px;\n}\n\n.tooltip .content.content-right-bottom .panel:before,\n.tooltip .content.content-right-bottom .panel:after,\n.tooltip .content.content-left-bottom .panel:before,\n.tooltip .content.content-left-bottom .panel:after {\n  top: 10px;\n}\n\n.tooltip .content.content-right-top.panel:before,\n.tooltip .content.content-right-top .panel:after,\n.tooltip .content.content-left-top .panel:before,\n.tooltip .content.content-left-top .panel:after {\n  bottom: 10px;\n}\n\n.tooltip .content.content-top .panel:after {\n  left: 50%;\n}\n\n.tooltip .content.content-top .panel:after,\n.tooltip .content.content-top-left .panel:after,\n.tooltip .content.content-top-right .panel:after {\n  top: 100%;\n}\n\n.tooltip .content.content-bottom .panel:after {\n  left: 50%;\n}\n\n.tooltip .content.content-bottom .panel:after,\n.tooltip .content.content-bottom-left .panel:after,\n.tooltip .content.content-bottom-right .panel:after {\n  bottom: 100%;\n}\n\n.tooltip .content.content-right .panel:after {\n  top: 50%;\n}\n\n.tooltip .content.content-right .panel:after,\n.tooltip .content.content-right-top .panel:after,\n.tooltip .content.content-right-bottom .panel:after {\n  right: 100%;\n}\n\n.tooltip .content.content-left .panel:after {\n  top: 50%;\n}\n\n.tooltip .content.content-left .panel:after,\n.tooltip .content.content-left-top .panel:after,\n.tooltip .content.content-left-bottom .panel:after {\n  left: 100%;\n}\n\n\n.tooltip .content .panel {\n  color: #0c1014;\n}\n\n.tooltip h1, .tooltip h2, .tooltip h3, .tooltip h4, .tooltip h5 {\ncolor: #0c1014;\n}\n\n  .panel.panel-default {\n    margin-right: 3px;\n    margin-bottom: 2px;\n    border-radius: 5px;\n  }\n  \n\n  .panel.panel-default, .content .panel:after {\n    box-shadow: 1px 1px 2px hsla(0,0%,13%,.6);\n  }\n  \n\n      .appcues-backdrop[data-pattern-type=left], .appcues-backdrop[data-pattern-type=shorty], .appcues-backdrop[data-pattern-type=modal] {\n        background-color: #2a3440;\n      }\n      \n\n      .appcues-backdrop[data-pattern-type=left], .appcues-backdrop[data-pattern-type=shorty], .appcues-backdrop[data-pattern-type=modal] {\n        opacity: 0.75;\n      }\n      \n\nappcues cue {\n    background: #ffffff\n}\n\n\nappcues cue * {\n    color: #0c1014\n}\n\n@font-face {\n  font-family: 'Graphik';\n  src: url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Semibold.woff2')\n      format('woff2'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Semibold.eot')\n      format('embedded-opentype'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Semibold.woff')\n      format('woff');\n  font-weight: 600;\n  font-style: normal;\n  font-display: swap;\n}\n\n@font-face {\n  font-family: 'Graphik';\n  src: url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Medium-Web.woff2')\n      format('woff2'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Medium-Web.eot')\n      format('embedded-opentype'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Medium-Web.woff')\n      format('woff');\n  font-weight: 500;\n  font-style: normal;\n  font-display: swap;\n}\n\n@font-face {\n  font-family: 'Graphik';\n  src: url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.woff2')\n      format('woff2'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.eot')\n      format('embedded-opentype'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.woff')\n      format('woff');\n  font-weight: 400;\n  font-style: normal;\n  font-display: swap;\n}\n\n@font-face {\n  font-family: 'Graphik';\n  src: url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.woff2')\n      format('woff2'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.eot')\n      format('embedded-opentype'),\n    url('https://s3.eu-west-2.amazonaws.com/marvelapp-styleguide/fonts/00.+Graphik-Regular-Web.woff')\n      format('woff');\n  font-weight: 300;\n  font-style: normal;\n  font-display: swap;\n}\n\nappcues cue  {\n  font-family: \"Graphik\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Helvetica, Arial, sans-serif !important;\n}\n\n/* CHANGE FONTS */\n.html .title {\n    font-size: 16px;\n    font-weight: 500;\n    color: #0C1014;\n    font-family: \"Graphik\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Helvetica, Arial, sans-serif;\n}\n\n.html .subtitle {\n    font-size: 14px;\n    color: #222D39;\n    margin-top: 6px;\n    font-family: \"Graphik\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Helvetica, Arial, sans-serif;\n}\n\nappcues cue {\n  padding: 20px 20px 60px 20px;\n}\n\nappcues cue .appcues-actions {\n  padding: 5px 20px 20px 20px;\n}\n\n/* ADJUST MODALS */\nappcues cue .apc-hero {\n    border-top-left-radius: 10px;\n    border-top-right-radius: 10px;\n}\n\nappcues cue {\n    border-radius: 10px;\n    min-height: auto;\n}\n\nmodal.container-fullscreen, modal.container, .appcues-progress, .appcues-skip, .active {\n    box-shadow: none;\n}\n\n.appcues-skip >a {\n    border-top-right-radius: 10px;\n}\n\n/* Center Modal */\n\nappcues[data-pattern-type=modal] {\n    padding-top: 20%;\n}\n\n/* To make modals slightly narrower */\nappcues[data-pattern-type=modal] > cue, appcues[data-pattern-type=modal] > div {\n    width: 310px;\n    min-width: 310px;\n}\n\n/* To make slideouts slightly narrower */\nappcues[data-pattern-type=shorty] modal-container {\n    width: 310px;\n    min-width: 310px;\n}\n\n// TOOLTIPS\n\n.panel {\n    padding: 10px;\n}\n\n.panel.panel-default {\n    border-radius: 10px;\n}\n\n.panel .panel-content {\n    padding: 10px;\n}\n\n.panel .panel-content .image {\n  border-radius: 5px;\n}\n\n.tooltip .content .panel:after {\n    box-shadow: none;\n    border: none;\n}\n\n\n\n\n\n    appcues .appcues-actions-right .appcues-button { padding-right: 18px; }\n    appcues .appcues-actions-right .appcues-button:after { content: none; }\n    appcues .appcues-actions-left .appcues-button { padding-left: 18px; }\n    appcues .appcues-actions-left .appcues-button:before { content: none; }","id":"-MT1dYDrFEehkhZ4sCqP","typekitId":""}};
    var VERSION = ACCOUNT_DETAILS.VERSION;
    var RELEASE_ID = ACCOUNT_DETAILS.RELEASE_ID;
    var GENERIC_BUNDLE_DOMAIN = ACCOUNT_DETAILS.GENERIC_BUNDLE_DOMAIN;
    var accountId = ACCOUNT_DETAILS.accountId;
    var isBootstrapped = false;

    self.AppcuesBundleSettings = {
      accountId: accountId,
      VERSION: VERSION,
      RELEASE_ID: RELEASE_ID,
      GENERIC_BUNDLE_DOMAIN: GENERIC_BUNDLE_DOMAIN,
      GENERIC_BUNDLE_PATH: ACCOUNT_DETAILS.GENERIC_BUNDLE_PATH,
      styling:  ACCOUNT_DETAILS.styling,
      integrations: ACCOUNT_DETAILS.integrations,
      account: ACCOUNT_DETAILS.account,
      events: ACCOUNT_DETAILS.custom_events
    };

    var skipAMD = false;
    var windowGlobals = window["AppcuesSettings"];
    if (
      windowGlobals &&
      typeof windowGlobals === "object" &&
      windowGlobals.skipAMD === true
    ) {
      skipAMD = true;
    }

    var doc = self.document;
    self[ns] = self[ns] || [];
    var Appcues = self[ns];
    if (Appcues.invoked) {
        if (self.console && console.error) {
            console.error('Appcues snippet included twice.');
        }
        return;
    }

    if (Appcues.identify) return;
    Appcues.invoked = true;

    var methods = [
        "identify",
        "track",
        "page",
        "anonymous",
        "start",
        "show",
        "clearShow",
        "on",
        "off",
        "once",
        "reset",
        "debug",
        "user",
        "call",
        "settings",
        "content",
        "initMixpanel",
        "initHeap",
        "initIntercom",
        "initCIO",
        "initWoopra",
        "initAmplitude",
        "initKlaviyo",
        "initTD",
        "initLl",
        "initCalq",
        "initKM",
        "initGA",
        "initGTM",
        "initSegment",
        "injectContent",
        "injectStyles",
        "injectEvents",
        "cancelEvents",
        "loadLaunchpad"
    ];

    var promises = [
        "user"
    ];

    function factory(method){
        return function(){
            var args = Array.prototype.slice.call(arguments);
            if (isBootstrapped) {
              self.Appcues[method].apply(self.Appcues, args);
            } else {
              args.unshift(method);
              Appcues.push(args);
            }
            return self.Appcues;
        };
    }

    // For each of our methods, generate a queueing stub.
    for (var i = 0; i < methods.length; i++) {
        var key = methods[i];
        Appcues[key] = factory(key);
    }

    for (var i = 0; i < promises.length; i++) {
        var key = promises[i];
        Appcues[key] = function() {
          var args = Array.prototype.slice.call(arguments);
          if (isBootstrapped) {
            return self.Appcues[key].apply(self.Appcues, args);
          } else {
            return new Promise(function(resolve, _reject) {
              args.unshift(resolve);
              args.unshift(key);
              Appcues.push(args);
            });
          }
        };
    }

    if (
      !skipAMD &&
      typeof window.define === "function" &&
      window.define.amd &&
      (window.define.amd.vendor == null ||
        window.define.amd.vendor !== "dojotoolkit.org")
    ) {
      window.define(function() { return Appcues; });
    }

    function load(){
        var bundleScript = doc.createElement("script");
        bundleScript.crossOrigin = "anonymous";
        bundleScript.integrity = "sha256-THjLD1EONpss3KqY9CS5Q47ZX+AnFRmQl+08D0ENGiI=";
        bundleScript.type = "text/javascript";
        bundleScript.src = GENERIC_BUNDLE_URL;
        bundleScript.async = true;
        bundleScript.onload = function () {
            isBootstrapped = true;
            Appcues.forEach(function(call) {
                var fnName = call[0];
                var args = call.slice(1);
                if (promises.indexOf(fnName) === -1) {
                  self[ns] && self[ns][fnName] &&
                      self[ns][fnName].apply(self[ns], args);
                } else {
                  var resolve = args[0];
                  var promiseArgs = args.slice(1);
                  self[ns] && self[ns][fnName] &&
                    self[ns][fnName].apply(self[ns], promiseArgs).then(
                      function() { resolve(arguments[0]); }
                    );
                }
            });
        };

        var firstScript = doc.getElementsByTagName('script')[0];
        firstScript.parentNode.insertBefore(bundleScript, firstScript);
    }
    Appcues.SNIPPET_VERSION = VERSION;
    load();
})(window, 'Appcues');
