/*!
 * jQuery JavaScript Library v1.7.1
 * http://jquery.com/
 *
 * Copyright 2011, John Resig
 * Released under the the MIT License.
 * http://jquery.org/license
 *
 * Includes Sizzle.js
 * http://sizzlejs.com/
 * Copyright 2011, The Dojo Foundation
 * Released under the MIT and BSD Licenses.
 *
 * Date: Mon Nov 21 21:11:03 2011 -0500
 */
(function( window, undefined ) {

// Use the correct document accordingly with window argument (sandbox)
var document = window.document,
	navigator = window.navigator,
	location = window.location;
var jQuery = (function() {

// Define a local copy of jQuery
var jQuery = function( selector, context ) {
		// The jQuery object is actually just the init constructor 'enhanced'
		return new jQuery.fn.init( selector, context, rootjQuery );
	},

	// Map over jQuery in case of overwrite
	_jQuery = window.jQuery,

	// Map over the $ in case of overwrite
	_$ = window.$,

	// A central reference to the root jQuery(document)
	rootjQuery,

	// A simple way to check for HTML strings or ID strings
	// Prioritize #id over <tag> to avoid XSS via location.hash (#9521)
	quickExpr = /^(?:[^#<]*(<[\w\W]+>)[^>]*$|#([\w\-]*)$)/,

	// Check if a string has a non-whitespace character in it
	rnotwhite = /\S/,

	// Used for trimming whitespace
	trimLeft = /^\s+/,
	trimRight = /\s+$/,

	// Match a standalone tag
	rsingleTag = /^<(\w+)\s*\/?>(?:<\/\1>)?$/,

	// JSON RegExp
	rvalidchars = /^[\],:{}\s]*$/,
	rvalidescape = /\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,
	rvalidtokens = /"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,
	rvalidbraces = /(?:^|:|,)(?:\s*\[)+/g,

	// Useragent RegExp
	rwebkit = /(webkit)[ \/]([\w.]+)/,
	ropera = /(opera)(?:.*version)?[ \/]([\w.]+)/,
	rmsie = /(msie) ([\w.]+)/,
	rmozilla = /(mozilla)(?:.*? rv:([\w.]+))?/,

	// Matches dashed string for camelizing
	rdashAlpha = /-([a-z]|[0-9])/ig,
	rmsPrefix = /^-ms-/,

	// Used by jQuery.camelCase as callback to replace()
	fcamelCase = function( all, letter ) {
		return ( letter + "" ).toUpperCase();
	},

	// Keep a UserAgent string for use with jQuery.browser
	userAgent = navigator.userAgent,

	// For matching the engine and version of the browser
	browserMatch,

	// The deferred used on DOM ready
	readyList,

	// The ready event handler
	DOMContentLoaded,

	// Save a reference to some core methods
	toString = Object.prototype.toString,
	hasOwn = Object.prototype.hasOwnProperty,
	push = Array.prototype.push,
	slice = Array.prototype.slice,
	trim = String.prototype.trim,
	indexOf = Array.prototype.indexOf,

	// [[Class]] -> type pairs
	class2type = {};

jQuery.fn = jQuery.prototype = {
	constructor: jQuery,
	init: function( selector, context, rootjQuery ) {
		var match, elem, ret, doc;

		// Handle $(""), $(null), or $(undefined)
		if ( !selector ) {
			return this;
		}

		// Handle $(DOMElement)
		if ( selector.nodeType ) {
			this.context = this[0] = selector;
			this.length = 1;
			return this;
		}

		// The body element only exists once, optimize finding it
		if ( selector === "body" && !context && document.body ) {
			this.context = document;
			this[0] = document.body;
			this.selector = selector;
			this.length = 1;
			return this;
		}

		// Handle HTML strings
		if ( typeof selector === "string" ) {
			// Are we dealing with HTML string or an ID?
			if ( selector.charAt(0) === "<" && selector.charAt( selector.length - 1 ) === ">" && selector.length >= 3 ) {
				// Assume that strings that start and end with <> are HTML and skip the regex check
				match = [ null, selector, null ];

			} else {
				match = quickExpr.exec( selector );
			}

			// Verify a match, and that no context was specified for #id
			if ( match && (match[1] || !context) ) {

				// HANDLE: $(html) -> $(array)
				if ( match[1] ) {
					context = context instanceof jQuery ? context[0] : context;
					doc = ( context ? context.ownerDocument || context : document );

					// If a single string is passed in and it's a single tag
					// just do a createElement and skip the rest
					ret = rsingleTag.exec( selector );

					if ( ret ) {
						if ( jQuery.isPlainObject( context ) ) {
							selector = [ document.createElement( ret[1] ) ];
							jQuery.fn.attr.call( selector, context, true );

						} else {
							selector = [ doc.createElement( ret[1] ) ];
						}

					} else {
						ret = jQuery.buildFragment( [ match[1] ], [ doc ] );
						selector = ( ret.cacheable ? jQuery.clone(ret.fragment) : ret.fragment ).childNodes;
					}

					return jQuery.merge( this, selector );

				// HANDLE: $("#id")
				} else {
					elem = document.getElementById( match[2] );

					// Check parentNode to catch when Blackberry 4.6 returns
					// nodes that are no longer in the document #6963
					if ( elem && elem.parentNode ) {
						// Handle the case where IE and Opera return items
						// by name instead of ID
						if ( elem.id !== match[2] ) {
							return rootjQuery.find( selector );
						}

						// Otherwise, we inject the element directly into the jQuery object
						this.length = 1;
						this[0] = elem;
					}

					this.context = document;
					this.selector = selector;
					return this;
				}

			// HANDLE: $(expr, $(...))
			} else if ( !context || context.jquery ) {
				return ( context || rootjQuery ).find( selector );

			// HANDLE: $(expr, context)
			// (which is just equivalent to: $(context).find(expr)
			} else {
				return this.constructor( context ).find( selector );
			}

		// HANDLE: $(function)
		// Shortcut for document ready
		} else if ( jQuery.isFunction( selector ) ) {
			return rootjQuery.ready( selector );
		}

		if ( selector.selector !== undefined ) {
			this.selector = selector.selector;
			this.context = selector.context;
		}

		return jQuery.makeArray( selector, this );
	},

	// Start with an empty selector
	selector: "",

	// The current version of jQuery being used
	jquery: "1.7.1",

	// The default length of a jQuery object is 0
	length: 0,

	// The number of elements contained in the matched element set
	size: function() {
		return this.length;
	},

	toArray: function() {
		return slice.call( this, 0 );
	},

	// Get the Nth element in the matched element set OR
	// Get the whole matched element set as a clean array
	get: function( num ) {
		return num == null ?

			// Return a 'clean' array
			this.toArray() :

			// Return just the object
			( num < 0 ? this[ this.length + num ] : this[ num ] );
	},

	// Take an array of elements and push it onto the stack
	// (returning the new matched element set)
	pushStack: function( elems, name, selector ) {
		// Build a new jQuery matched element set
		var ret = this.constructor();

		if ( jQuery.isArray( elems ) ) {
			push.apply( ret, elems );

		} else {
			jQuery.merge( ret, elems );
		}

		// Add the old object onto the stack (as a reference)
		ret.prevObject = this;

		ret.context = this.context;

		if ( name === "find" ) {
			ret.selector = this.selector + ( this.selector ? " " : "" ) + selector;
		} else if ( name ) {
			ret.selector = this.selector + "." + name + "(" + selector + ")";
		}

		// Return the newly-formed element set
		return ret;
	},

	// Execute a callback for every element in the matched set.
	// (You can seed the arguments with an array of args, but this is
	// only used internally.)
	each: function( callback, args ) {
		return jQuery.each( this, callback, args );
	},

	ready: function( fn ) {
		// Attach the listeners
		jQuery.bindReady();

		// Add the callback
		readyList.add( fn );

		return this;
	},

	eq: function( i ) {
		i = +i;
		return i === -1 ?
			this.slice( i ) :
			this.slice( i, i + 1 );
	},

	first: function() {
		return this.eq( 0 );
	},

	last: function() {
		return this.eq( -1 );
	},

	slice: function() {
		return this.pushStack( slice.apply( this, arguments ),
			"slice", slice.call(arguments).join(",") );
	},

	map: function( callback ) {
		return this.pushStack( jQuery.map(this, function( elem, i ) {
			return callback.call( elem, i, elem );
		}));
	},

	end: function() {
		return this.prevObject || this.constructor(null);
	},

	// For internal use only.
	// Behaves like an Array's method, not like a jQuery method.
	push: push,
	sort: [].sort,
	splice: [].splice
};

// Give the init function the jQuery prototype for later instantiation
jQuery.fn.init.prototype = jQuery.fn;

jQuery.extend = jQuery.fn.extend = function() {
	var options, name, src, copy, copyIsArray, clone,
		target = arguments[0] || {},
		i = 1,
		length = arguments.length,
		deep = false;

	// Handle a deep copy situation
	if ( typeof target === "boolean" ) {
		deep = target;
		target = arguments[1] || {};
		// skip the boolean and the target
		i = 2;
	}

	// Handle case when target is a string or something (possible in deep copy)
	if ( typeof target !== "object" && !jQuery.isFunction(target) ) {
		target = {};
	}

	// extend jQuery itself if only one argument is passed
	if ( length === i ) {
		target = this;
		--i;
	}

	for ( ; i < length; i++ ) {
		// Only deal with non-null/undefined values
		if ( (options = arguments[ i ]) != null ) {
			// Extend the base object
			for ( name in options ) {
				src = target[ name ];
				copy = options[ name ];

				// Prevent never-ending loop
				if ( target === copy ) {
					continue;
				}

				// Recurse if we're merging plain objects or arrays
				if ( deep && copy && ( jQuery.isPlainObject(copy) || (copyIsArray = jQuery.isArray(copy)) ) ) {
					if ( copyIsArray ) {
						copyIsArray = false;
						clone = src && jQuery.isArray(src) ? src : [];

					} else {
						clone = src && jQuery.isPlainObject(src) ? src : {};
					}

					// Never move original objects, clone them
					target[ name ] = jQuery.extend( deep, clone, copy );

				// Don't bring in undefined values
				} else if ( copy !== undefined ) {
					target[ name ] = copy;
				}
			}
		}
	}

	// Return the modified object
	return target;
};

jQuery.extend({
	noConflict: function( deep ) {
		if ( window.$ === jQuery ) {
			window.$ = _$;
		}

		if ( deep && window.jQuery === jQuery ) {
			window.jQuery = _jQuery;
		}

		return jQuery;
	},

	// Is the DOM ready to be used? Set to true once it occurs.
	isReady: false,

	// A counter to track how many items to wait for before
	// the ready event fires. See #6781
	readyWait: 1,

	// Hold (or release) the ready event
	holdReady: function( hold ) {
		if ( hold ) {
			jQuery.readyWait++;
		} else {
			jQuery.ready( true );
		}
	},

	// Handle when the DOM is ready
	ready: function( wait ) {
		// Either a released hold or an DOMready/load event and not yet ready
		if ( (wait === true && !--jQuery.readyWait) || (wait !== true && !jQuery.isReady) ) {
			// Make sure body exists, at least, in case IE gets a little overzealous (ticket #5443).
			if ( !document.body ) {
				return setTimeout( jQuery.ready, 1 );
			}

			// Remember that the DOM is ready
			jQuery.isReady = true;

			// If a normal DOM Ready event fired, decrement, and wait if need be
			if ( wait !== true && --jQuery.readyWait > 0 ) {
				return;
			}

			// If there are functions bound, to execute
			readyList.fireWith( document, [ jQuery ] );

			// Trigger any bound ready events
			if ( jQuery.fn.trigger ) {
				jQuery( document ).trigger( "ready" ).off( "ready" );
			}
		}
	},

	bindReady: function() {
		if ( readyList ) {
			return;
		}

		readyList = jQuery.Callbacks( "once memory" );

		// Catch cases where $(document).ready() is called after the
		// browser event has already occurred.
		if ( document.readyState === "complete" ) {
			// Handle it asynchronously to allow scripts the opportunity to delay ready
			return setTimeout( jQuery.ready, 1 );
		}

		// Mozilla, Opera and webkit nightlies currently support this event
		if ( document.addEventListener ) {
			// Use the handy event callback
			document.addEventListener( "DOMContentLoaded", DOMContentLoaded, false );

			// A fallback to window.onload, that will always work
			window.addEventListener( "load", jQuery.ready, false );

		// If IE event model is used
		} else if ( document.attachEvent ) {
			// ensure firing before onload,
			// maybe late but safe also for iframes
			document.attachEvent( "onreadystatechange", DOMContentLoaded );

			// A fallback to window.onload, that will always work
			window.attachEvent( "onload", jQuery.ready );

			// If IE and not a frame
			// continually check to see if the document is ready
			var toplevel = false;

			try {
				toplevel = window.frameElement == null;
			} catch(e) {}

			if ( document.documentElement.doScroll && toplevel ) {
				doScrollCheck();
			}
		}
	},

	// See test/unit/core.js for details concerning isFunction.
	// Since version 1.3, DOM methods and functions like alert
	// aren't supported. They return false on IE (#2968).
	isFunction: function( obj ) {
		return jQuery.type(obj) === "function";
	},

	isArray: Array.isArray || function( obj ) {
		return jQuery.type(obj) === "array";
	},

	// A crude way of determining if an object is a window
	isWindow: function( obj ) {
		return obj && typeof obj === "object" && "setInterval" in obj;
	},

	isNumeric: function( obj ) {
		return !isNaN( parseFloat(obj) ) && isFinite( obj );
	},

	type: function( obj ) {
		return obj == null ?
			String( obj ) :
			class2type[ toString.call(obj) ] || "object";
	},

	isPlainObject: function( obj ) {
		// Must be an Object.
		// Because of IE, we also have to check the presence of the constructor property.
		// Make sure that DOM nodes and window objects don't pass through, as well
		if ( !obj || jQuery.type(obj) !== "object" || obj.nodeType || jQuery.isWindow( obj ) ) {
			return false;
		}

		try {
			// Not own constructor property must be Object
			if ( obj.constructor &&
				!hasOwn.call(obj, "constructor") &&
				!hasOwn.call(obj.constructor.prototype, "isPrototypeOf") ) {
				return false;
			}
		} catch ( e ) {
			// IE8,9 Will throw exceptions on certain host objects #9897
			return false;
		}

		// Own properties are enumerated firstly, so to speed up,
		// if last one is own, then all properties are own.

		var key;
		for ( key in obj ) {}

		return key === undefined || hasOwn.call( obj, key );
	},

	isEmptyObject: function( obj ) {
		for ( var name in obj ) {
			return false;
		}
		return true;
	},

	error: function( msg ) {
		throw new Error( msg );
	},

	parseJSON: function( data ) {
		if ( typeof data !== "string" || !data ) {
			return null;
		}

		// Make sure leading/trailing whitespace is removed (IE can't handle it)
		data = jQuery.trim( data );

		// Attempt to parse using the native JSON parser first
		if ( window.JSON && window.JSON.parse ) {
			return window.JSON.parse( data );
		}

		// Make sure the incoming data is actual JSON
		// Logic borrowed from http://json.org/json2.js
		if ( rvalidchars.test( data.replace( rvalidescape, "@" )
			.replace( rvalidtokens, "]" )
			.replace( rvalidbraces, "")) ) {

			return ( new Function( "return " + data ) )();

		}
		jQuery.error( "Invalid JSON: " + data );
	},

	// Cross-browser xml parsing
	parseXML: function( data ) {
		var xml, tmp;
		try {
			if ( window.DOMParser ) { // Standard
				tmp = new DOMParser();
				xml = tmp.parseFromString( data , "text/xml" );
			} else { // IE
				xml = new ActiveXObject( "Microsoft.XMLDOM" );
				xml.async = "false";
				xml.loadXML( data );
			}
		} catch( e ) {
			xml = undefined;
		}
		if ( !xml || !xml.documentElement || xml.getElementsByTagName( "parsererror" ).length ) {
			jQuery.error( "Invalid XML: " + data );
		}
		return xml;
	},

	noop: function() {},

	// Evaluates a script in a global context
	// Workarounds based on findings by Jim Driscoll
	// http://weblogs.java.net/blog/driscoll/archive/2009/09/08/eval-javascript-global-context
	globalEval: function( data ) {
		if ( data && rnotwhite.test( data ) ) {
			// We use execScript on Internet Explorer
			// We use an anonymous function so that context is window
			// rather than jQuery in Firefox
			( window.execScript || function( data ) {
				window[ "eval" ].call( window, data );
			} )( data );
		}
	},

	// Convert dashed to camelCase; used by the css and data modules
	// Microsoft forgot to hump their vendor prefix (#9572)
	camelCase: function( string ) {
		return string.replace( rmsPrefix, "ms-" ).replace( rdashAlpha, fcamelCase );
	},

	nodeName: function( elem, name ) {
		return elem.nodeName && elem.nodeName.toUpperCase() === name.toUpperCase();
	},

	// args is for internal usage only
	each: function( object, callback, args ) {
		var name, i = 0,
			length = object.length,
			isObj = length === undefined || jQuery.isFunction( object );

		if ( args ) {
			if ( isObj ) {
				for ( name in object ) {
					if ( callback.apply( object[ name ], args ) === false ) {
						break;
					}
				}
			} else {
				for ( ; i < length; ) {
					if ( callback.apply( object[ i++ ], args ) === false ) {
						break;
					}
				}
			}

		// A special, fast, case for the most common use of each
		} else {
			if ( isObj ) {
				for ( name in object ) {
					if ( callback.call( object[ name ], name, object[ name ] ) === false ) {
						break;
					}
				}
			} else {
				for ( ; i < length; ) {
					if ( callback.call( object[ i ], i, object[ i++ ] ) === false ) {
						break;
					}
				}
			}
		}

		return object;
	},

	// Use native String.trim function wherever possible
	trim: trim ?
		function( text ) {
			return text == null ?
				"" :
				trim.call( text );
		} :

		// Otherwise use our own trimming functionality
		function( text ) {
			return text == null ?
				"" :
				text.toString().replace( trimLeft, "" ).replace( trimRight, "" );
		},

	// results is for internal usage only
	makeArray: function( array, results ) {
		var ret = results || [];

		if ( array != null ) {
			// The window, strings (and functions) also have 'length'
			// Tweaked logic slightly to handle Blackberry 4.7 RegExp issues #6930
			var type = jQuery.type( array );

			if ( array.length == null || type === "string" || type === "function" || type === "regexp" || jQuery.isWindow( array ) ) {
				push.call( ret, array );
			} else {
				jQuery.merge( ret, array );
			}
		}

		return ret;
	},

	inArray: function( elem, array, i ) {
		var len;

		if ( array ) {
			if ( indexOf ) {
				return indexOf.call( array, elem, i );
			}

			len = array.length;
			i = i ? i < 0 ? Math.max( 0, len + i ) : i : 0;

			for ( ; i < len; i++ ) {
				// Skip accessing in sparse arrays
				if ( i in array && array[ i ] === elem ) {
					return i;
				}
			}
		}

		return -1;
	},

	merge: function( first, second ) {
		var i = first.length,
			j = 0;

		if ( typeof second.length === "number" ) {
			for ( var l = second.length; j < l; j++ ) {
				first[ i++ ] = second[ j ];
			}

		} else {
			while ( second[j] !== undefined ) {
				first[ i++ ] = second[ j++ ];
			}
		}

		first.length = i;

		return first;
	},

	grep: function( elems, callback, inv ) {
		var ret = [], retVal;
		inv = !!inv;

		// Go through the array, only saving the items
		// that pass the validator function
		for ( var i = 0, length = elems.length; i < length; i++ ) {
			retVal = !!callback( elems[ i ], i );
			if ( inv !== retVal ) {
				ret.push( elems[ i ] );
			}
		}

		return ret;
	},

	// arg is for internal usage only
	map: function( elems, callback, arg ) {
		var value, key, ret = [],
			i = 0,
			length = elems.length,
			// jquery objects are treated as arrays
			isArray = elems instanceof jQuery || length !== undefined && typeof length === "number" && ( ( length > 0 && elems[ 0 ] && elems[ length -1 ] ) || length === 0 || jQuery.isArray( elems ) ) ;

		// Go through the array, translating each of the items to their
		if ( isArray ) {
			for ( ; i < length; i++ ) {
				value = callback( elems[ i ], i, arg );

				if ( value != null ) {
					ret[ ret.length ] = value;
				}
			}

		// Go through every key on the object,
		} else {
			for ( key in elems ) {
				value = callback( elems[ key ], key, arg );

				if ( value != null ) {
					ret[ ret.length ] = value;
				}
			}
		}

		// Flatten any nested arrays
		return ret.concat.apply( [], ret );
	},

	// A global GUID counter for objects
	guid: 1,

	// Bind a function to a context, optionally partially applying any
	// arguments.
	proxy: function( fn, context ) {
		if ( typeof context === "string" ) {
			var tmp = fn[ context ];
			context = fn;
			fn = tmp;
		}

		// Quick check to determine if target is callable, in the spec
		// this throws a TypeError, but we will just return undefined.
		if ( !jQuery.isFunction( fn ) ) {
			return undefined;
		}

		// Simulated bind
		var args = slice.call( arguments, 2 ),
			proxy = function() {
				return fn.apply( context, args.concat( slice.call( arguments ) ) );
			};

		// Set the guid of unique handler to the same of original handler, so it can be removed
		proxy.guid = fn.guid = fn.guid || proxy.guid || jQuery.guid++;

		return proxy;
	},

	// Mutifunctional method to get and set values to a collection
	// The value/s can optionally be executed if it's a function
	access: function( elems, key, value, exec, fn, pass ) {
		var length = elems.length;

		// Setting many attributes
		if ( typeof key === "object" ) {
			for ( var k in key ) {
				jQuery.access( elems, k, key[k], exec, fn, value );
			}
			return elems;
		}

		// Setting one attribute
		if ( value !== undefined ) {
			// Optionally, function values get executed if exec is true
			exec = !pass && exec && jQuery.isFunction(value);

			for ( var i = 0; i < length; i++ ) {
				fn( elems[i], key, exec ? value.call( elems[i], i, fn( elems[i], key ) ) : value, pass );
			}

			return elems;
		}

		// Getting an attribute
		return length ? fn( elems[0], key ) : undefined;
	},

	now: function() {
		return ( new Date() ).getTime();
	},

	// Use of jQuery.browser is frowned upon.
	// More details: http://docs.jquery.com/Utilities/jQuery.browser
	uaMatch: function( ua ) {
		ua = ua.toLowerCase();

		var match = rwebkit.exec( ua ) ||
			ropera.exec( ua ) ||
			rmsie.exec( ua ) ||
			ua.indexOf("compatible") < 0 && rmozilla.exec( ua ) ||
			[];

		return { browser: match[1] || "", version: match[2] || "0" };
	},

	sub: function() {
		function jQuerySub( selector, context ) {
			return new jQuerySub.fn.init( selector, context );
		}
		jQuery.extend( true, jQuerySub, this );
		jQuerySub.superclass = this;
		jQuerySub.fn = jQuerySub.prototype = this();
		jQuerySub.fn.constructor = jQuerySub;
		jQuerySub.sub = this.sub;
		jQuerySub.fn.init = function init( selector, context ) {
			if ( context && context instanceof jQuery && !(context instanceof jQuerySub) ) {
				context = jQuerySub( context );
			}

			return jQuery.fn.init.call( this, selector, context, rootjQuerySub );
		};
		jQuerySub.fn.init.prototype = jQuerySub.fn;
		var rootjQuerySub = jQuerySub(document);
		return jQuerySub;
	},

	browser: {}
});

// Populate the class2type map
jQuery.each("Boolean Number String Function Array Date RegExp Object".split(" "), function(i, name) {
	class2type[ "[object " + name + "]" ] = name.toLowerCase();
});

browserMatch = jQuery.uaMatch( userAgent );
if ( browserMatch.browser ) {
	jQuery.browser[ browserMatch.browser ] = true;
	jQuery.browser.version = browserMatch.version;
}

// Deprecated, use jQuery.browser.webkit instead
if ( jQuery.browser.webkit ) {
	jQuery.browser.safari = true;
}

// IE doesn't match non-breaking spaces with \s
if ( rnotwhite.test( "\xA0" ) ) {
	trimLeft = /^[\s\xA0]+/;
	trimRight = /[\s\xA0]+$/;
}

// All jQuery objects should point back to these
rootjQuery = jQuery(document);

// Cleanup functions for the document ready method
if ( document.addEventListener ) {
	DOMContentLoaded = function() {
		document.removeEventListener( "DOMContentLoaded", DOMContentLoaded, false );
		jQuery.ready();
	};

} else if ( document.attachEvent ) {
	DOMContentLoaded = function() {
		// Make sure body exists, at least, in case IE gets a little overzealous (ticket #5443).
		if ( document.readyState === "complete" ) {
			document.detachEvent( "onreadystatechange", DOMContentLoaded );
			jQuery.ready();
		}
	};
}

// The DOM ready check for Internet Explorer
function doScrollCheck() {
	if ( jQuery.isReady ) {
		return;
	}

	try {
		// If IE is used, use the trick by Diego Perini
		// http://javascript.nwbox.com/IEContentLoaded/
		document.documentElement.doScroll("left");
	} catch(e) {
		setTimeout( doScrollCheck, 1 );
		return;
	}

	// and execute any waiting functions
	jQuery.ready();
}

return jQuery;

})();


// String to Object flags format cache
var flagsCache = {};

// Convert String-formatted flags into Object-formatted ones and store in cache
function createFlags( flags ) {
	var object = flagsCache[ flags ] = {},
		i, length;
	flags = flags.split( /\s+/ );
	for ( i = 0, length = flags.length; i < length; i++ ) {
		object[ flags[i] ] = true;
	}
	return object;
}

/*
 * Create a callback list using the following parameters:
 *
 *	flags:	an optional list of space-separated flags that will change how
 *			the callback list behaves
 *
 * By default a callback list will act like an event callback list and can be
 * "fired" multiple times.
 *
 * Possible flags:
 *
 *	once:			will ensure the callback list can only be fired once (like a Deferred)
 *
 *	memory:			will keep track of previous values and will call any callback added
 *					after the list has been fired right away with the latest "memorized"
 *					values (like a Deferred)
 *
 *	unique:			will ensure a callback can only be added once (no duplicate in the list)
 *
 *	stopOnFalse:	interrupt callings when a callback returns false
 *
 */
jQuery.Callbacks = function( flags ) {

	// Convert flags from String-formatted to Object-formatted
	// (we check in cache first)
	flags = flags ? ( flagsCache[ flags ] || createFlags( flags ) ) : {};

	var // Actual callback list
		list = [],
		// Stack of fire calls for repeatable lists
		stack = [],
		// Last fire value (for non-forgettable lists)
		memory,
		// Flag to know if list is currently firing
		firing,
		// First callback to fire (used internally by add and fireWith)
		firingStart,
		// End of the loop when firing
		firingLength,
		// Index of currently firing callback (modified by remove if needed)
		firingIndex,
		// Add one or several callbacks to the list
		add = function( args ) {
			var i,
				length,
				elem,
				type,
				actual;
			for ( i = 0, length = args.length; i < length; i++ ) {
				elem = args[ i ];
				type = jQuery.type( elem );
				if ( type === "array" ) {
					// Inspect recursively
					add( elem );
				} else if ( type === "function" ) {
					// Add if not in unique mode and callback is not in
					if ( !flags.unique || !self.has( elem ) ) {
						list.push( elem );
					}
				}
			}
		},
		// Fire callbacks
		fire = function( context, args ) {
			args = args || [];
			memory = !flags.memory || [ context, args ];
			firing = true;
			firingIndex = firingStart || 0;
			firingStart = 0;
			firingLength = list.length;
			for ( ; list && firingIndex < firingLength; firingIndex++ ) {
				if ( list[ firingIndex ].apply( context, args ) === false && flags.stopOnFalse ) {
					memory = true; // Mark as halted
					break;
				}
			}
			firing = false;
			if ( list ) {
				if ( !flags.once ) {
					if ( stack && stack.length ) {
						memory = stack.shift();
						self.fireWith( memory[ 0 ], memory[ 1 ] );
					}
				} else if ( memory === true ) {
					self.disable();
				} else {
					list = [];
				}
			}
		},
		// Actual Callbacks object
		self = {
			// Add a callback or a collection of callbacks to the list
			add: function() {
				if ( list ) {
					var length = list.length;
					add( arguments );
					// Do we need to add the callbacks to the
					// current firing batch?
					if ( firing ) {
						firingLength = list.length;
					// With memory, if we're not firing then
					// we should call right away, unless previous
					// firing was halted (stopOnFalse)
					} else if ( memory && memory !== true ) {
						firingStart = length;
						fire( memory[ 0 ], memory[ 1 ] );
					}
				}
				return this;
			},
			// Remove a callback from the list
			remove: function() {
				if ( list ) {
					var args = arguments,
						argIndex = 0,
						argLength = args.length;
					for ( ; argIndex < argLength ; argIndex++ ) {
						for ( var i = 0; i < list.length; i++ ) {
							if ( args[ argIndex ] === list[ i ] ) {
								// Handle firingIndex and firingLength
								if ( firing ) {
									if ( i <= firingLength ) {
										firingLength--;
										if ( i <= firingIndex ) {
											firingIndex--;
										}
									}
								}
								// Remove the element
								list.splice( i--, 1 );
								// If we have some unicity property then
								// we only need to do this once
								if ( flags.unique ) {
									break;
								}
							}
						}
					}
				}
				return this;
			},
			// Control if a given callback is in the list
			has: function( fn ) {
				if ( list ) {
					var i = 0,
						length = list.length;
					for ( ; i < length; i++ ) {
						if ( fn === list[ i ] ) {
							return true;
						}
					}
				}
				return false;
			},
			// Remove all callbacks from the list
			empty: function() {
				list = [];
				return this;
			},
			// Have the list do nothing anymore
			disable: function() {
				list = stack = memory = undefined;
				return this;
			},
			// Is it disabled?
			disabled: function() {
				return !list;
			},
			// Lock the list in its current state
			lock: function() {
				stack = undefined;
				if ( !memory || memory === true ) {
					self.disable();
				}
				return this;
			},
			// Is it locked?
			locked: function() {
				return !stack;
			},
			// Call all callbacks with the given context and arguments
			fireWith: function( context, args ) {
				if ( stack ) {
					if ( firing ) {
						if ( !flags.once ) {
							stack.push( [ context, args ] );
						}
					} else if ( !( flags.once && memory ) ) {
						fire( context, args );
					}
				}
				return this;
			},
			// Call all the callbacks with the given arguments
			fire: function() {
				self.fireWith( this, arguments );
				return this;
			},
			// To know if the callbacks have already been called at least once
			fired: function() {
				return !!memory;
			}
		};

	return self;
};




var // Static reference to slice
	sliceDeferred = [].slice;

jQuery.extend({

	Deferred: function( func ) {
		var doneList = jQuery.Callbacks( "once memory" ),
			failList = jQuery.Callbacks( "once memory" ),
			progressList = jQuery.Callbacks( "memory" ),
			state = "pending",
			lists = {
				resolve: doneList,
				reject: failList,
				notify: progressList
			},
			promise = {
				done: doneList.add,
				fail: failList.add,
				progress: progressList.add,

				state: function() {
					return state;
				},

				// Deprecated
				isResolved: doneList.fired,
				isRejected: failList.fired,

				then: function( doneCallbacks, failCallbacks, progressCallbacks ) {
					deferred.done( doneCallbacks ).fail( failCallbacks ).progress( progressCallbacks );
					return this;
				},
				always: function() {
					deferred.done.apply( deferred, arguments ).fail.apply( deferred, arguments );
					return this;
				},
				pipe: function( fnDone, fnFail, fnProgress ) {
					return jQuery.Deferred(function( newDefer ) {
						jQuery.each( {
							done: [ fnDone, "resolve" ],
							fail: [ fnFail, "reject" ],
							progress: [ fnProgress, "notify" ]
						}, function( handler, data ) {
							var fn = data[ 0 ],
								action = data[ 1 ],
								returned;
							if ( jQuery.isFunction( fn ) ) {
								deferred[ handler ](function() {
									returned = fn.apply( this, arguments );
									if ( returned && jQuery.isFunction( returned.promise ) ) {
										returned.promise().then( newDefer.resolve, newDefer.reject, newDefer.notify );
									} else {
										newDefer[ action + "With" ]( this === deferred ? newDefer : this, [ returned ] );
									}
								});
							} else {
								deferred[ handler ]( newDefer[ action ] );
							}
						});
					}).promise();
				},
				// Get a promise for this deferred
				// If obj is provided, the promise aspect is added to the object
				promise: function( obj ) {
					if ( obj == null ) {
						obj = promise;
					} else {
						for ( var key in promise ) {
							obj[ key ] = promise[ key ];
						}
					}
					return obj;
				}
			},
			deferred = promise.promise({}),
			key;

		for ( key in lists ) {
			deferred[ key ] = lists[ key ].fire;
			deferred[ key + "With" ] = lists[ key ].fireWith;
		}

		// Handle state
		deferred.done( function() {
			state = "resolved";
		}, failList.disable, progressList.lock ).fail( function() {
			state = "rejected";
		}, doneList.disable, progressList.lock );

		// Call given func if any
		if ( func ) {
			func.call( deferred, deferred );
		}

		// All done!
		return deferred;
	},

	// Deferred helper
	when: function( firstParam ) {
		var args = sliceDeferred.call( arguments, 0 ),
			i = 0,
			length = args.length,
			pValues = new Array( length ),
			count = length,
			pCount = length,
			deferred = length <= 1 && firstParam && jQuery.isFunction( firstParam.promise ) ?
				firstParam :
				jQuery.Deferred(),
			promise = deferred.promise();
		function resolveFunc( i ) {
			return function( value ) {
				args[ i ] = arguments.length > 1 ? sliceDeferred.call( arguments, 0 ) : value;
				if ( !( --count ) ) {
					deferred.resolveWith( deferred, args );
				}
			};
		}
		function progressFunc( i ) {
			return function( value ) {
				pValues[ i ] = arguments.length > 1 ? sliceDeferred.call( arguments, 0 ) : value;
				deferred.notifyWith( promise, pValues );
			};
		}
		if ( length > 1 ) {
			for ( ; i < length; i++ ) {
				if ( args[ i ] && args[ i ].promise && jQuery.isFunction( args[ i ].promise ) ) {
					args[ i ].promise().then( resolveFunc(i), deferred.reject, progressFunc(i) );
				} else {
					--count;
				}
			}
			if ( !count ) {
				deferred.resolveWith( deferred, args );
			}
		} else if ( deferred !== firstParam ) {
			deferred.resolveWith( deferred, length ? [ firstParam ] : [] );
		}
		return promise;
	}
});




jQuery.support = (function() {

	var support,
		all,
		a,
		select,
		opt,
		input,
		marginDiv,
		fragment,
		tds,
		events,
		eventName,
		i,
		isSupported,
		div = document.createElement( "div" ),
		documentElement = document.documentElement;

	// Preliminary tests
	div.setAttribute("className", "t");
	div.innerHTML = "   <link/><table></table><a href='/a' style='top:1px;float:left;opacity:.55;'>a</a><input type='checkbox'/>";

	all = div.getElementsByTagName( "*" );
	a = div.getElementsByTagName( "a" )[ 0 ];

	// Can't get basic test support
	if ( !all || !all.length || !a ) {
		return {};
	}

	// First batch of supports tests
	select = document.createElement( "select" );
	opt = select.appendChild( document.createElement("option") );
	input = div.getElementsByTagName( "input" )[ 0 ];

	support = {
		// IE strips leading whitespace when .innerHTML is used
		leadingWhitespace: ( div.firstChild.nodeType === 3 ),

		// Make sure that tbody elements aren't automatically inserted
		// IE will insert them into empty tables
		tbody: !div.getElementsByTagName("tbody").length,

		// Make sure that link elements get serialized correctly by innerHTML
		// This requires a wrapper element in IE
		htmlSerialize: !!div.getElementsByTagName("link").length,

		// Get the style information from getAttribute
		// (IE uses .cssText instead)
		style: /top/.test( a.getAttribute("style") ),

		// Make sure that URLs aren't manipulated
		// (IE normalizes it by default)
		hrefNormalized: ( a.getAttribute("href") === "/a" ),

		// Make sure that element opacity exists
		// (IE uses filter instead)
		// Use a regex to work around a WebKit issue. See #5145
		opacity: /^0.55/.test( a.style.opacity ),

		// Verify style float existence
		// (IE uses styleFloat instead of cssFloat)
		cssFloat: !!a.style.cssFloat,

		// Make sure that if no value is specified for a checkbox
		// that it defaults to "on".
		// (WebKit defaults to "" instead)
		checkOn: ( input.value === "on" ),

		// Make sure that a selected-by-default option has a working selected property.
		// (WebKit defaults to false instead of true, IE too, if it's in an optgroup)
		optSelected: opt.selected,

		// Test setAttribute on camelCase class. If it works, we need attrFixes when doing get/setAttribute (ie6/7)
		getSetAttribute: div.className !== "t",

		// Tests for enctype support on a form(#6743)
		enctype: !!document.createElement("form").enctype,

		// Makes sure cloning an html5 element does not cause problems
		// Where outerHTML is undefined, this still works
		html5Clone: document.createElement("nav").cloneNode( true ).outerHTML !== "<:nav></:nav>",

		// Will be defined later
		submitBubbles: true,
		changeBubbles: true,
		focusinBubbles: false,
		deleteExpando: true,
		noCloneEvent: true,
		inlineBlockNeedsLayout: false,
		shrinkWrapBlocks: false,
		reliableMarginRight: true
	};

	// Make sure checked status is properly cloned
	input.checked = true;
	support.noCloneChecked = input.cloneNode( true ).checked;

	// Make sure that the options inside disabled selects aren't marked as disabled
	// (WebKit marks them as disabled)
	select.disabled = true;
	support.optDisabled = !opt.disabled;

	// Test to see if it's possible to delete an expando from an element
	// Fails in Internet Explorer
	try {
		delete div.test;
	} catch( e ) {
		support.deleteExpando = false;
	}

	if ( !div.addEventListener && div.attachEvent && div.fireEvent ) {
		div.attachEvent( "onclick", function() {
			// Cloning a node shouldn't copy over any
			// bound event handlers (IE does this)
			support.noCloneEvent = false;
		});
		div.cloneNode( true ).fireEvent( "onclick" );
	}

	// Check if a radio maintains its value
	// after being appended to the DOM
	input = document.createElement("input");
	input.value = "t";
	input.setAttribute("type", "radio");
	support.radioValue = input.value === "t";

	input.setAttribute("checked", "checked");
	div.appendChild( input );
	fragment = document.createDocumentFragment();
	fragment.appendChild( div.lastChild );

	// WebKit doesn't clone checked state correctly in fragments
	support.checkClone = fragment.cloneNode( true ).cloneNode( true ).lastChild.checked;

	// Check if a disconnected checkbox will retain its checked
	// value of true after appended to the DOM (IE6/7)
	support.appendChecked = input.checked;

	fragment.removeChild( input );
	fragment.appendChild( div );

	div.innerHTML = "";

	// Check if div with explicit width and no margin-right incorrectly
	// gets computed margin-right based on width of container. For more
	// info see bug #3333
	// Fails in WebKit before Feb 2011 nightlies
	// WebKit Bug 13343 - getComputedStyle returns wrong value for margin-right
	if ( window.getComputedStyle ) {
		marginDiv = document.createElement( "div" );
		marginDiv.style.width = "0";
		marginDiv.style.marginRight = "0";
		div.style.width = "2px";
		div.appendChild( marginDiv );
		support.reliableMarginRight =
			( parseInt( ( window.getComputedStyle( marginDiv, null ) || { marginRight: 0 } ).marginRight, 10 ) || 0 ) === 0;
	}

	// Technique from Juriy Zaytsev
	// http://perfectionkills.com/detecting-event-support-without-browser-sniffing/
	// We only care about the case where non-standard event systems
	// are used, namely in IE. Short-circuiting here helps us to
	// avoid an eval call (in setAttribute) which can cause CSP
	// to go haywire. See: https://developer.mozilla.org/en/Security/CSP
	if ( div.attachEvent ) {
		for( i in {
			submit: 1,
			change: 1,
			focusin: 1
		}) {
			eventName = "on" + i;
			isSupported = ( eventName in div );
			if ( !isSupported ) {
				div.setAttribute( eventName, "return;" );
				isSupported = ( typeof div[ eventName ] === "function" );
			}
			support[ i + "Bubbles" ] = isSupported;
		}
	}

	fragment.removeChild( div );

	// Null elements to avoid leaks in IE
	fragment = select = opt = marginDiv = div = input = null;

	// Run tests that need a body at doc ready
	jQuery(function() {
		var container, outer, inner, table, td, offsetSupport,
			conMarginTop, ptlm, vb, style, html,
			body = document.getElementsByTagName("body")[0];

		if ( !body ) {
			// Return for frameset docs that don't have a body
			return;
		}

		conMarginTop = 1;
		ptlm = "position:absolute;top:0;left:0;width:1px;height:1px;margin:0;";
		vb = "visibility:hidden;border:0;";
		style = "style='" + ptlm + "border:5px solid #000;padding:0;'";
		html = "<div " + style + "><div></div></div>" +
			"<table " + style + " cellpadding='0' cellspacing='0'>" +
			"<tr><td></td></tr></table>";

		container = document.createElement("div");
		container.style.cssText = vb + "width:0;height:0;position:static;top:0;margin-top:" + conMarginTop + "px";
		body.insertBefore( container, body.firstChild );

		// Construct the test element
		div = document.createElement("div");
		container.appendChild( div );

		// Check if table cells still have offsetWidth/Height when they are set
		// to display:none and there are still other visible table cells in a
		// table row; if so, offsetWidth/Height are not reliable for use when
		// determining if an element has been hidden directly using
		// display:none (it is still safe to use offsets if a parent element is
		// hidden; don safety goggles and see bug #4512 for more information).
		// (only IE 8 fails this test)
		div.innerHTML = "<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>";
		tds = div.getElementsByTagName( "td" );
		isSupported = ( tds[ 0 ].offsetHeight === 0 );

		tds[ 0 ].style.display = "";
		tds[ 1 ].style.display = "none";

		// Check if empty table cells still have offsetWidth/Height
		// (IE <= 8 fail this test)
		support.reliableHiddenOffsets = isSupported && ( tds[ 0 ].offsetHeight === 0 );

		// Figure out if the W3C box model works as expected
		div.innerHTML = "";
		div.style.width = div.style.paddingLeft = "1px";
		jQuery.boxModel = support.boxModel = div.offsetWidth === 2;

		if ( typeof div.style.zoom !== "undefined" ) {
			// Check if natively block-level elements act like inline-block
			// elements when setting their display to 'inline' and giving
			// them layout
			// (IE < 8 does this)
			div.style.display = "inline";
			div.style.zoom = 1;
			support.inlineBlockNeedsLayout = ( div.offsetWidth === 2 );

			// Check if elements with layout shrink-wrap their children
			// (IE 6 does this)
			div.style.display = "";
			div.innerHTML = "<div style='width:4px;'></div>";
			support.shrinkWrapBlocks = ( div.offsetWidth !== 2 );
		}

		div.style.cssText = ptlm + vb;
		div.innerHTML = html;

		outer = div.firstChild;
		inner = outer.firstChild;
		td = outer.nextSibling.firstChild.firstChild;

		offsetSupport = {
			doesNotAddBorder: ( inner.offsetTop !== 5 ),
			doesAddBorderForTableB ifells; ( td.offsetTop === 5 )able: fu
		inner.style.position = "fixed";
		inner.style.topnRigh0pxrapBlocks =sord/Top !st "ts parent border width  sti which is 5px
		offsetSupport.fixedPosition = ( inner.offsetTop === 2pportrnner.offsetTop === 2pportrnne1u
; sti which is 5px
		offset 2pportrg";

		out	offset 2overloawrtrghiddening tivent ) { = mis 5px
		osition 2o0pxgles and rtrg";

		out	offse=set
		/	if ( !isSupps( !isSupg{
			state = Width ===c( !isSupg{ 5px
		|dt.reliableI1fnerddenOfSupph =m( inner		support.inl.=sord/Top !st aent ) tTop ===g[6E.re|romisort.fixedPosition = ( stil: fp		});


	ey ] = li1o ===c( =m( innguments, 2
			s wit(?:\{.*\}|\[.*\])$/,

act lD		rs wi([A-Z])/g// Static reference to	Strin:+ data );
	Pmen				""= ( d to/ The vu iser xml par prosetTop === 2ppor5px
		|dta );
		|re|romise|romise|to/ The v .p
	/gment.rcarde htading/trait"e if needed)
	y to/ The vuoeeI: false,"The vuc;to(
			}

	ems.len+
			i rfalsm()place( trimL/\D/g.replata );
		Tllback list ;

			/{
			/oc d)
		do// IE8,9 W safeif ng here( data
					//I: falsne is own, true afm.: undD
		:
		of"embyleue,
		 Must beaast o "comple// IE8,mise|Flto	S( bord
			///I: fals		// (f ( typee,"cls
		D27CDB6E-AE6D-11cf-96B8-444553540000",// (f				eteue,
	
		return ninD
		a function
	accoom !== 	acco=
	acce: ( div.f?
			}
/ Th[
	acc[
			}
I: fals]Div i typeositing.firstChild.firstChild;

	o&ffsetHeight ==r cl.=sord/Toloawrtrgject( "M cl.;
	},

	//dm !== 	acco=
	acce:name, obdm !ptlvt /*nternetalse a Oy IE*/ {
		if ( ty!uery.acce
		rtrgelem ) ) {
					turn;
		}

		co])/gpriveElche[ this sche[ thtur
			i =ernetalK ===rstChild;

	onturnurn	ons[iis sength ; ar=== "string" |ntu			// We uave to cf ( typOM nodes and wiJSbjects donifrencey by ause of6/7-7			// Wan't haGCbjects eference tproperly clacss-bhe DOM (-JSbund ey t			isSude( 		}
/ Th[
	accntu			// W Oy IOM nodes aeed ahe Dlobal Gde htadi fals;iJSbjects ata is a			// W tachEv ahrectly uo the object
o, aGCan onlcritutomatically i			conhe = {}Sude(c[
			}
I: falsChild.fntu			// W Oy IOfineng an htID	///IJSbjects df it'ssi falalready exists
lre/oca			// Whe case(co seert-ccuon ahe same ofp see
		if ( {
			type,ctiontco see (lik""enstead of tre=set
		/	ifmodel wme", "bSecurity/CSP
	if ( div.attachEvent ) {
		for( id && g" |ntu			e( id /Top !st "tAE
	fdo	disablon).ted
 Firefthe callbaset
		ry	di value/ W ta3)
	ning ifssi fal Firen di (l W ta3renhe y.acce
	(!id++;!ypeosiid]++;	(!for( id trgjealstrgj!ypeosiid].W ta))trgjngth ; artrgjW ta|| jQuery.isFu;
		}

		co])/gpriupported .isFuy IOM nodes aeed ahe Dlobal alobwe and caIDent.rcard
		// hisily dren
rtrgjments when fiupiv. Gde htadi e (lik""eupport of treiv.setAttrbSecurity/CSP
	if (= tead ++alsChilise|e {
				jQuery.mergteadrity/CSP
	ie {
		co])/gpriupportstrgj!yp tea			return rgj!yp tea		=r // Actuop !st "tA
		diodispfals;iJSmhecue/ W tabacv. df it'ssi are set
 it'ssictuop ! of correctly followi datau			//loaisSupportedof treiv.setArn rgj!yp tea	

 datd;

	ontion(e {
		co])/gpriop !st}

/*moved
			}
he ca

	ontue/  true, IE toaWith/argi			}ir; thtuted m/Top !sth// Whe htheckghidW tct
o,e/oca	lowirgj!yriupportar=== "string" |n-11cf-96iid]r=== "strition" ) {
					// Add upportargj// Add rn rgj!yp tea		=r==c( =m( inngumrgj!yp tea	
		reture {
				jQuery.mergrgj!yp teasiid].	=r==c( =m( inngumrgj!yp teasiid].
		reture {
		co])/gpriope[ this sch
		jQue sch
	mrgj!yp teasid /Top !r==c( =rtrgj()afe toblodl contlags tha

/*mabled set
 it'ssi'srity/CSPrtrgj/Top !mrgj!yl co	if (eaks in IWith of ci
// en dtwdirrity/CSPrtrgjects ug/
jQuery./Top !rtrgjjQuery.isFurgj// Add ery.isFujQue sch.						var fn =jQue sch.					=r /			return jQuejQue sch
	mjQue sch.					co])/gpriupporte				ned ) {
			// OptionaljQue sch;

	o&flass. If (		retura		=r					co])/gpa regex torint backle fwn, true afmirsivelet
rity/CSPru			e( it'ssifollow

	ontue/ mise|Flt safe) {eateElemedg #451uifssi fo
 *			.- glone co	distilldiv.a? tojQuery.isF;	(!for( id tjQue sch=== falsisFu;
		}

	he[ this sche.u			e(	co])/gpa regexCternet Exbore|rs fromednMa-lass.g #4rd evrs fromedr				
		// (We== fasE is used,ar				
		// (We=wa for a checQuery.isFtrgjngth ; supportcallback toTrject			ed
-is
		// (Wertrgjments			i =jQue sch=== faasid /Tofor enctyet Ey ] =| {
			//
		// (Wertrgjmenrned && jQ{
						obj = obj is oTrject			eet
rlass. If /
		// (We obnts			i =jQue sch;

	o&flass. If (		retura	} else if ( deferr{ments			i =jQue sch;return ret;
	},

	// arg is foeeI: Dco=
	acce:name, obdm !ptlternetalse a Oy IE*/ {
		if ( ty!uery.acce
		rtrgelem ) ) {
					turn;
		}

		co])/gpriveElchthtur
			i 
	flW Oy IOfineR slice
	slrity/CSPrtrgjmrgj!yWithetalK ===rstChild;

	onturnurn	ons( 		}
/ Th[
	accntu			// W Oy IOM no//d

	ontue/ nformation).
		// (o= {}Sude(c[
			}
I: falsChild.fntu			// W Oy IOfine//d

	ontue/ nformation).
		// (o= {}Stead of tre=set
		/	ifmodel wme", "ity/CSP
	ie {E is usedstill  ofists
lr see (likhent
eferred
	} else still  of seE is uspuriod  ond arginulowriupportstrgj!yp tea	isFu;
		}

		co])/gpriupport		return rn jQuejQue sch
	erne=sergj!yp tea	i:mrgj!yp teasiid].( array.lengtjQue sch	obj = obj is oit(?:\{rray[ ierr.innerlags that u			//== faseferrid].Withs!( --count )ray( elems ) )t		retur	obj = obbj is ot
stil u			//=a f.With 2011 no	did
		// // (o= {}Support		re  ontjQue sch	obj =fer[ acth ; a=== faaslse {
						for (se bbj is o/ );et
rlass.rlaf /
rowserMabyh \s
ivious f.Witlatest "meh \s
ie/oca		 =fer[ acth ; 

	o&flass. If (		returlse {}Support		re  ontjQue sch	obj =fer[ aacth ; a=== faaslse {{
						fbj =fer[ aacth ; acth +/ );
	"	"	)
					}
				}
				return 		r= 0, length = arg; acth < length; i++ 				if ( args[v.test;=jQue sch=== fae;
	;		return 		r=is usedstill  oen di (l Wh:1piv. Gdemrgj!yttrFiwani fod arginue		r=is ug #4rst; Gdemrgj!a

/*mabt

i valueu		oyed!( --count ) erne=sergject( "M cl.;
 :

	o&frgject(cl.;
 )gtjQue sch	oreturn jQuery.Def		}
		}

		// FlatteOfine//d

	ontue/ nformation).
		// (o= {}y.isFurgj// Add[v.test;mrgj!yp teasiid].( arr need ton'alueu		oy Gdeder widmrgj!yvious  Gderity/CSPrtrgj it'ssictuop ! hadn dir Gderails re
	Wh:1piv. itrray.lengrtrgject( "M cl.;
	rgj!yp teasoreturn jQery.Def		}
		// FlatteOfineBfing/t havetest)undD
		:test/ (o'lengtprock by:test/		D27CDB6Erai it defautrings (anb3C blike an// Wh bli(o'lsible tabdf it'ssi ;ble tabbfing/t it de a bod the of the lohe options`rgj!y`
					ifarings (

/*ma#10080= {}y.is

	onteteExpando = false;
(!id++;!yte( e a Oarg// Add[v.test;mrgj!yp teas;if ( deferr{mentsrgj!yp teas	ey ] = // FlatteOfineWelueu		oyed Gdemrgj!ae;efthe calests
	;=jQ		D27CDB6e ofp setu		eaks in IteOfin});
 firikupsiv. Gdemrgj!ye suppo			e a body ofir			re/oca	teOpport of treiv.setAtt't match 				in// Wh usby:test/	undD
		:
		of"emblist
 ahe D know if ahrtch 		idy
			reoeeI: eventNamenit( seleclecgment(); ahe D //ly need tmus(IE does'lsibldstilse non-t it{}y.is

	onteteExpando = false;
(eturn jQedo = fet
		/	ifmodel wme"e {
				jQuey.is
	accnoeeI: eventName(eturn jQe	accnoeeI: eventName(/	ifmodel wmure {
				jQuery.mergt
		/	ifmodel wmes	ey ] = /}
		// Fl/ Deferred heF usage only
	erailsjQue_cco=
	acce:name, obdm !ptlvt /*turn {};
	}


	ontue/ e, obdm !ptlvt /*nton
	
	// A global GUI ( docue sug if an element 		type,ctiovedIE doesstilt /*nundD
		:balgelem cco=
	acce: ( div.f?
			}
y.is
	accn,ctigth ; supp	 = rwebkit.ex

	ontiocco=[
	accn,ctigCase();
});

be"e { it{}y.isebkit.eturn !!memory;
	(bkit. {
					s||
	accng("className", "t")iappned )bkit.	}

		return ret;
	},				




jQuer()place(  par prosetTcco=
	acce:name, exec, fn, args = slider t, inlasm !ptlvs = Tcco=	ey ] = /}peof key === "object" ) {) {
			// Check i.lengtjQue
						memory= Tcco=	e

	ontue/ gtjQuef (if ( value != gtjQuef (== 3 ),

		/1 id t

	ont_ue/ gtjQuef (

 winddclass"	oreturn jQuenlas	ejQuef (=
		if ( ty ( var i = 0; i < lh = arg; a
		i< length; i++ 				if ( arer[ aacth ; a
		ie;.cth  ( se {}Support		re ompatible "ue/ -"	}

	/f ( arefer[ acth ; 

	o&flass. If (		retse=su			//(5)if ( valuey= Tcco=clasgtjQuef (m !ptlvt /*n=== falsis
					}
					return obj;

	ont_ue/ gtjQuef (

 winddclass"ton
	
	// 	returnreturn jQuery.fn.iid].( arf ( deferr key === "object" ) {
			for ( var k;
				},
						{
									return

	ontue/ gtjQuendefin	}

				div.style.cer t, =defi, functi.ainle.cer t,[1s	eyer t,[1s	? i.a +yer t,[1s	:ut	offset !== undefiW ta|| jQuery.isFus = Tcco=	e	},
				g		rH does ("ge cco=a +yer t,[1s +y"!"to[er t,[0]]f ( vaj is oTrject	eit.o	didby add and toblodlcco=	

	ck i.lengrtrgjW ta|| jQuery.i&&tjQue
						memory= Tcco=	e

	ontue/ gtjQuef (ndefin	}ory= Tcco=	ecco=clasgtjQuef (ndefivt /*n
			return jQuery.fn.rtrgjW ta|| jQuery.i&&ter t,[1s	?r fn =jQuetue/ gter t,[0]
		r fn =id].( arf ( defer( var k;
				},
						{
									returni < 

	e

	ongtjQuesAddBorrgs || [];[ter t,[0]ec, fn, ] ( valuey

				g		rH does (ntue cco=a +yer t,[1s +y"!"			}
		}return

	ontue/ gtjQuendefi
			}
			valuey

				g		rH does (nt
 *			cco=a +yer t,[1s +y"!"			}
		}retur			div.s/ arg is foeeI: Dco=
	acce:name			jQuery. k;
				},
						{
									retur

	ontoeeI: Dc/ gtjQuendefin	}
ur			div


jQuer{
					cco=clase, obdmdefivt /*nQuery.s usedymore
	=wa ff	isSdby add andtonrject	eit.o	diy.s ut /*nist
			em;
5t /*n-*
		return le.lengrtrgjW ta|| jQuery.i&&, obd== 3 ),

		/1Query.s = slidcth ;  "ue/ -"	+defiTllback lien				""= 

-$1or e();

		var match =trgjW 
	accng("classNam (		returl/}peof key === "obtrgjW  |ntu			//or ( var knrjemory= Tcco=	etrgjW  |ntn
	"	? n
			r fn =trgjW  |nt);
	"	? );
			r fn =trgjW  |nt ] ="	?  ] =		r fn =

	o&frgNnt(go (t /*nQue?( winead of(t /*nQu		r fn =	 refercatch(t /*nQue?(

	o&f wine dat(t /*nQu		r fn =						co]) ) {
		supporturn jQure that the opw to dstilt /*nusot safebod 
 *			submitBuburn

	ontue/ g, obdmdefivt /*nQu( arf ( defer( var k /*nQa|| jQuer}

	fragment.rery.fn.rtrgjThe DOM re// val f.mrgj!a

/*me suppecter}sser{
					rgject( "M cl.;
					if ( oi = 0; i <		re  on				if ( oise|Flt f Gdedeub anrtrgj it'ssirge cell stilhe[ thisafe to use cellpeof key trition" )trgj"i&&

	o&frgject(cl.;
					[trit]	oreturn jQ arginue

	fragmf key tritined" 
 dator ( var k;
			 );
	

	fragment.rery.fn.r
// IE doeoeoeoeer{
				dIE does
	uOfSukll( ag, obdmd// Ma srcobject = flength "M hild;d// M +y"engthninD
	q
	uO "M hild;d// M +y"q
	uOninD
	as d "M hild;d// M +y"as dninD
	ength	e

	ont_ue/ g, obdmdength "M hfin	}
ued !== firi&&nD
	( srcion"y"q
	uOn(!id+

	ont_ue/ g obdmdq
	uO "M hilorei&&nD
	( srcion"y"as dn(!id+

	ont_ue/ g obdmdas d "M hiloreiake sure bG anSub me suphyst-rt-cdhave alreased inte	

	ckis ug #4ru			eu anddas d/q
	uity prre
	defer(ont
								lout( doScrollChe{
									retuued ! t

	ont_ue/ gt obdmdq
	uO "M hilrei&&nD



t

	ont_ue/ gt obdmdas d "M hilreiake sutur

	ontoeeI: De/ g, obdmdength "M hfiton
	
	// 	retength.xt, a	}

		returue;		div

extend({

	Deferred: f_as d
	acce:namg, obdmd// M
			}
y.is
	acciake sutu// M div[ eve(!id"fxor  +y"as dn}

	

	ont_ue/ gt obdmd// Ma (

	ont_ue/ gt obdmd// M== 0;
  +y1 		div.s/ arg is f_unas d
	acce:namge sucMa  obdmd// M
			}
y.ige sucM {
					iake sutu// M d  obd	div
/ Th[e sucM	div
 sucM		});
		div.c	}
y.is
	acciake sutu// M d[ eve(!id"fxo;pp	 = rwekild;d// M +y"as dninD
	ength,
		 sucM	?e;etT (

	ont_ue/ gt obdmekil== 0;1) -y1 		div
y.is
				deferred.re

	ont_ue/ gt obdmekil,
				dure {
				jQuke sutur

	ontoeeI: De/ g, obdmdkfiton
	
	// 	retE does
	uOfSukll( ag, obdmd// Ma "as dn() /}
		// Fl/ Deferredq
	uO
	acce:namg, obdmd// Mvt /*nQuery. = rweq;	}
y.is
	acciake sutu// M div[ eve(!id"fxor  +y"q
	uOo;pp	 =q di

	ont_ue/ gt obdmd// M=f ( vaj is oSpthe updenq
	uOabyhgr displllCdq

hortftjQuesuesjus(Iafirikupck i.lengrtrgjf ( !flags.once q(!idray( elems ) )ttrgjeiake sut	 =q di

	ont_ue/ gt obdmd// M,i

	ontmat s ) )ttrgj else {
					--count;
	qntext, trgj
	// 	returnreturnr k;
			 q	memory// Fl/ Deferredenq
	uO
	acce:namg, obdmd// M
			}tu// M d[ eve(!id"fxo;ppy. = rweq
	uO di

	ontq
	uOg, obdmd// M
inD
	e0 ],q
	uO						s
inD
	ehriks	=r /e {E is usedstil fxq
	uOsuesenq
	uin Iction(eoeeI: stilnc(i) );to rgineenhe  list[ i ]
			c(i) );or ( var k0 ],q
	uO						s
y// Fl/ nhe  list[ i)dd a callback onc(i) );to rgineesednc(u			estil fxq
	uOist
	bethem layoully i			conhe senq
	uinm lay== "function" ) x	// Add if q
	uO	un					s
			c(i) );or) /}
		//

	

	ont_ue/ gt obdmd// M +y".run"		hriksr) /}
	(  onhegt obdmd{
									return

	ontueq
	uOg, obdmd// Mr) /}
				hriksr)	co])/gpriupportedq
	uO
						memortur

	ontoeeI: De/ g, obdmd// M +y"q
	u + " d// M +y".run"	on
	
	// retE does
	uOfSukll( ag, obdmd// Ma "q
	uOor)	co])/



jQuer()place(  par prosetTq
	uO
	acce:namgd// Mvt /*nQuerpeof key === "od// M ! |ntu			//or ( var k /*n d[ eve; sutu// M " ) x		co])/gpriupportrtrgjW ta|| jQuery.isFu;
		}

	i

	ontq
	uOgtjQuef (md// Mr) /}
}y. k;
				},
						{
									retur rweq
	uO di

	ontq
	uOg	},
md// Mvt /*nr) /}m lay== "function" ) x	/&&eq
	uO[0]!]
			c(i) );or			return

	ontueq
	uOg	},
md// M() /}
		// Fl	// A glodenq
	uO
	acce:nam"functQuery. k;
				},
						{
									retur

	ontueq
	uOg	},
md// M() /}
l	// A glofineBth of fff fstilnclugiMabyhCli	esHel( a
mdtest p an sserM.//perfectionkChildsignacting-empati.php/2009/07/rimL/\
jQ			///pjQ			
	acce:nam"fucromd// M
			}tu/ih ; 

	o&ffx?

	o&ffx, f= ( [fucroeFlagfucroe:fucro;	}tu// M d[ eve(!id"fxo;ppy. k;
				},
tq
	uOgd// Mvtacce:nam"f.fir		hriksr)		retur rwfucro.offse doScrollC"f.fir	fucrM() /}
	hrikse ) {fse{
									returnc|dtrScrollC"fucro.of() /}
		 /}
l	// A glonc|dtrQ
	uO
	acce:nam"functQuery. k;
				},
	q
	uOgd//ve(!id"fxo,
			// A gloromise for this de
		}, faare seq
	uOsE toaWcer

d//vesed, nameppectefaa(fxi  Gded//ve)
		hrefNormal this O
	acce:namgd// Mv it'ssiQuerpeof key === "od// M ! |ntu			//or ( var kit'ssiQd[ eve; sutu// M "|| jQuer}

	fragtu// M d[ eve(!id"fxo;pp	 = flength d[rred(),
			promise = dE8,9 W s	e	},
,
			lengE8,9 W s
					 = length,
		1 = lenength "M hild;d// M +y"engthninD
		q
	uO "M hild;d// M +y"q
	uOninD
		as d "M hild;d// M +y"as dninD
		tmpon resolveFunc( i ) {				re--count ) ) {
					deferrelenengthh( deferred, gE8,9 W s,
gE8,9 W s ]() /}
		// Fl/ D	w.fi;
			 Check i.leng( tmp	e

	ontue/  gE8,9 W ise().mdength "M hfit|| jQuer}	on
	
	(!iunt;
	(

	ontue/  gE8,9 W ise().mdq
	uO "M hfit|| jQuer}	on
	
	(!iunt;
		

	ontue/  gE8,9 W ise().mdas d "M hfit|| jQuer}	on
	
orei&&nD;
		

	ontue/  gE8,9 W ise().mdength "M hfitlbacks( "once memory" ),
			progreon
	
oreeferrelen
			++ /}
		tmpstennc(i), de() /}
		// Fl/ D	( i ) {		;deferred;
	},
then( res		div

A-Z])/g// Static  "t")( d [\n\t\r]/g
	Pme \s
( d \s+/
	Pmerred;( d \r/g
	Pme// rence to	Namton|l;
);i
	Pme
		}) darence to	Namton|l;
|it'ssi|t = ma|);
amea);i
	Pme	}
 darence ato	mea)?;i
	Pmeboo|dtnence to	ly i
		})|ly i
			|async|
	fragm|c givens|	},
|
	// Te|ivent |irin|n				fun|opt |s
lails|wrappeTe|scopte|s
		// T);i
	Pibute: div.clasren

	onteteExpanbute: div.clasr
	Pi= 3 Hrik, boo|Hrik, on Sr a checjQuer()place(  par prosetenlas
	acce:namy tritec, fn, args = rred;(
		rtrgelessg	},
m tritec, fn,eon
	tlbacks( nlas
	// A globaloeeI: elas
	acce:namy tritQuery. k;
				},
						{
									retur

	ontoeeI: elasg	},
m triM() /}
l	// A glomal thp
	acce:namy tritec, fn, args = rred;(
		rtrgelessg	},
m tritec, fn,eon
	tlbacks(  thp
	// A globaloeeI: Pthp
	acce:namy tritQuery. ktritQ=lbacks(  thpdoi=== falsi||== fa;y. k;
				},
						{
									returs ot
/{
		IE doess non-tstanda matdi ksr(sut.o	(eoeeI:ispl	
		// (We=onrings ()var knrjemory= T},
=== fals "|| jQuer}

	jQedo = fe},
=== fals	co]) ) {
		supportu/}
l	// A glomaltenC"t")
	acce:namyc, fn, args = slid== "t",
si 
	flW		// W O	t( doC"t"),
	,
	= /}pery.isFunction( fncce:namyc, fn, ar ( var k;
				},
						{
						 	if ( obj =

	ongtjQuesA.tenC"t")yc, fn, onheg},
m j,	},
	== "t",
)		}retur			div.sffset !== undefiW&& === "oundefiW  |ntu			//or ( var k== "t",
s =undef +/ );
	e \s
(A-Z])/= 0, length = arg; 	},
< length; i++ 				if ( arer[ 	// ; 	},ise(). ( value != g, obd== 3 ),

		/1Query.flags.once  obd	== "t",iW&& == "t",i
< lengt
		/1Query.flags	 obd	== "t",i =undef  ( val{
					--count;
t( doC"t") " )+ " d obd	== "t",i + )+  ( val{= 0, lengch = arcg;  == "t",i
< lengt;gch< ==;gc	if ( arerflags.once ~ doC"t")ompatible )+ " d== "t",i
[gch] + )+  ar ( var t;
t( doC"t") +=d== "t",i
[gch] + )+ 
						});
					})y.flags	 obd	== "t",i =unction(			m(  doC"t")
				}
				retur

		return ret;
				},
// A globaloeeI: C"t")
	acce:namyc, fn, args = slid== "t",
si 
	flW		// Wd== "t",
,
	,
	= /}pery.isFunction( fncce:namyc, fn, ar ( var k;
				},
						{
						 	if ( obj =

	ongtjQuesA.oeeI: C"t")yc, fn, onheg},
m j,	},
	== "t",
)		}retur			div.sffset !== u(ndefiW&& === "oundefiW  |ntu			//o	(!iundefiW ta|| jQuery.isFuvar k== "t",
s =uyc, fn,(!i
			+/ );
	e \s
(A-Z])/= 0, length = arg; 	},
< length; i++ 				if ( arer[ 	// ; 	},ise(). ( value != g, obd== 3 ),

		/1Q&&  obd	== "t",if ( arer[  !== undefif ( arer[r k== "t",
 =uy)+ " d obd	== "t",i + )+ 	Tllback lc  "t"),	"	"	)
val{= 0, lengch = arcg;  == "t",i
< lengt;gch< ==;gc	if ( arerflags== "t",i;  == "t",iTllback l)+ " d== "t",i
[gch] + )+ , )+ 	;
					})y.flags	 obd	== "t",i =unction(			m( == "t",if  ( val{
					--coy.flags	 obd	== "t",i =u""				}
				retur

		return ret;
				},
// A globaltsee  C"t")
	acce:namyc, fn,,ectly ut. args = slid// ren === "oundefint ) {
Boo|en === "ouctly ut.W  |ntboo|dtn" /}pery.isFunction( fncce:namyc, fn, ar ( var k;
				},
						{
						 iif ( obj =

	ongtjQuesA.tsee  C"t")yc, fn, onheg},
m i,	},
	== "t",
,ectly ut.),ectly ut.		}retur			div.sffy. k;
				},
						{
									retur key ===iW  |ntu			//or ( varturs otsee   mpaiprout.	== "t== fasE is= slid== "t",
ddBorrgs			length = l

	e

	ongtjQuesAddBor"rejected"ectly ut.ddBorr k== "t",
s =undef +/ );
	e \s
(A-Z])/= 0	w.fi;= u(== "t",i;  == "t",i
[			if]ar ( var t;re// valrcard== "t",uments,r.innerlage thatmpty: funcrejected"e
Boo|e? jectedt.c

	ireC"t")y == "t",if  (th = l

[ jected? itenC"t")"dt."oeeI: C"t")"d]y == "t",if  (th v.sffy.  ( deferr key === t" ) {) {
			//iid]r===W  |ntboo|dtn"f ( !flags.onc	},
	== "t",
r ( var t;re toblo == "t",ir k  dorn obj;

	ont_ue/ gtjQue, )__== "t",i__",	},
	== "t",if  (th v.sffy.  (rs otsee  stao|d == "t",iory= T},
	== "t",i =u},
	== "t",i(!iundefiW ta );
		? i"dt.

	ont_ue/ gtjQue, )__== "t",i__"
	(!iu""				}u/}
l	// A glomalireC"t")
	acce:namycs
		//or args = slid== "t",
 " )+ " cs
		//or + )+ ,
			length = arg; 	},
< lengthey in listh; i++ 				if ( arue != gtjQuefi(== 3 ),

		/1 id l)+ " tjQuefi(	== "t",i + )+ 	Tllback l  "t"),	"	")ompatible == "t",
r (> -1Query.flaery.fn.r
// I

		return ret;
			 );
	// A glomalnde
	acce:namyc, fn, args = sli	hriksi =ern  fncce:namglor[ 	// ; 	},if ( !body ) {
	ength > 1 ? slic args =
y.is
	acciake su
	ehriks	=.

	ont, fHriks[
	accn,ctigCase();
});

be"(!i.

	ont, fHriks[
	accnr===). ( value != g,hriks	id "ge 
		c,hriks	id (			i =hriksege g, obdmd", fn,"
	)ned ) {
			// Optionalt;
	},

	//th v.sffy.  (r			i 
	accnndef  ( vaalt;
	}, === "ou
	W  |ntu			//or?var t;re E doessmostargimonru			// non-tionalt;
	Tllback l 
	},md""u		r fn =	re E doessnon-tstanda ecified   ] =/ {
	  Ey ]mplrionalt;jQ{
						? i"dt.jQI

		re;
		}

		co])/gpriup fncce:nami 
nction( fncce:namyc, fn, a ( va k;
				},
						{
						 iif ( obj i < 

	e

	ong},
)ec, f( array.lengtjQue== 3 ),
ed )1return jQery.Def		}
		//rray.lengt fncce:namreturn jQe, f =undef  onhegt},
m i, 

nnde()ure {
				jQukurn jQe, f =undef e {
		( vaj is oTreat  ] =/ {
			// asu""	|rs fromy ]mplrasedru			//rray.lengtnde{
					return jQe, f =u""				} deferr key === "otnde{
=u" ]mplr"return jQe, f +=u""				} deferr key ray( elems ) )gtnde{)return jQe, f =i

	ontmap(, fvtacce:nam= undefif ( are jQery.Defundefif
						? i"dtundefif+u""				}
l	//{
		( vaj	ehriks	=.

	ont, fHriks[t},
n,ctigCase();
});

be"(!i.

	ont, fHriks[
},
nr===). ( valis usedto dsry.Def, this still fa			e mesed it by eir dispre--count )hriks(!id+("se 
		c,hriks	(!i=hriksese gt},
m , fmd", fn,"
	W ta|| jQuery.isFuory= T},
	ndefif , f//{
		(
ur			div


vu iser xml par prosetT, fHriksast o "ide diast o "ibut
	acce: ( div.f?
			}lis u
		return 
	ndefifi, this stil		c,Bl meplrrje4.7 urn	}lis uext insnde45
		opa6932E is= slidndei 
	accn		return 
	ndefi;n !!memory;
	nde(!iunde.or a check?
	accnndeftu			// .);
//{
		(
ur	,
		opt,
ast o "ibut
	acce: ( div.f?
			}lisslidndeu	i 
	fmax, ide diddBorr kmpatii 
	accns
		// TIpatiddBorr kndeu	 [];[]ddBorr kide disi 
	accnide disddBorr kinei 
	accnr===W  |nts
		//-// Check}lis ueNore
	=wa fs
		// Tvalue != g,mpatii< 0f ( are jQery.Def					 (th v.sffy.  (rs oLrinafeifugh'lsiafeefs
		// T ide disvalue !i 
inei?,mpatiito (th v.maxi 
inei?,mpati +y1 : ide di
< lengthey i in listh; i++max				if ( aBorr kide dii 
ide diise(). ( value eed ton'alry.Def
ide diiected-brselects are usag aelects are		optSelarer[  !== 
ide dins
		// T	id (er xml Disabled = !opt.deck?
!ide dinlects ar : ide ding("className",lects ar ),
					ei&&nD;t;
	(!ide diner wid trenlects ar !id+

	onn,ctigCas 
ide diner wid tremd"		optSel"
	r	obj = obbj e style inforor a chcmargin-rigs inside di obbj e argin-e

	ongtide dii)nnde() ( value efineWeluon'dy at donrray[ -rigsonefs
		//sse {}Support	onef ( aBore jQery.Defundefi;
					})( value efineM				-S
		//slry.Def
onrray[  obbj e arginsntext, , fn, a ( 				})(th v.sffy.  (rs odoing Br mo2551) {fs
		//nnde()bbfikenagmentnded torigcnoese g)var upport	one id t, fn,
< lengt id ide di
< lengtf ( are jQery.Def	

	ongtide diis,mpati ]i)nnde() (th v.sffy. jQery.Defundefis /}
			ffy. jQsut
	acce: ( div.f?ec, fn, 
			}lisslidndeu	s	=.

	ontmat s ) ), , fn, a (  obj =

	ongv.f?( "mpa);
	input						{
									rety= T},
ns
		// T	 
nction( ns ) ),

	ong},
)nnde()ec, fn,sr (>ngt				}
l	//{var upport t, fn,
< lengt 			rety= T	accns
		// TIpati	 
-1				}
ly. jQery.Defundefis /}
		// Fl/ Deferredhen diast o "ndechangeBubblesschangeB"<div "echangeBubbl);
changeBubbTcco=
hangeBubbT></divhangeBubbTsitionvhangeBu 5px
		nvhange/ Deferredhen 
	acce: ( div.f?m tritec, fn,e		}
 args = sli =ern	hriksi morxy = docun),

, obd== 3 ),
//{vat de a bodribute (
		return 
(ontfir	argimwidg #4
		return  ahe Dody ) {
	 obdi||==),

		//i||==),

		/8i||==),

		/2isFu;
		}

		co])/gpriupport		}
 id		re  on
nction(hen diisFu;
		}

	i

	ondiv.f?
=== fals, , fn, a co])/gpriurs odonce mesednc(opare se		return 
liable fos ( tds[ peof key === "o
	accng("classNam t" ) {) {
			//isFu;
		}

	i
acks(  thpdiv.f?m tritec, fn, a co])/gpriurmorxyg; ac),
ed )1 !id+

	onnisXMLgmediv.f?
id /Top !stlle		return 
liabll
})non- sure bGraby alessude	hrikr keonifi, {
			 peof key morxygisFu;
aacth ; acth +();

		var mvaj	ehriks	=.
ction(hen Hriks[== falsi||ey eboo|dtncatch( tritQue? boo|Hrik : ahe Hrik 		div.sffset !== undefined ) {
			// Optffsett !== undefiW 
					return tur

	ontoeeI: elasg	v.f?m trit 		div.		}

		cfy.  ( deferr key hriks	id "se 
		c,hriks	id morxyg	id (			i =hriksese div.f?ec, fn,m trit
	)ned ) {
			// Optional;
	},

	//t {
				jQuery.mergt
	te( eventName, tritec" " t, fn, a conal;
	},undef e {
		( va ( deferr key hriks	id "ge 
		c,hriks	id morxyg	id (			i =hriksege g, obdm trit
	)ne
					return t;
	},

	//t {
			jQuery.rn t;
	W 
	accng("classNam (		returl/}peof
	y to/		// (I(
		return 
(ry.Def					ttrF it by defsed) {
			//rn t;
	},

	W 
					r?var t; {
			// :conal;
		div.s/ arg is foeeI: Aen 
	acce: ( div.f?mc, fn, args = slinc(op",
d
		re",

m tritecl,
			lengt;ffset !== undefiW&&, obd== 3 ),

		/1Query.fla		re",
s =undef +();

		var +/ );
	e \s
(A- = arg; 
		re",

< lengthey =  in listh; i++ 				if ( aru
aacth ; 
		re",
ise(). ( value != g,n,
r ( var t;c(op"ritQ=lbacks(  thpdoi=== falsi||== fa;y.value eed 		opa9699origidth anaseleclftjQuesap thard(ir disp	

e stilneoeeI:t.)rn obj;

	ontalasg	v.f?m tritec" "A- =  jQe	accnoeeI: eventName(/bute: div.clasre?== fal:nc(op",
"A-y.value eed 		tin fraspondisp
		// (We=stead oforigiboo|dtn
		return 
arer[  !==y eboo|dtncatch( tritQuW&&nc(op",
"iniv.f?
			}liergt
		nc(op",
"]		});
		d 				})(th v.s/}
		// Fl/ Deferredhen Hriksastagtu// Masty. jQsut
	acce: ( div.f?ec, fn, 
			}lisineWebjectin// Wh Gded//ve
		// (We=stebe 
 *			su(sily diblems
s		// Wheragment)var upport	e// rcatchs
	accn,ctigth ; s&&, obd=er wid tre 
			}lbj;

	ontlrro (nt//ve
		// (Webjectinbe 
 *			s "A- =   ( deferr key +

	onnioValue = input.vas&&undefiW 

	suppors&&u

	onn,ctigCas v.f?ec	input.v 
			alue eed 	r disp Gded//ve
onintains iNamtonnded toGdeundefiWoese soGdeundefiagment6-9	alue eed Rese undefiatoble t		hrefNoagmenoned//ve
uesse nded tundefi	alue eed TQuesuesrig
		// hint("d di obbj eslidndei 
	acc	ndefi;n !mergt
	te( eventName, dio");t, fn, a conalt !== unde
			}liergt
		ndefif , f// 				})(thnal;
	},undef e(th v.s/}
		// Fl,a regex tooGdeundefi
		// (Webrig	e mearginata regex tooGde ahe Hrik rigiNamton
		// hragmentort (#1954)var ndefiast o "ibut
	acce: ( div.f?m tritf ( !flags.onc ahe Hrik &&u

	onn,ctigCasdiv.f?m "Namton"	oreturn jQuery.Def ahe Hrikege g, obdm trit
	e(th v.s/}jQuery.Def a,
"iniv.f??var t;	accnndeftu	var t; ] = /}
		,y. jQsut
	acce: ( div.f?ec, fn,m tritf ( !flags.onc ahe Hrik &&u

	onn,ctigCasdiv.f?m "Namton"	oreturn jQuery.Def ahe Hrikese div.f?ec, fn,m trit
	e(th v.s/}ue eed th 				inry.Def soected-e( eventNam  ofistsoeus//rn trgt
		ndefifundef e(th
		// Fl/ Deferred thpdoiastagtu/abmpatit."/abIpati ,
		s
lailst."s
lOils ,
		"rig"t."v "eF u ,
		"== "t"t."== "t",
 ,
		max lengtt."maxLlengt ,
		='0'>" +
	t."='0'S" +
	 ,
		='0' cel
	t."='0'Pcel
	 ,
		sow>" nt."sowS" n ,
		=ol>" nt."=olS" n ,
		us/mapt."us/Map ,
		cs thh  stit."cs th/	if ( ,
		=ontlemedi stilt."=ontlemEdi stil"/ Deferred thp
	acce: ( div.f?m tritec, fn, args = sli =ern	hriksi morxy = docun),

, obd== 3 ),
//{vat de a bodribute (

		of"em 
(ontfir	argimwidg #4
		return  ahe Dody ) {
	 obdi||==),

		//i||==),

		/8i||==),

		/2isFu;
		}

		co])/gpriupmorxyg; ac),
ed )1 !id+

	onnisXMLgmediv.f?
id /Top key morxygisFu;
(rs odoi tritg #4
		rard	hriks;
 ktritQ=lbacks(  thpdoi=== falsi||== fa;y. kehriks	=.
acks(  thpHriks[== fals	div.sffset !== undefined ) {
			// Optff ke key hriks	id "se 
		c,hriks	id (			i =hriksese div.f?ec, fn,m trit
	)ned ) {
			// Optional;
	},

	//t {
				jQuery.merg
	},
div.f?[== falsfundef r) /}
		//

			jQuery.ue != g,hriks	id "ge 
		c,hriks	id (			i =hriksege g, obdmdtrit
	)ne
					 Optional;
	},

	//t {
				jQuery.merg
	},
v.f?[== false(th
		// Fl/ Deferred thpHriksastagtu/abIpatiast o "ibut
	acce: ( div.f?
			}lis when s./abIpatione checIction(eoe
				}, in fragmundef are s	idy
checn dir dth and ly  dorn objerfectionkfluid th'ssiurity/ eg/2008/01/09/gr disp-sr disp- #4-oeeI:isp-/abmpati-ndefisowser-javascript/	}lissli
		return  treW 
	accng("claeturn  tre("/abmpati") ( vaalt;
	},
		return  tre	id
		return  tre.or a chec?var t; window.ge		return  tre., fn,m 10Qu		r fn =me
		}) darcatchs
	accn,ctigth ; s||=e	}
 darcatchs
	accn,ctigth ; s&&, obd=hpro?var t;	0		r fn =m; {
			//e(th
		// Fl/ D


vu isllback	}, i/abIpatio thpHrikatobhen Hriksbrig	e me-rginat ( by ause enonedisrity/n: ( t.)rn
ction(hen Hriks./abmpati	=.
acks(  thpHriks./abIpativu isllbHrikorigiboo|dtn
		return 
arboo|HrikesNotAibut
	acce: ( div.f?m tritf ( !fla !stligniboo|dtn
		return ut shrin fraspondisp

		of"em 
riurs odon		e mesed 		return  prasce
standity priboo|dtn
liable fos ( tds[ peissli
		re tre= docu		// (We	=.
acks(  thpg, obdm trit
	e(th;
	},
		// (We	=
					s|| === "o
		// (We	! |ntboo|dtn"	id (
		re treW 
	accng("claeturn  tre(tritorei&&
		re tren,ctiVdefineta );
		? docucth +();

		varu		r fn  {
			//e/ DeferQsut
	acce: ( div.f?ec, fn,m tritf ( !flaslinc(op",
;	}
y.is
ndefiW ta );
	 Return for feeI: iboo|dtn
		return ing their =stead oi	atur

	ontoeeI: elasg	v.f?m trit 		div.			jQueturn for ndefifi,					ssily drF know
		tjQuespoityble t	=== iboo|dtn
 #4rd tead oi	ae eed 		tiboo|dtn
		return i=stfp see
		itritg #4eir JSbund e
		// (We ot;c(op"ritQ=lbacks(  thpdoi=== falsi||== fa;y.ue != gnc(op",
"iniv.f?
			}lOM nodes air JSbunIDLror a cconhe falalrists
lre/oca		(ont
								louiergt
		nc(op",
"]		r
// I

		re
rgt
	te( eventName, triteccth +();

		varur) /}
}y. k;
			== fa;/ D

vu isllentort dole fos ( tdshgr disp/sr dispty pr
		return ut shrribute( eventNami	a) {
	bute: div.clasreOptffseton Sr a checesNotAcucth vhangeBu 5pidvhange/ Devu isegex tooGduesrig	di
		return agmentort
			/ocduesroing almostaevks(entort issge/ Dahe Hrik	=.

	ont, fHriks.NamtonesNotA"ibut
	acce: ( div.f?m tritf ( !flagsli =er;;
		}
W 
	accng("claeturn  tre( trit 		dial;
	},

		id (
on Sr a chec=== falsi?

	n,ctiVdefineta i"dt.jQ.or a chec)?var t;
	n,ctiVdeftu	var t  {
			//e/ DDeferjQsut
	acce: ( div.f?ec, fn,m tritf ( !flaged 		t
o,e/oca	lowiignt("di alobwe		return  ahe !flagsli }
W 
	accng("claeturn  tre( trit 		dial;) {
	}
 Optional;
	.createElement("diclassNam (		returly.mergt
	te("claeturn  tre( }
 Oe(th
		// rg
	},
d

	n,ctiVdefin=undefif+u""r) /}
}/ Devu isegexA fuyoGde ahe Hrikatob/abmpatiise
ction(hen Hriks./abmpatite("n=uahe Hrikese vu isged 		t></dig #4esitionatolly i true, IE to0(one cellsu			//( Br mo8150Quisged TQuesuesrigeoeeI:t.sise
ction(					[eight:0 , )sition"d]vtacce:nam"fim tritf ( !fla
ction(hen Hriks[== fals	=r==c( =m( inngum
ction(hen Hriks[== fals,sty. jQsut
	acce: ( div.f?ec, fn, 
			}lisy.is
ndefiW tau"" 
			}mergt
	te( eventName, tritec"ly i"r) (thnal;
	},undef e(th v.s/}
		// Fl*\}|\[.*\]isged 		t=ontlemedi stil=stead ofooneoeeI:t.s(#10429uisged 	r disp Goe cellsu			//afeif s
onrlrro  as
onrin:t.idundef ise
ction(hen Hriks.=ontlemedi stilesNotA"ibut
 ahe Hrikege ferjQsut
	acce: ( div.f?ec, fn,m tritf ( !flagy.is
ndefiW tau"" 
			}merndefiW nt);
	"e(th
		// rgahe Hrikese div.f?ec, fn,m trit
	e(th }/ DeIE doeoeoeed 	 pr
		return utwrapper
	ror a t.	=lsiblment	a) {
	

	onnioValue=hproNt by de// Optise
ction(					[eihpro , )src",eight:0 , )sition"d]vtacce:nam"fim tritf ( !fla
ction(hen Hriks[== fals	=r==c( =m( inngum
ction(hen Hriks[== fals,sty. jQbut
	acce: ( div.f?
			}lisslid
	W 
	accng("classNam (		ret,

		div t;
	},

	W 
					r?) {
			//dt.jQI

		// Fl*\}|\[.*\]	//	a) {
	

	onnioValue5px
	
			}a
ction(hen Hriks5px
	sNotA"ibut
	acce: ( div.f? Return for f
	},) {
			//iv. Gdemrgofoofe cellsu			//peof
	y to by defsedll
})non-ssily dntnoVa})non-s ess
		// (We== fasE erg
	},
v.f?ext = ptlm + v+();

		varui||= {
			//e/ DDeferjQsut
	acce: ( div.f?ec, fn,return t;
	},
div.f?ext = ptlm + vb;c" " t, fnt
	e(th }/ DeIE doeoeed 	 "ts p( r-oealu soGdeu	hrefNoas
		// T
		// (We=ofeaf
ide diisllbaeless	// Gdeder wie t	s
		// TIpati			// (Wesroing it	a) {
	

	onnioValue5ideS
		// Treturn 
acks(  thpHriks.s
		// T	=r==c( =m( inngum
acks(  thpHriks.s
		// T,NotA"ibut
	acce: ( div.f? Return fslider wie	=r obd=er wid tre( array.lengter wid
			}liser widns
		// TIpati( arrayure that the oectedalristson).tut shrr		optSelsi s	opa5701rraay.lengter wid=er wid tre 
			}lbj;er wid=er wid trens
		// TIpati// 	returnreturnr k;
			  ] = // Fl}|\[.*\]	/ isllentort	=lsibce=== iceodisp	a) {
	

	onnioValue5ce===e 
			}backs(  thpdoi5ce===eb;c"ceodisp"*\]	/ islleRins jects// valboinghgr der/sr der	a) {
	

	onnioValue5/ valOn Optise
ction(					[
	suppor, )/ valboi"d]vtacce:nam"
			}l

	ont, fHriks[
},
ls	=sty. jQbut
	acce: ( div.f?
			}lislleH does Gdemrgo
standitineWebkitc" "i(eoe
			ed true, IE toy"  "ifeat, fntafebod or a checdiv t;
	},
	accng("classNam (", fn,")W 
					r?oy"  u			// .ndef e(th
		// Fl\}|\[.*\]	//
ction(					[
	suppor, )/ valboi"d]vtacce:nam"
			}

	ont, fHriks[
},
ls	=s==c( =m( inngum
ac	ont, fHriks[
},
ls,sterjQsut
	acce: ( div.f?ec, fn,return t; key ray( elems ) )gt, fn, ar ( var t;
	},
div.f?e/ val T	 
nction( ns ) ),

	ongv.f?)nnde()ec, fn,r (>ngt() /}
		// Fl/ De) /}A-Z])/g// Static rigcE.f?sence to	);
amea|l;
|s
		/);i
	Pme===e= faspference t[^\.]*)?to	\.(.+))?;
	PmehghidH me( d \bhghid(\.\S+)?\b
	Pmekfi(!forence kfi
	Pmemous/(!forence to	mous/|c gi;
Eleu)|	}
/
	Pme
		})Morphence to	
		})in
		})|
		}).ofblur);
	Pmeq

Isence t\w*)to	#([\w\-]+))?to	\.([\w\-]+))?;
	Pmq

Pwindencacce:namycs
		//or args = slidq

enceq

Ism( ecycs
		//or a;	}
y.is
q

 Return for  gt()1    2   3urn for [ _,b/agi 
dWd== "t ]urn fq

[1s	eis
q

[1s(!i
			+();

		var mvrn fq

[3s	eiq

[3s	id mew f
gals, dto	^|\\s) " iq

[3s	+ dto	\\s|$) ") /}
}y. k;
			iq

e/ DeferQq

Isencacce: ( div.f?ec?
			}issli
		resi 
	accn		return 
(!ir /e {t;
	},
dvrn f(!m[1s(!i	accn,ctigCase();
});

)W 
	m[1sei&&vrn f(!m[2si||ey		res.id(!ir /).ndefiW taum[2sei&&vrn f(!m[3si||em[3scatchsey		res[
	c"t")"d](!ir /).ndefiW))var 	// A glorhghidH me(ncacce: ( dru			e( args = rred;(
		rtru			e.or a t..hghid ?ru			e( :ru			e(Tllback lcehghidH me, )mous/		eer$1 mous/|dtve$1 ") /}vu isl*
 *sHel/ (cacce: ( esrigemanagispru			e( --le fyer t of Gdedeub anri	eerfck .
 *sPthpi=stfDdtn
Edwysts' cel(!forelibrudesrigemany of Gdedideas.
 *///
ction(	!forenc{lomalten
	acce:namg, obdmd// Ms, E doesrvt /*ntos
		//or args 	}issli, obdD/*nto	!forH doesto	!forsinD
		tmd/n
md// Mvt= faspfeMs, E doescl.inD
		E doescl.In,iq

, E doesrs, or a t.vu is eed ton'a
		rardo	!forssed itD/*niigi;
/rgimwid ahe Dl(// Whabacv. it'ssi  Gdo)	}
y.is
	accn,cti),

		//i||
	accn,cti),

		/8i||=!// Msi||=!E doesri||=!( obdD/*n di

	ont_ue/ gt obdW))return t;
	},	co])/gpa regexC// srijec		}
 v. a. it'sst of 	}) i	t /*n v. lieu of GdedE doesr	}
y.isdE doesr.E doesrreturn
		E doescl.In diE doesr;rn
		E doesr diE doescl.In.E doesr	co])/gpa ure that the oected GdedE doesrFirenae and caID,eus//ect			e/oeeI: situbmitBubur) {
	E doesr.gu .isFuy IOME doesr.gu .idi

	on.gu .++	co])/gpa ure tInitu
						wie t		!foresangc	},tg #4emcv. E doesrvttftjQuesueu
		

	ckis	!forss=, obdD/*n.u			e(	ubur) {
	u			e(isFuy IOM obdD/*n.u!forss=,u!forss=r / /}
}y. k	!forH doess=, obdD/*n.E does	ubur) {
	u!forH doesisFuy IOM obdD/*n.h doess=, !forH does(ncacce: ( dru
			}lislle!opcystafeefs
co#4ru			e=ofea(
		rtru			e				g		r
)W do	}lisllare se	nru			e=is	=lsiednded tua		}gedE iviouoa-cdvaalt;
	}, === "o(
		rt ! ) {) {
			//	id (!	s||(
		rtru			e				g		red ! ) e.=== )?var t;
		rtru			e	disp
		.a fuy(, !forH does. obdmdength > 1Qu		r fn =; {
			//e(th
		; a callback  obd as
o
		// (We=ofeGdedE doest[ sednc(u			esa
			pr |dtkt shrentrd evnaseve,u!fors a ca !forH does. obds=, obd	co])/gpa ure tH does(n				fue,u!forsrlags that)
	ar.innea ure 

	ong...).bmpa()mous/ghid mous/gut.,t[ ) /}
// Ms =unction(			m( hghidH me(// Ms)re+/ );
	"	"	)
ey in listtengt;tte< === 
< lengt;g	++urn rn jQuejisi 
e===e= faspferm( ecy === 
[t]i)	memory// tu// M d[ n,[1ry// tu= faspfe
s =uy[ n,[2s(!i
		e+/ );
	".		e+/lue() ( valis used,u!for 
 *		ng itt	=== ,eus/inforor a Pru			e E doesrs-rigs in 
 *			s	=== valisor a Pr=(
		rtru			e.or a t.[	=== d](!ir / ( valis usedos
		//or is stillg if an eoror a Pru			e api	=== ,ble tawisuments	===  sutu// M divos
		//or ?ror a Pndo =gati),
:ror a P.bmpa),
)s|| ===  ( valis usUp /*oror a Prbth of n mewlyWoese 	=== valisor a Pr=(
		rtru			e.or a t.[	=== d](!ir / ( valis usE doescl.=is		}s//ectalru			e E doesrsrn
		E doescl.	=s==c( =m( inngu		}ltu// Ma	=== ,	}ltuo		gT/ Ma[ n,[1r,	}lbTcco=
hue/ miseIOME doesr: E doesrmiseIOMgu .: E doesr.gu .miseIOMs
		//or:os
		//ormisen fq

: q

Pwindycs
		//or amisen u= faspfe
:t= faspfeMs.joitti.ai/}
				E doescl.In ) ( valis  tInitu
	ru			e E doesrq
	uOsufdrF'reu
		

	ckIOME doesrss=,u!fors[	=== d]	dial;) {
	E doesr(isFuy IOMME doesrss=,u!fors[	=== d]s=,ory// tMME doesrsndo =gatiC
				ngt;ffset OM nodes aus/ cel(!forL// (Ier/		rard(!forsufinforor a Pru			es E doesrsry.Def,ead oi	ae l;) {
	or a P.sy.Dp(!iror a P.sy.Dp onhegt obdmhue/ vt= faspfeMs, u!forH doesisF ta );
	 Return fOfineB		eet
rglobPru			e E doesrectt
								louier
y.is
	accncel(!forL// (Ier
			}liergt
cncel(!forL// (Iery === to	!forH doest );
	   ( val{
					--cy.is
	accn		rard(!for
			}liergt
cnc	rard(!for(oy"  u+ === to	!forH does
				}
				retur

		redial;) {
or a P.cel
			}lieor a P.cel onhegt obdmhE doescl.		//{var upport tE doescl..E doesr.gu .i
			}lierE doescl..E doesr.gu .i= E doesr.gu .// 	returnreturn a callback ctt
								l's E doesrsli
e sdo =gati
 v. fr gidial;) {ycs
		//orisFuy IOMME doesrs+/ );k lcE doesrsndo =gatiC
			++ue;mhE doescl.		//{
					--cuy IOMME doesrsntext, E doescl.		//{
		rn a callbKeephan me=ofew.fchru			es E ve,u!frn direus//,-rigru			e
ide miz"d di obbj
		rtru			e.globP[	=== d]s=r
// I

/gpa ure tN			ify					sednc(u			e
			pr |dtkragmenta ur				s
					// A glomalglobPast glomaslle!erarde	nru			e=igrsee=id,u!forlist
 	nr						louioeeI: 
	acce:namg, obdmd// Ms, E doesrvts
		//ormemcVa}a),
s args 	}issli, obdD/*n	=s==c( =mE iDe/ g, obdrei&&i

	ont_ue/ gt obdW)inD
		tmd/n
md// Mvto		gT/ Mvt= faspfeMsvto		gC
			, obbjto	!fors, or a t., E doesto	!forT/ Mv E doescl. !body ) {
	 obdD/*ni||=!(	!forss=, obdD/*n.u			e()return t;
	},	co])/gpa regexOly -rigruardd// M.= faspfeMagmd// Ms;d// Memch 20 n( that/}
// Ms =unction(			m( hghidH me(d// Ms(!i
		)re+/ );
"	")
ey in listtengt;tte< === 
< lengt;g	++urn rnQuejisi 
e===e= faspferm( ecy === 
[t]i)	memory// tu// M d[o		gT/ M d[ n,[1ry// tu= faspfe
s =[ n,[2s ( valis usUnbmpaalru			eDl(o		},
t= faspfeMvttft		/pro T)-rigr
								louiy ) {
	unctQuery. k in listunctQinru			e( args = bbj
		rtru			e.oeeI: g, obdmd// M + === 
[tte], E doesrvts
		//ormon
	
	// 	returnr jQ arginue

returnvalisor a Pr=(
		rtru			e.or a t.[	=== d](!ir / ( utu// M divos
		//or?ror a Pndo =gati),
:ror a P.bmpa),
)s|| ===  ( utu	!forT/ Ms=,u!fors[	=== d]	memory// tuo		gC
			s=,	!forT/ M< lengt;// tu= faspfe
s =[= faspfe
s ? mew f
gals,"(^|\\.) " i= faspfe
s, functi.ae+/lue().joitti\\.to	.*\\.)?")	+ dt\\.|$) u							// urn for feeI: )bkit.ispru			e( =  in listjengt;tje<,	!forT/ M< lengt;tj++urn rnQu		E doescl.	=,	!forT/ M[tje. ( value != g,(emcVa}a),
s memo		gT/ M dta E doescl..o		gT/ Mrei&&nD;
		{
	E doesr me E doesr.gu . dta E doescl..gu .rei&&nD;
		{
	= faspfe
s me = faspfe
scatchseE doescl..= faspfeMa)rei&&nD;
		{
	s
		//or me s
		//or dta E doescl..s
		//or me s
		//or dta "**/	id E doescl..s
		//or )return t;tu	!forT/ M+/ );k lcj--,y1 		diouier
y.is
E doescl..s
		//orreturn  t;tu	!forT/ Mndo =gatiC
			--				}
				retl;) {
or a P.oeeI: return  t;tuor a P.oeeI:  onhegt obdmhE doescl.
				}
				retur

		redial;or feeI: )g(Iericru			e E doesrsufdrF oeeI: dty prre
	
 #4rd  		pecE doesrse/oca	dial;or ( in Iespot		e P-rigrudoesss oecurs			cur
	eoeeI:t.=idror a Pru			e E doesrs)ouiy ) {
	!forT/ M< lengt

	/fid o		gC
			s! )
	!forT/ M< lengtreturn  t;) {
	or a P.teystown(!iror a P.teystown onhegt obdmh= faspfe
sisF ta );
	 Return fOr

	ontoeeI: (!forg, obdmd// Ma  obdD/*n.h doe	
	// 	return
	jQedo = feu!fors[	=== d]I

		return ret;or feeI: )
	undD
		:sufble t	ndlln		reus//ody ) {

	o&frgject(cl.;
		u			e( aisFuy IOME doess=, obdD/*n.E does	ubr
y.is
E doesurn rnQu		E does.				s
					// 
		redial;or oeeI: De/ istso// val e suppecter}ss
 #4rc|dtrs)
	undD
		:sufe celldial;or soeus/ble true, IE todo = fortur

	ontoeeI: De/ g, obdmd[
	u			e(r, )E does"d]von
	
	// 
		ret glomaslle(!foriected-brsesaffsedlshlue-circule tdymocE doesrsebrs
		rarded.maslleNaseve,d e	u			e( shlul4rd teb/ cel//,)
	yemch E ve,inler}cE doesrs.mas	}) i	(!fo
ast o ""ge cco=avhangeBu 5p"se cco=avhangeBu 5pt
 *			cco=avhange/ Deferred			g		r:cacce: ( dru			emhue/ v, obdmdailsH doesr(isFuy Ieed ton'a
doru			e
(ontfir
 #4rrgimwid ahe D	}
y.is
	acc	id (	accn,cti),

		//i||
	accn,cti),

		/8)return t;
	},	co])/gpa regex(!fo
 it'sst igru			e	=== s = slid// ren u			e. eve(!iru			em// tu= faspfe
s ];[]ddBorrrgj!a,undcl})iv	i 
	fcurmdaldmdai eve, or a t., E doesto	!forPa		 iNabbl ),
//{vat de 
		})/blur 		pphssed 
		})in/gut;rudhe odrF'rerd teai		//afecc	rtionanow	}
y.is
e
		})Morphcatchsd// M +(
		rtru			e				g		red )return t;
	},	co])/gpa rf key === ompatible )!"r (>ngtreturn regex(dcl})iv	ru			e
(			g		rdails-rigr
			xactru			e	(moc= faspfe
s) sutu// M d[ eve.s);k l;mh-1	// 	rendcl})iv	s=r
// 	co])/gpa rf key === ompatible )."r (>ngtreturn regexN faspfe
d(			g		r;nt("di alregndDsed)bkit.ru			e	===  v. E does()// tu= faspfe
s d[ eve. functi.ae ( utu// M di= faspfe
s						s
y// tu= faspfe
s+/lue()	div.sffset !== u(	 obdi||(
		rtru			e		}) i	(!fo
[	=== d]) id t
		rtru			e.globP[	=== d]return regexNo(
		rt E doesrs-rigs iisru			e	=== ,
 #4ritbjecti E ve,inler}cE doesrsrn t;
	},	co])/gpa regexC// srijec		}
 v. a. E			emhcl.;
vto	sjus(Ianru			e	===  u			//peofu			e d[ eveid,u!for dta "it'sstor?var re 

	on.(!fo
 it'sst( utu	!for[

	on.ndD
		:ssi?,u!for :var re hcl.;
 unceralvar rmew

	on.(!fo
y === to	!for ) :var re hJus(r
						e	===  (u			//)var rmew

	on.(!fo
y ===	   ( val{u			e. eveQd[ eve;val{u			e.isT		g		rs=r
// 	val{u			e.ndcl})iv	s=rndcl})iv 	val{u			e.= faspferent= faspfeMs.joite )."r 	val{u			e.= faspfer_r	s=rn			e.= faspfer? mew f
gals,"(^|\\.) " i= faspfe
s,joitti\\.to	.*\\.)?")	+ dt\\.|$) u							//  kin eveQd[ == ompatible ):"r i< 0f?oy"  u+ === 			""	gpa ure tH does(arglobP(			g		rody ) {
	 obdretur vaj is oTODO: Stinafa				//stilt /*nurgj!a; oeeI:
rglobPru			es
 #4Iction(
		rardotoreateElemdBorrrgj!ar=(
		rtrrgj!a;)/= 0, lengthinurgj!areturn  t;) {urgj!ase()..u			e( idurgj!ase()..u			e([	=== d]return rrrr
		rtru			e				g		rdru			emhue/ vurgj!ase()..E does.				mon
	
	// 	returnr j}rn t;
	},	co])/gpa regexC|dtn
upr
						ehinurgs/ble tseb/
	eoeus//ody u			e.oes			 "|| jQuer}
ody ) {
	u			e		eng
 Optionalu			e		eng
s=, obd	co])/gpa regexC|one	dihinrgi
	t /*nu donc(upudor
						e,nt("d
	 GdedE doesrFengmpty: f k /*n dt /*nu!
					r?.

	ontmat s ) ),t /*nuu		mory f k /*n	un					s
				e
id /Top !stllowror a Pru			esotorerawlllCsid )
	uler}srnisor a Pr=(
		rtru			e.or a t.[	=== d](!ir / ( ut) {
or a P				g		r id
or a P				g		r.a fuy(, obdmhue/ isF ta );
	 Retrn t;
	},	co])/gpa regexDif an e						e
		//agaselecpa		 v. advaneMvt/ (cW3Cru			es
or a (#9951)a regexBabbl 
uprtoreateElee stilnrtorings (; wkit.r, l(arglobP(ownth ateElee sli (#9724)var 	!forPa		 ];[[, obdmror a P.bmpa),
(!i	=== d]]
ody ) {
	ailsH doesr( id tor a P.noBabbl 
id +

	onnisWngs (g, obdreietur vaj iNabbl ),
 ];or a Pndo =gati),
s|| ===  ( utucur ];e
		})MorphcatchsdNabbl ),
u+ === 	)?, obdr:r obd=er wid tr  ( utualds
					/ =  in listh;curh;curs
	cur=er wid tre 
			}lb 	!forPa		ntext,[fcurmdNabbl ),
u]	// 	rtualds
	cur// 
		rediaOM nodes acelrings (sufdrF gotrtoreateElee (	.g.i morabacv. it' or israrded,d e)ouiy ) {
ald
id alds
= 
	accnownth ateElee 
			}lb 	!forPa		ntext,[fald.	hrefNoViews||fald=er widWngs (s||rings (mdNabbl ),
u]	// 
		return ret;or FipecE doesrseonr
						ecpa		ret0, length = h; i++	!forPa		n lengt id !u			e.isP	//agaseleStinpromi				if ( ar( utucur ]+	!forPa		fi(f ( !b	l{u			e. eveQ]+	!forPa		fi([1ry//y IOME doess=,(i

	ont_ue/ gfcurmd	u			e(r )(!ir /
==u			e. eveQs	id 

	ont_ue/ gfcurm )E does"d)	ubr
y.is
E doesurn rnQu		E does.a fuy(,curmhue/ is// 
		retis ueNoroected jQuesueua bbrs
JScacce: (n
 #4rd tea(
		rt E doesry IOME doess=,in eveQid cur[,in eveQ]	ubr
y.is
E doesQid(
		rtrgele= !e/ gfcurrei&&iE does.a fuy(,curmhue/ isF ta );
	 Retrn tl{u			e.c(u			eDhrefNo(	// 
		returval{u			e. eveQd[ eve;vaE is usedsnobolrec(u			eedoGdeu	hrefNoaae: (nmhu:sunanow	}
y {
	ailsH doesr( id !u			e.isDhrefNoP(u			eed(eietur vajt !== u(tor a P._	hrefNoa!iror a P._	hrefNo.a fuy(,	accnownth ateEleemhue/ isF ta );
	ei&&nD;
	!(r===W  |nt	}
" &&u

	onn,ctigCasdiv.f?m "a"
	rQid(
		rtrgele= !e/ g, obdreietur vaj iegexC//  aloaseve,d e	prreodeonr
			eng
t shrep see
		it
		itritg sr
						e.vaj iegexCectiaus/ cn ( fncce:namy)// valranditbeems
entort );ilsected jese.vaj iege ton'a
dor	hrefNoaae: (nseonrings (mected'tstandarglobP(sliistilseb/ (#6170)vaj iegeent<9 dm 
(ont
		})/blurrtorivent 							l (#1486)var upport,in eveQid
v.f?[= eveQs	id ((// M ! |nt
		})" &&u// M ! |ntbluro	(!iuu			e		eng
.x
		nWht:0 ! |n0)
id +

	onnisWngs (g, obdreietur vaj i eed ton'alry-			g		r an,inFOOuu			eare sewe	=lsi itt	FOO()	prreodvaj	rtualds
	 obd[,in eveQ]	ubvaj	ry ) {
aldreturn  t;tu obd[,in eveQ]s
					/			}
				vaj i eed P(u			alry-			g		rlowiifep see
		i				e,sily drFists
lrdNabbl 4ritbabI:
rn rrrr
		rtru			e				g		r 4rd[ eve;valt;tu obd[, eveQ](	/rn rrrr
		rtru			e				g		r 4rd|| jQuer}	ubvaj	ry ) {
aldreturn  t;tu obd[,in eveQ]s
	ald				}
				retur

		return ret;
				u			e.oes			// A glomaldisp
		:cacce: ( dru			eretugpa ure that ta wri stil

	on.(!fo
ist
ep senaseve,u!fo
 it'sst( utu!fo
r=(
		rtru			e.roidru			es||rings (.				e
id s = slidE doesrss== u(

	ont_ue/ gtjQuemd	u			e(r )(!ir /
==u			e. eveQs	memor)inD
		do =gatiC
				ncE doesrsndo =gatiC
			inD
		engs ];[].s);k  onhegdength > 1, 0f)inD
		run_nhe ];!u			e.ndcl})iv	sid !u			e.= faspfeMvy IOME doesrQ
	uO ];[]ddBorrim j	fcurmdjqcurmd
vts
	M
		,)bkit.ed,)bkit.Ms, E doescl.vts
	mdbmi}	ubv regex tooGde roi-ed

	on.(!fo
iraGderectenr
		(s
l-ails)enaseve,u!fo
v r	engsf (Q]+	!for	val{u			endo =gati)eng
s=	},
/gpa regexDif an e	cE doesrsected shlul4rrunsufinforeebrs
do =gatidru			es/Top !stin Ielects are
		// hragment (#6911)W dord evleft-	}
dNabbllowagm Fipefox (#3861)	}
y.is
do =gatiC
			sid !u			e		eng
.lects arsid=!(	!for.Namtoneid=	!for.r===W  |nt	}
"eietur vaj eed P(ug(Ier"di alslowil

	on it'sstr, leoeus/t shrenis()// tujqcur	e

	ong},
);// tujqcur.c gi;
s=	},
nownth ateElee	me	},
hey =  in listcur	eu			e		eng
h;curs!=	},
h;curs
	cur=er wid tre	me	},
return  t;s
	M
		s=r / rn  t;bkit.Mss=,ory// ttujqcurf (Q
	cur// 
t0, length = h; i+
do =gatiC
							if 			}lierE doescl.	ncE doesrise(). (th = l
 a E doescl..s
		//or	ubvaj	ry ) {
s
	M
		[
s
	Q]s
d ) {
			// Optionalt;	s
	M
		[
s
	Q]s

dvrn flierE doescl..q

 ? q

Is(,curmhE doescl..q

uu		mjqcurnis(
s
	Q)vrn flie
				}
		vaj	ry ) {
s
	M
		[
s
	Q]sOptional t;bkit.Msntext,hE doescl.
				}
				retur

	 ) {
bkit.Msn lengtreturn  IOME doesrQ
	uOntext,{e
		/:,curm
bkit.Ms:
bkit.Ms A-		retur

		return ret;llback	}, eoemcv.low ( bragmly-bo {)cE doesri	}
y.isdE doesrsn lengtr>
do =gatiC
			return  ME doesrQ
	uOntext,{e
		/:	},
m
bkit.Ms:dE doesrsns);k l
do =gatiC
			retA-return ret;or funsdo =gati
	

	;)
	yemch wa		redru	op
		//agaselecb(Iea		 usret0, length = h; i++E doesrQ
	uOn lengt id !u			e.isP	//agaseleStinpromi				if ( ar t;bkit. 4rd+E doesrQ
	uOse(). (th =u			e		}r wid)eng
s=	bkit. 4. obd	co =  in listjengt;tje<,bkit. 4.bkit.Msn lengt id !u			e.isIimwdiatiP	//agaseleStinpromi;tj++urn rnQu		E doescl.	=,bkit. 4.bkit.Ms[tje. ( vaue eed T		g		r 4ru			e
us(reiGdere1)cb(rd evndcl})iv	s do E ve,moc= faspfeMvto	vaue eed 2) E vec= faspfeM(s) alsubset igruqual ctt
oseiv. Gdembo {ru			e	(ble ijec E ve,moc= faspfeM).

	 ) {
run_nhei||ey!u			e.= faspfeM id !E doescl..= faspfeM	(!iuu			e.= faspfer_r	sid u			e.= faspfer_r	catchseE doescl..= faspfeMa)reiur vaj i eu			e. /*n deE doescl.. /*n;vaj i eu			e.E doescl.	ncE doescl. !body  t;
	s== u(

	rtru			e.or a t.[	E doescl..o		gT/ Md](!ir /).E does(!irE doescl..E doesrQ)vrn flie	.a fuy(,bkit. 4. obdmdengs 		diouier
y.is

	ned ) {
			// Optional;y u			e.oes			 ".jQI
ier
y.is

	n ta );
	 Retrn tl tl{u			e.c(u			eDhrefNo(	// 
	 tl{u			e.u	opP	//agasele(	// 
	 tl}			}
				retur

		return ret;
				u			e.oes			// A glomal  tIncl}e Dty pr
				e
		//Dtyharat)
	Kfi(!fors do Mous/(!formal  t***
		reC *			
		re",
dbmi} tre	srcE					l liable f it by defd,rd evW3C sdoc(ucmi},t sn		eF oeeI: dtv. 1.8t***red thps:d"		reC *			
		re",
dbmi} tre	srcE					l altKfidNabbl sijeccbmbl  ctrlKfid	}r wid)eng
+	!forPE ie	prraKfidbmi})eng
+					Kfi		eng
te meStamp viewew.fch"+/ );
"	"),ffseton Hriksast glomalkfiHriksastagtu thps:d"char charCtre	kfi	kfiCtre"+/ );
"	"),ff	tonlt	r:cacce: ( dru			emho		ginde
		rn a callback w.ft.r, l(kfiru			es/uiy ) {
	!for.w.ft.r
					 Optional;	!for.w.ft.rho		ginde.charCtre	!
					r?.o		ginde.charCtre	:.o		ginde.kfiCtre// 
		rediat;
				u			e// 
		ret glomasmous/Hriksastagtu thps:d"NamtoneNamtonsijli		eXijli		eYist
E					l x
		nX x
		nY		}geX		}geY snt(enX snt(enY ctE					l"+/ );
"	"),ff	tonlt	r:cacce: ( dru			emho		ginde
		rnn fsliru			e at sdat sbolrmisen uNamtonrho		ginde.Namtonmisen ust
E					lrho		ginde.st
E					l	diouiiegexC//cubmi}		}geX/Ysufp( rs
	
 #4ijli		eX/Ysavaibmbl /uiy ) {
	!for.	}geXr
					sidho		ginde.jli		eXi!
					 Optional;u			e at	eu			e		eng
nownth ateElee	mereateEleQI
ierdat	eu			e at.eateEleQE			leQI
ierbolr	eu			e at.bolr	diouier	!for.	}geXrho		ginde.jli		eXi+{
eatsidhdat.sntollLefe	merbolrsidrbolr.sntollLefe	megtret-{
eatsidhdat.jli		eLefe	merbolrsidrbolr.jli		eLefe	megtre;ouier	!for.	}geYrho		ginde.jli		eYi+{
eatsidhdat.sntollTop
	merbolrsidrbolr.sntollTop
	megtret-{
eatsidhdat.jli		eTop
	merbolrsidrbolr.jli		eTop
	megtre;oureturn a callbackdbmi})eng
vttfy alessude a y ) {
	u			e	bmi})eng
sidist
E					l Optional;u			e	bmi})eng
s=ist
E					lr
eu			e		eng
r?.o		ginde.ctE					l :ist
E					l;oureturn a callback w.ft.r, l(	}
: 1r
eleft; 2r
emidoes	 3r
e	rtionretis ueNoro:iNamtonisle f it by defd,rso a bodeus/ble a y ) {
	u			e	w.ft.sidiNamtonned ) {
			// Optional;	!for.w.ft.rh(iNamtonn& 1r? 1r:h(iNamtonn& 2r? 3r:h(iNamtonn& 4r? 2r:htrerere// 
		rediat;
				u			e// 
		ret glomason :cacce: ( dru			eretugpy ) {
	!for[

	on.ndD
		:ssietudiat;
				u			e// 
		gpa regexCt("di a wri stilcope=ofeGde,u!fo
 it'sst
 #4 it by defty pr

		of"em 
s = slidi,

		omisen o		ginde(!forencu			em// tton Hrikr=(
		rtru			e.on Hriks==u			e. e Md](!ir /m// ttcoper=(on Hrik.		//Dt?	},
.		//D.c gcmi((on Hrik.		//Duu		m},
.		//D ( val{u!forenc

	on.(!fo
y o		ginde(!forre// ret0, length =cope< lengt;ti;ietudiat;		//h =cope[ --(). (th =u			e	nc(opQ]s
	a		ginde(!f	e	nc(opQ]// 
		gpa (rs odoi		eng
t		// (Wevttfy alessude (#1925,ent ort/8 & 	 "ts 2)ody ) {
	u			e		eng
 Optionalu			e		eng
s=,a		ginde(!f	e.srcE					l	mereateEleQI
i	gpa (rs o)eng
 shlul4rd teb/ ctfid ahe  (#504, 	 "ts )ody ) {
u			e		eng
n,cti),

		// Optionalu			e		eng
s=
u			e		eng
ner wid tre// 
		gpa (rs odod mous//kfiru			es;acelrprraKfidufble t	ndtinforee(#3368,entort/8)ody ) {
u			e	prraKfis
d ) {
			// Optionalu			e	prraKfis=
u			e	ctrlKfi;return ret;
				on Hrik.onlt	r?	on Hrik.onlt	rdru			emho		ginde(!forre :ru			e// A glomasor a Pastagtus
lrastagyure that the oecte s
lrru			e=is	sy.Dpagyursy.Dpt.

	on.bmpaR
lragy			ffy. juoa-astagyured P(u			al			g		r 4rim}ge.uoa-,u!forlist
 Nabbllowrtorings (.uoa-agyurnoBabbl vhange/ y			ffy. j
		})astagyurdo =gati),
:d"
		})in"/ DDeferjQblurastagyurdo =gati),
:d"
		})gut./ y			ffy. jbe, leunuoa-astagyursy.Dptcacce: ( dhue/ vt= faspfeMs, u!forH doesisF		}lisineWebailh wa		redrdom},
ror a t.	=lseeonrings (s

	 ) {


	onnisWngs (g	},
ret			rety= T},
nonbe, leunuoa-s=, !forH does-		retur/}
			ffy. jQteystowntcacce: ( dt= faspfeMs, u!forH doesisF		}lis) {
},
nonbe, leunuoa-s===, !forH doest			rety= T},
nonbe, leunuoa-s=,				/		h v.s/}
		// Fl/ Deferredsimubmi}tcacce: ( dt// Ma  obd, u!formdNabbest			reured P	g	ye mes(n
  a bigru			e	=o simubmi}
   by ause eone.a (rs odat ho		ginde(			e	=o  in I a big t	u	opP	//agaselemdNarsufinfoa (rs osimubmi}-,u!forec(u			et		hrefNoate sewe	dtfp see
		eonr
	 a big.	}issli, 	=s==c( =m( innguvar rmew

	on.(!fo
y)inD
		u			em// tt{ // Ma	=== ,	}ltuisSimubmi}-vhangeBu 5en o		ginde(!forasts/}
		// Fa;	}
y.isdNabbest			rerrr
		rtru			e				g		rdru,,				a  obd 		div.			jQueturt;
		rtru			e	disp
		 onhegt obdmhe 		div.	ody ) {
u.isDhrefNoP(u			eed(eietur tl{u			e.c(u			eDhrefNo(	// 
}/ D

vu oeed 	 pr
pluginsebrs
})ingmdNarble t	uneateEleeed/doc(ucmi}
 #4t sn		eF oeeI: d.oeed T
	 1.7ror a Pru			eri	eerfck  shlul4t		/pro 'lsiafee=hriksy at }
n (.//
ction(	!for.h doess=,
		rtru			e	disp
		vu oe

	ontoeeI: (!fo	.createElemtoeeI: (!forL// (Ierr?varacce:namg, obdmd// M,
E doesurn rnQ
y.is
	acctoeeI: (!forL// (Ierretur tl{	acctoeeI: (!forL// (Ier(d// M,
E doest );
	  // 
}/ D
 :varacce:namg, obdmd// M,
E doesurn rnQ
y.is
	acctderard(!for
			}li	acctderard(!for(oy"  u+ =/ M,
E doe	  // 
}/ D
vu oe

	ont(!fo	.cracce:namg,src,

		o
return  !stllow truea		iaselet shrou(r
		'mew'(kfi).-ag ) {
	g},
 truea	c "o(

	ont(!fo	) args = rred;(mew

	on.(!fo
g,src,

		o
revu urn reegex(!fo
 it'sstag ) {
srcsid
src.unctQuery. T},
no		ginde(!foren
src;y. T},
. eveQd[src.unct;gpa regex(!fo
s Nabbllowrupr
		eateElememch E ve, diremcrk}
 sec(u			eeda rege)
	arE doesrll
})	eawnr
			rea; oef		//	}, in fragmundef .y. T},
.isDhrefNoP(u			eedrh([src.dhrefNoP(u			eedr||[src.rred;VdefiW ta );
	r||	}lisrc.geoP(u			eDhrefNosid
src.geoP(u			eDhrefNo(eiet? rred;TrfiW: rred;F;
	;n reegex(!		e	=== s .			jQuetu. T},
. eveQd[srcvu urn reegexPu(rdth and lyt		/pro T

		of"em 
(onctt
			!fo
 it'sstag ) {

		o
return 	==c( =m( inng
},
,

		o
revu urn reegexCt("di ate mestamp ) {inrgi
			!fo
one chec E ve(on s T},
.e meStamp =
srcsid
src.e meStamp ||(
		rtrn ((.*\]isged Mcrkritbaesroinds T},
[

	on.ndD
		:d]s=r
// I
vu oeacce:nam rred;F;
	"
			}rred; );
 I
oeacce:nam rred;Trf	"
			}rred;r
// I
u oee 

	on.(!fo
 isrbth of n d e3x(!fo
s aesor a checbyoGde ECMAScript L*		u}geeB		disp	aerfectionkwww.w3urityTR/2003/WD-d e-L	!fl-3-(!fo
s-20030331/ecma-script-b		disp.v "eoe

	ont(!fo	.		/to eveQd			}c(u			eDhrefNo:tacce:nam"
		y. T},
.isDhrefNoP(u			eedrhrred;Trf	vu oeissli, 	=s},
no		ginde(!for
ody ) {
		 Retrn t;
	},	co])/gpa regex) {c(u			eDhrefNoe/oca		rrunsuteonr
	 o		ginde		!fo
ody ) {
u.c(u			eDhrefNo
			}li	.c(u			eDhrefNo(	/gpa regeble tawisuair JSbunrred;Vdefi
		// (We=ofe
	 o		ginde		!fo
=stead ofo(nt)div.			jQueturt;e.rred;VdefiW ead of// 
		ret glo	u	opP	//agasele:tacce:nam"
		y. T},
.isP	//agaseleStinpedrhrred;Trf	vu oeissli, 	=s},
no		ginde(!for
ody ) {
		 Retrn t;
	},	co])/gpregex) {u	opP	//agaselee/oca		rrunsuteonr
	 o		ginde		!fo
ody ) {
u.u	opP	//agaseleeRetrn t;u.u	opP	//agasele(	// 
}a regeble tawisuair JSbuijeccbBabbli
		// (We=ofe
	 o		ginde		!fo
=ste
//fo(nt)div.e.jeccbBabblis=r
// I
t glo	u	opIimwdiatiP	//agasele:tacce:nam"
		y. T},
.isIimwdiatiP	//agaseleStinpedrhrred;Trf	vu  T},
.u	opP	//agasele(	/
t glo	isDhrefNoP(u			eed: rred;F;
	glo	isP	//agaseleStinped: rred;F;
	glo	isIimwdiatiP	//agaseleStinped: rred;F;
	
vu oegexCt("di mous/		eer/|dtve,u!forl
})ing mous/ghid/ou(ra{ru			e-e me// val //
ction(						y. mous/		eer:d"mous/ghid",y. mous/|dtve:d"mous/gut./ },tacce:nam" o		g,sroieRetrn 

	rtru			e.or a t.[ o		gls	=sty. jdo =gati),
:droiferjQb		d),
:droifererjQE does:cacce: ( dru			eretugpy= slid/eng
s=	},
Bu 5en bmi}s=
u			e	bmi})eng
vrnQu		E doescl.	=,u			e.E doescl.miseIOMs
		//or a E doescl..s
		//orBu 5en l	diouiieg odod mous		eer/|dtve,clsiafee=h doesrsufdbmi}sislllCsid )
	u	eng
nretis ueNB:xNo(bmi})engrsufinfo mous	left/		eeredoGdeubif serrings ( a y ) {
	bmi}i||eybmi}ied d/eng
sid +

	on.c giatru(d/eng
mdbmi}W))return 	l{u			e. eveQ]+E doescl..o		gT/ M	div t;
	Q]+E doescl..E doesr.a fuy(	},
mdength > 1Qu;rn 	l{u			e. eveQ]droie(th
		// rg
	},

	e(th }/ DeIE d)vu isllentlsub( tsdo =gat ( 	a) {
	

	onnioValue5sub( tBabbli
returnrn 

	rtru			e.or a t.5sub( t	=sty.ursy.Dptcacce: ( deturnaOM nodes y at oGduesrigdo =gatidrrigmlsub( tru			es/uiy ) {u

	onn,ctigCasdtjQuemd	rigm"	oreturn jQrred; );
 ;oureturn a callbLazy-celralsub( trE doesrare se	doscnnga		rrigmlmchspot		e Ps ybelsub( ttidurt;
		rtru			e	celdtjQuemnt	}
._sub( t(kfiprass._sub( t",cacce: ( dru
			}lislle tre	name// val  in Ise	VML-bmi}Wcrashagment (#9807)	}lisslid obds=, .teng
vrnQu  in lds=u

	onn,ctigCasdtv.f?ec	inputr )(!iu

	onn,ctigCasdiv.f?m "Namton"	or?
	acctn lds:|| jQuer}
odyiy ) {un ldsid +n ld._sub( t_		rarded
			}lis
		rtru			e	celun ldm "sub( t._sub( t",cacce: ( dru			eretugpy= lis usedun ldswaslsub( ttecbyoGde us	rmdNabbl t
			!fo
 upr
			reagpy= lis) {
},
ner wid tresid +u			e.isT		g		rretugpy=lis
		rtru			e	simubmi}(oysub( t",
},
ner wid tre, u!forme
//fo	// 
	 tl}			}
			// 
	 tn ld._sub( t_		rardeds=r
// I
	 tl}			}		/dial;or oe	},) {
			//sily drFia body at Ianru			e	l// (Ier/ y			ffy.jQteystowntcacce: ( deturnaOM nodes y at oGduesrigdo =gatidrrigmlsub( tru			es/uiy ) {u

	onn,ctigCasdtjQuemd	rigm"	oreturn jQrred; );
 ;oureturn a callbfeeI: )do =gatidrE doesrs;rc|dtn!e/ ru			euPs yt("pslsub( tcE doesrse		rardedsabI:
rn rr
		rtru			e.oeeI:sdtjQuemd	._sub( t"
	e(th }/ DeIE do isllent 
 *			sdo =gat ( ects// valboi/ains iroi	a) {
	

	onnioValue5
 *			Babbli
returnrn 

	rtru			e.or a t.5
 *				=sty.y.ursy.Dptcacce: ( deturn/uiy ) {u rigcE.f?scatchdtjQuen,ctigCas	oreturn jQllent ne chec 
e 
 *			s( ec// val/ains i				l blur;l			g		rsuteonr	}
rn jQllnded tua			// (We
 *			. Eed Gde blur-
 *			agmeor a t.5
 *			.E does.vaue eed T,
ro		ll 
 
(on
 *			aafs
co#4re me/rig// val/ains nded t blur.	}lis) {
},
.r===W  |n)/ valboi"(!i
},
.r===W  |n)ains "return jQ
		rtru			e	celdtjQuemnt		// (We
 *			._
 *			",cacce: ( dru			eretugpy= iy ) {
	!for.a		ginde(!f	e.		// (WegCas	  |n)/ valed"return jQ T},
._jus(_
 *			ds=r
// // 
	 tl}			}
			// 
t;
		rtru			e	celdtjQuemnt	}
._
 *			",cacce: ( dru			eretugpy= iy ) {
},
._jus(_
 *			dsid +u			e.isT		g		rretugpy=lis},
._jus(_
 *			dW ead of/gpy=lis
		rtru			e	simubmi}(oy
 *			",
},
, u!forme
//fo	// 
	 tl}			}
			// 
	 }rn jQrred; );
 ;oureturni eed to =gatidru			e; lazy-celral
 *		e=h doesrsondoscnnga		rinputsurt;
		rtru			e	celdtjQuemntbe, leae: vati._
 *			",cacce: ( druretugpy=lslid obds=, .tengl	diouiiy ) {u rigcE.f?scatchs
	accn,ctigth ; s&&
	 obd._
 *			_		rarded
			}lis
		rtru			e	celuv.f?m "
 *			._
 *			",cacce: ( dru			eretugpy= iy ) {
},
ner wid tresid +u			e.isSimubmi	dsid +u			e.isT		g		rretugpy=lis
		rtru			e	simubmi}(oy
 *			",
},
ner wid tre, u!forme
//fo	// 
	 tl}			}
			// 
	 t obd._
 *			_		rardeds=r
// I
	 tl}			}		/dial}fererjQE does:cacce: ( dru			eretugpy= slid obd	eu			e		eng
hrn a callbSw// Whenaseve,
 *			,u!forlist
 / valboi/ains ,drFists
lrl			g		r 4afeccsabI:
rn r ) {
},
ied d obdi||(u			e.isSimubmi	ds||(u			e.isT		g		rs|| (	accn// M ! |n)ains "rid 	accn// M ! |n)/ valboi"oreturn jQrred;(u			e.E doescl..E doesr.a fuy(	},
mdength > 1Qu;rn 	l}/ y			ffy.jQteystowntcacce: ( deturnaOM
		rtru			e.oeeI:sdtjQuemd	._
 *			"Qu;rediat;
			u rigcE.f?scatchdtjQuen,ctigCas	oe(th }/ DeIE do isgexCt("di "Nabbllow"t
		})ects blur,u!forl	a) {
	

	onnioValue5
		})inBabbli
return	
ction(						t
		}):d"
		})in", blur:d"
		})gut. },tacce:nam" o		g,sroieRetn ret;llba	rard alslowilcap
		lowrE doesrareilfty pron  wa		s 
		})in/
		})gut	}issli
		rat.Mss=,0,rn
		E doesr dcacce: ( dru			eretugplis
		rtru			e	simubmi}(droifu			e		eng
,(
		rtru			e.roidru			es)me
//fo	// 
	/ ( val 

	rtru			e.or a t.[ roils	=sty. jrsy.Dptcacce: ( deturuiiy ) {u		rat.Ms++

	/fetugpy=lieateElemncel(!forL// (Ier" o		g,rE doesrmon
	
	// 	returnr j},y. jQteystowntcacce: ( deturuiiy ) {u--		rat.Ms

	/fetugpy=lieateE		e.oeeI:s(!forL// (Ier" o		g,rE doesrmon
	
	// 	returnr j}// Fl\}|\[.*\]	/ oe

	ontfnm( inngu		}}|\le:tacce:nam"d// Ms, s
		//ormhue/ vufemd/*INTERNAL*/sontf ( !flasli o		gFemdunct;gpa regexT/  sijeceb/ ctmcV=ofe/  s/E doesri	}
y.ise/  ofe/  s dta "it'sstoreturnaOM no"d// Ms-cl.;
vts
		//ormhue/ Q)vrn
y.ise/  ofes
		//or ! |n)u			//oreturnaOMM no"d// Ms-cl.;
mhue/ Q)vrn
k /*n dts
		//or;iseIOMs
		//or a | jQuer}
rnr j}// Fin listunctQind// MsreturnaOMMjQuenam"d// M, s
		//ormhue/ vd// M([	=== d],sontf e(th
		// rg
	},
jQue	div.sffset !== hue/ Q
					sidufeQ
					seturnaOM no"d// MsvufeQ)vrn
feQdts
		//or;is
k /*n dts
		//or a | jQuer}
rn
					--cy.is
feQ
					setuvrn
y.ise/  ofes
		//or = |n)u			//oreturnaOMM no"d// Ms, s
		//orvufeQ)vrn
feQdt /*n;vaj
k /*n dt| jQuer}
rn
						--curnaOMM no"d// Ms,t /*nvufeQ)vrn
feQdt /*n;vaj
k /*n dts
		//or;iseIOMs
		//or a | jQuer}
rnr j}// F}// Fy.is
feQ ta );
	 Retrn tlfeQ  rred;F;
	
rn
					--cy.is
!feQRet// rg
	},
jQue	div.sffset !== hontQ ta 1QRet// rgo		gFe dcan;rn tlfe dcacce: ( dru			eretugpj iegexCecaus/ cne cellsuee,sily ru			erc giatru Gde in
	gplis
		rt().x
dru			e
		div t;
	},
o		gFe.a fuy(	},
mdength > 1Qu;rn 	l};rn regex tsee
		egu .rso//// srijec	oeeI:s
})ing
o		gFern tlfe.gu . d
o		gFe.gu .s|| (
o		gFe.gu .idi

	on.gu .++	oe(th }/ rg
	},
jQue(					cacce: ( deturnaOM
		rtru			e.celdtjQuemd// Msvufevt /*ntos
		//or	oe(th }	/
t glo	ont:tacce:nam"d// Ms, s
		//ormhue/ vuferetugprg
	},
jQue(on onhegtjQuemd// Ms, s
		//ormhue/ vufemd1 	/
t glo	x
:tacce:nam"d// Ms, s
		//ormuferetugpr
y.ise/  ( ide/  (.c(u			eDhrefNoide/  (.E doescl.seturnaOM nodru			eret disp
		ed

	on.(!fo
gpy= slidE doescl.s=e/  (.E doescl.;rnaOM
		rtse/  (ndo =gati)eng
s).x
drnQu		E doescl..= faspfer? E doescl..// M + )."r+eE doescl..= faspfeMa: E doescl..// M,rnQu		E doescl..s
		//or,rnQu		E doescl..E doesry IOM	// rg
	},
jQue	div.s	}
y.ise/  ofe/  s dta "it'sstoreturnaOM no"d// Ms-it'sst [, s
		//orsie// Fin listslitunctQind// MsreturnaOMMjQuenx
"d// M, s
		//ormd// M([	=== d]f e(th
		// rg
	},
jQue	div.sffl;) {ycs
		//orW ta );
	r||e/  ofes
		//or = |n)acce:namoreturnaOM no"d// Ms [,ufe]Q)vrn
feQdts
		//or;isIOMs
		//or a | jQuer}
// F}// Fy.is
feQ ta );
	 Retrn tlfeQ  rred;F;
	
rn
		/ rg
	},
jQue(					acce: ( deturnaOM
		rtru			e.oeeI:sdtjQuemd// Msvufevos
		//or	oe(th }	/
t glo
tb		d:tacce:nam"d// Msmhue/ vuferetugprg
	},
jQue(am"d// Msm					mhue/ vufe 	/
t glo	unb		d:tacce:nam"d// Msmhferetugprg
	},
jQuenx
"d// Msm					vufe 	/
t glo
tleve:tacce:nam"d// Msmhue/ vuferetugprg
		rts
jQuenc gi;
s)(am"d// Msm
jQuens
		//ormhue/ vufere;gprg
	},
jQue/
t glo	die:tacce:nam"d// Msvuferetugprg
		rts
jQuenc gi;
s)(a
"d// Msm
jQuens
		//orr|| "**/vufere;gprg
	},
jQue/
t glo
tdo =gate:tacce:nam"ds
		//ormd// Msmhue/ vuferetugprg
	},
jQue(am"d// Msm	s
		//ormhue/ vufe 	/
t glo	undo =gate:tacce:nam"ds
		//ormd// MsmhferetugpOM no"d= faspfeMa)rorr"ds
		//ormd// Ms [,ufe]Q)gprg
	},dength > 1< lengt
 1?
jQuenx
"ds
		//orm "**/re :rjQuenx
"d// Ms, s
		//ormufere;/ Deferred			g		r:cacce: ( "d// Mmhue/ retu/ rg
	},
jQue(					acce: ( deturnaOM
		rtru			e.			g		r"d// Mmhue/ m
jQue	oe(th }	/
t gred			g		rH doe	r:cacce: ( "d// Mmhue/ retu/ r ) {
},
[0sietudiat;
				
		rtru			e.			g		r"d// Mmhue/ m
jQue[0svon
	
	// 
		ret glomastogges:cacce: ( dhferetugpOM noStve,re ausecfseddength > 1r, l(aelesshinurlohe o!flasli engs ]dength > 1,rnQu	gu .idife.gu .s|| 

	on.gu .++,rnQu	is=,0,rn
		toggesr dcacce: ( dru			eretugpli(rs odoge olllC w.ft.racce: ( sedd( ecutegpy=lslidlastToggess=,(i

	ont_ue/ gtjQuemd	lastTogges"r+ife.gu .s)	megtret% i	div t;

	ont_ue/ gtjQuemd	lastTogges"r+ife.gu .,dlastToggess+d1 	( arrayure that the oectedr	}
t	u	oprn tl{u			e.c(u			eDhrefNo(	//arrayure t dod( ecute Gde acce: ( div t;
	},
engsfdlastToggess].a fuy(	},
mdength > 1Qu	me );
 ;ouretu;gpa regexllok'lsiafee acce: ( s,rso any of Gdemijec	unb		d	},
r	}
 E doesry 		toggesr.gu .idigu .// 	rreilft(; i++engsn lengtreturn  Iengsf			if].gu .idigu .// 
		re/ rg
	},
jQue(	}
( toggesrre;/ Deferlorhghid:cacce: ( dhfeOhid,hfeOutretu/ rg
	},
jQue(mous/		eerdhfeOhids)(mous/|dtve(hfeOut	mehfeOhirre;/ DeE d)vu //
ction(					 (tblur 
		}) 
		})in 
		})llC uoa-s 
deftsntollviouoa-r	}
 dbl	}
 "r+/ D"mous/eawnrmous/uprmouseeI:s
mous/ghid mous/gut mous/		eer mous/|dtve "r+/ Dy
 *			 s
		// sub( t(kfieawnrkfiprassrkfiuprerr l(c gi;
Eleu"e+/ );
"	"),tacce:nam" ivt= faeRetn rere tH doesru			erb		disprer

	ontfn[t= fae] dcacce: ( dhue/ vuferetugprgy.is
feQ
					setuvrn
feQdt /*n;is
k /*n 
					// 
		re/ rg
	},dength > 1< lengt> 0f?/ rMMjQuenam"t= fam					mhue/ vufe 	 :/ rMMjQuen			g		r"t= fa") /}vu is ) {u

	onn		reFeretugprg

	onn		reFe[t= fae] dr
// I
t u is ) {uekfi(!forcatch"t= fa")retugprg
		rtru			e.on Hriks=t= fae] dr
		rtru			e.kfiHriksI
t u is ) {uemous/(!forcatch"t= fa")retugprg
		rtru			e.on Hriks=t= fae] dr
		rtru			e.mous/Hriks;/ DeE d)vu //u isl*!
 *sSizzesrCSS S
		//orrEnger}
 *s Copertiona2011, T
	 Dojo Fo {at ( 
 *s R
		th of {egr
		MIT, BSD,
 #4rGPL Licnns (n
 *s More in
	rmasele:fectionksizzesjenc m/
 *///	acce: ( detn revar chunksr dc/(to	\(to	\([^()]+\)|[^()]+)+\)|\[to	\[[^\[\]]*\]|['"][^'"]*['"]|[^\[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?(to	.|\r|\n)*)/g,rn
ndD
		:d|n)sizrgj!s"r+i(Ma		nr
		:m()r+i'')Tllback l'.',i'')glo	donts=,0,rn
toS			//s=,cl.;
.		/to eve.toS			//,rn
E iDuh anatiW ead of,rn
bas/H iDuh anatiW eangeBu 5rBa
tlash dc/\\/g,rn
rR
	}, dc/\r\n/g,rn
rNonW.- dc/\W/vu islleHe odre// valsufinfo JavaScript enger} il
})ingty prty  t ofisll
ide miz"d distandari
one t	ndtIction(,clsiaour c mer is diisll
acce: ( .sedectedrisJSbuijesMmhuopcystafeefE iDuh anatiWndef .y.ll
  T
}) 
arectedrincl}e DtGoogesrCht
 .y.[0, 0].y  t	acce: ( deturnabas/H iDuh anatiW  );
 ;our
	},d0IE d)vu isvarsSizzesr=tacce:nam"ds
		//orm(c gi;
, oes			s, s
ed
			}oes			sr=toes			s	memory// c gi;
s=	c gi;
smereateEleQI
// sli o		gC gi;
s=	c gi;
vu is ) {	c gi;
n,cti),
!ta 1Q&&	c gi;
n,cti),
!ta 9retu/ rg
	},mory//		retis ) {
	s
		//or mee/  ofes
		//or ! |n)u			//oreturnaO
	},toes			sy//		r
// sli m,suee,// valSee,/;
ramd
	fcurmdpopi 
	agtu tuniW eangeBu 5 c gi;
XMLW eSizzes.isXML	c gi;
f)inD
	er ts ];[]ddBorsoFarQdts
		//or;istisallbfeir JSbudposi:nam of Gde chunksrlregndDs(str tist
 h
l)lo	doturnaOchunksrm( ecy ""
	e(th d	echunksrm( ecy soFarQ)vu is	 ) {
breturnaorsoFarQdtm[3ry//	tisa
	er tsntext,tm[1]f e(th
vrn
y.i,tm[2]sOptional ;
raQdtm[3ryional brdtk
rnr j}// F}// }areilf{
brevu is ) {	er ts< lengt> 1sidho		gPOSm( ecyes
		//or )reiur vaj ) {	er ts< lengtQ ta 2sidhalsr	bmieve[	er t
[0si]sOptionalir J=dposP	/less(	er t
[0si+	er t
[1]m(c gi;
, s
edrevu is						--cuionalir J=halsr	bmieve[	er t
[0si]?var t;[(c gi;
i]:var t;Sizzes(	er t
						s
m(c gi;
revu is		rreilft	er ts< lengtsOptional s
		//or a	er t
						s
	diouiiy ) {halsr	bmieve[	s
		//ori]sOptionaal s
		//or +a	er t
						s	// 
	 }rn jQional sr J=dposP	/less(	s
		//orm(sr , s
edrevu

		return re					--cui regexTat talshluecu(ra{rir JSbu(c gi;
sufinfo root	s
		//oriisra{ IDgpOM no"Nam	ndtdufble n		eF faseersufinfo inIer	s
		//oriisra{ ID)ody ) {
	s
edridher ts< lengt> 1Q&&	c gi;
n,cti),
=ta 9sid +c gi;
XMLi&&nD;
	alsr.bkit..IDcatch"er t
[0s s&&
	alsr.bkit..IDcatch"er t
[er ts< lengt- 1])reiur vajaO
	W eSizzes.f		d(	er t
						s
m(c gi;
m(c gi;
XMLievu

	c gi;
s=	
	.elsr?var t;Sizzes.onlt	rdr
	.elsr,r
	.ir J)[0s:var t;
	.ir [0s	div.sffset !== hc gi;
seiuvajaO
	W  s
ed?var t;{ elsr:	er t
	pops
m(ir : mat s ) ),s
edet:var t;Sizzes.f		d(	er t
	pops
m	er ts< lengtQ ta 1Q&&	"er t
[0s = |n)~"(!i
er t
[0s = |n)+")Q&&	c gi;
ner wid tres?	c gi;
ner wid tres:(c gi;
m(c gi;
XMLievu
ionalir
s=	
	.elsr?var t;Sizzes.onlt	rdr
	.elsr,r
	.ir J):var t;
	.ir vu
iona ) {	er ts< lengt>	/fetugpy=l/ valSees=	mat s ) ),(ir ievu
ional				--cuionalu tuniW  );
 ;ouretuu is		rreilft	er ts< lengtsOptional curs
	er t
	pops	// 
	 popQ
	cur//{var upport talsr	bmieve[	curi]sOptionnal curs
	""// nal				--cuion
	 popQ
	er t
	pops	// 
	 }/{var upport popQ
					secuion
	 popQ
(c gi;
// 
	 }/{var upalsr	bmieve[	curi](// valSee, popm(c gi;
XMLievu

	 }/{var 				--cuio=l/ valSees=	er ts ];[]// 
}/ D

is ) {
	/ valSeesecuiol/ valSees=	ir v/ D

is ) {
	/ valSeesecuio;Sizzes.err l(	cur me s
		//or )v/ D

is ) {
toS			// onheg/ valSee) = |n)[it'sst s ) )]oreturna ) {
	 tunireturna oes		tsntext.a fuy(	oes		ts,// valSeerevu is						--c!== hc gi;
Q&&	c gi;
n,cti),
=ta 1QRet// r0, length = h;/ valSeefi(i!
									if 			}lie!== hc valSeefi(Q&&	"c valSeefi(=t eange mehc valSeefi(n,cti),
=ta 1Q&&	Sizzes.c giatru(c gi;
m(c valSeefi())return 	a oes		tsntext,(ieefi(	// 
	 }/

	 }/{var 				--et// r0, length = h;/ valSeefi(i!
									if 			}lie!== hc valSeefi(Q&&	c valSeefi(n,cti),
=ta 1return 	a oes		tsntext,(ieefi(	// 
	 }/

	 }/{turn re					--cui remat s ) ),// valSee, oes		ts )v/ D

is ) {/;
rasecuio;Sizzes/;
ravto		gC gi;
, oes			s, s
ed
;io;Sizzes.uniqueS  t	 oes		ts )v/ D

isO
	},toes			sy//vu isSizzes.uniqueS  tr=tacce:nam	 oes		ts ecuis ) {/s  tOrd	rretugpy=E iDuh anatiW ebas/H iDuh anativu  oes		tsns  t/s  tOrd	rQ)vu is	 ) {
E iDuh anatiretugpy=in listsligth =1h; i++oes		ts< lengt				if 			}lie!==	 oes		tsfi(=t eoes		tsf; i- 1i]sOptionnal oes		ts+/ );k lci--,y1 		/ 
	 }/

	 }/{tur/ D

isO
	},toes			sy//vu isSizzes.bkit.Mss=,acce:nam	 elsr,rseesecuisO
	},tSizzes	 elsr,					,					,rseesey//vu isSizzes.bkit.MsS
		//ors=,acce:nam	 ,cti, elsrsecuisO
	},tSizzes	 elsr,					,					,r[,cti]sO< lengt>	/y//vu isSizzes.f		ds=,acce:nam	 elsr,(c gi;
m(isXMLsecuisOslirseei 
	f lem
bkit.md// M,left;
is ) {
	elsrsecuisrg
	},mory//		r
is0, length = 	f leJ=halsr	ord	r< length; i++ le				if 			}l// MJ=halsr	ord	rfi(	/ 
set !== u(bkit.J=halsr	leftM
		[	=== d]m( ecyeelsrse)return 	alef
s=	bkit.[1ry// tubkit.+/ );k lc1,y1 		/ iona ) {	lefe5subu			lefe< lengt- 1 	 ! |n)\\oreturnaOMMbkit.[1rs=,(bkit.[1r(!i
	)Tllback l rBa
tlash, ""
	e(th alir J=halsr.f		d[	=== d](,bkit.,(c gi;
m(isXMLse//{var upport ir J!
					secuion
	 elsrs=eelsrTllback l alsr.bkit.[	=== d], ""
	e(thnal brdtk
/ 
	 }/

	 }/{tur/ D

is ) {
	seesecuisOlir J=e/  ofec gi;
ngeQE			leQsByTaggCas ! |n)| jQuer}or?var rc gi;
ngeQE			leQsByTaggCasy "*/re :var rory//		r
isO
	},t{(ir :rseei elsr:	elsrs}y//vu isSizzes.onlt	rs=,acce:nam	 elsr,rseei 
nback i morsecuisOsli,bkit.,(anyFo {,	}l// Mvufo {,blef?m onlt	r,left,	}li,		}
,	}tualds
 elsr,u  oes		t ];[]ddBorcurLoopQ
(set,	}lisXMLFnlt	rs=,s
sid ir [0ssideSizzes.isXML ir [0sse//{varreilft elsrsid ir < lengtsOptionin listunctQin alsr.onlt	rsOptiont !== u(bkit.J=halsr	leftM
		[	=== d]m( ecyeelsrse)r!
					sidubkit.[2]sOptional onlt	rs= alsr.onlt	r[	=== d]I
 	alef
s=	bkit.[1ry//
 	aanyFo {W  );
 y//
 	ubkit.+/ );k l1,1e//{varna ) {	lefe5subu			lefe< lengt- 1 	 = |n)\\oreturnaOr rc giin/ I
	 tl}/{varna ) {	curLoopQ=t eoes		treturnaOr oes		t ];[]I
	 tl}/{varna ) { alsr.praFnlt	r[	=== d]returnaOr bkit.J=halsr.praFnlt	r[	=== d](,bkit.,	curLoopi 
nback ieoes		ti mori 
sXMLFnlt	r 		diouier
y.is
!bkit.returnaOr 	aanyFo {W  )o {W eange	diouier
				--c!==(,bkit.=t eange eturnaOr 	rc giin/ Iouier
	
	 tl}/{varna ) { bkit.returnaO r0, length = h;(lef?h =curLoopfi()i!
									if 			}lina ) { lef?retugpy=lis)o {W eonlt	r lef?m
bkit.mdi,	curLoop 		gpy=lis	}
W emors^ )o {	diouilina ) { 
nback sid )o {J!
					secuion
lina ) { 	}
Wecuion
lir 	aanyFo {W eange	diouierer
				--cuion
lir 	acurLoopfi(W ead of/gpy=lisl}/{varna r
				--c) { 	}
Wecuion
aOr oes		tntext lef?re/gp
lir 	aanyFo {W eange	di=lisl}/{lisl}/{er
	
	 tl}/{varna ) { )o {J!
 ) {
			// Optioner
y.is
!
nback sOptioner
rcurLoopQ
eoes		tIouier
	
ion
	 elsrs=eelsrTllback l alsr.bkit.[	=== d], ""
	e(tioner
y.is
!anyFo {sOptionerrg
	},moryouier
	
(thnal brdtk
/ 
	 }/

	 }/{tur/ E is usem		// (eelsress diis
y.is
elsrs=
 )aldreturn 
y.is
anyFo {W 
					secuion;Sizzes.err ls
elsrievu
ional				--cuional brdtk
rnr j}// F}//	}tualds
 elsry//		r
isO
	},tcurLoopy//vu isSizzes.err rs=,acce:nam	 msgsecuionthtw(mewErr ls
"Sygiax err r,) {ragogndefdeelsress di: "r+ msgsey//vu is/**
 *sUti);y,acce:namr, leoe	reiv
	 Gdedi;mundef  ofra{ a ) ) of d e ahe D	} *s@er am {s ) )|E			leQ						
 *///sli,geQT;mW eSizzes.geQT;mW eacce:nam	  obdretur     slidi, ahe ,	}l,cti),
=
	accn,cti),
,isrg
	s
	""/
is ) {
,cti),
returna ) {
,cti),
=ta 1(!i,cti),
=ta 9return regex tedi;mC gi		l	me inIerT;mW, le
		// hrvrn
y.ise/  of
	accni;mC gi		l=ta 'u			//'return jQrred;
	accni;mC gi		l
rn
						--cy.ise/  of
	accninIerT;l=ta 'u			//'return jQallbfeback sIE t	ca )iagunrred;srn jQrred;
	accninIerT;lTllback l rR
	},,i''re
rn
						--curnaOMM noTrahids/ble t	ceild wi/ 
t0, len
	acc=
	accn

	Ceild;
	acc;
	acc=
	accnn;lSiblloweturnaOr oet +a,geQT;mn
	acc 		/ 
	 }/

	 }/{						--cy.ise,cti),

		//(!i,cti),
=ta 4ietudiat;
			
	accn,ctiVdefi// 
}/ D
			--cuvaE is usedsno,cti),
, jQuesueeelseceedoGo	eFra{ a ) )ret0, length = h;(,ct
=
	accfi()				if 			}i eed to	ndtinrahids/bc m// h,ctirvrn
y.is,ctin,cti),
!ta 8f 			}Or oet +a,geQT;ms,cti 		/

	 }/{tur/ D

g
	},

	e(t}vu isvar alsrW eSizzes.s
		//ors	=sty. ord	r	mo "ID", "NAME", "TAG"d],u isbkit.astagyuID: /#(to	[\w\u00c0-\uFFFF\-]|\\.)+)/,isrgCLASS: /\.(to	[\w\u00c0-\uFFFF\-]|\\.)+)/,isrgNAME: /\[= fa=['"]*(to	[\w\u00c0-\uFFFF\-]|\\.)+)['"]*\]/,isrgATTR: /\[\s*(to	[\w\u00c0-\uFFFF\-]|\\.)+)\s*to	(\S?=)\s*to	(['"])(.*?)\3|(#?to	[\w\u00c0-\uFFFF\-]|\\.)*)|)|)\s*\]/,isrgTAG: /^(to	[\w\u00c0-\uFFFF\*\-]|\\.)+)/,isrgCHILD: /:(ailh|nth|last|

	)-ceildto	\(\s*tu			|odd|to	[+\-]?\d+|to	[+\-]?\d*)?n\s*to	[+\-]\s*\d+)?))\s*\))?/,isrgPOS: /:(nth|eq|gt|lt|

	|last|u			|odd)to	\(t\d*)\))?to=[^\-]|$)/,isrgPSEUDO: /:(to	[\w\u00c0-\uFFFF\-]|\\.)+)to	\((['"]?)(to	\([^\)]+\)|[^\(\)]*)+)\2\))?// DeferlorleftM
		ast glomal		reMapastagyu"class": "classgCas",isrg	rig": "v "eFig"isr glomal		rrH doe	astagyuhre :eacce:nam	  obdretudiat;
			
	accngeQA	rribui}(oyhre "
	e(th },	}l// M:eacce:nam	  obdretudiat;
			
	accngeQA	rribui}(oy// M"
	e(th }isr glomalbmieveastagyu"+":eacce:nam"c valSeem	er t)ugpy= slidisPr tS		J=e/  ofeer t = |n)u			//o,	}ltuisTagJ=eisPr tS		J&&
	rNonW.-catch"eer t ),	}ltuisPr tS	rNotTagJ=eisPr tS		J&&
	isTag	/ iona ) {	isTagf 			}Or er t =eer t.toL
})Cas/(	// 
		regpy=in listsligth = 	f h =c valSee< lengta  obdh; i++					if 			}lie!== h(	acc=(c valSeefi()f 			}lierreilf= h(	acc=  obd.c(u	iousSibllowerid 	accn,cti),
!ta 1Q 			
(thnal c valSeefi(= isPr tS	rNotTagJ|| 	accrid 	accn,ctigCas.toL
})Cas/(	 = |eer t ?rn  t;tu obd	me );
  :rn  t;tu obd	= |eer t	/ 
	 }/

	 }/ iona ) {	isPr tS	rNotTagf 			}O t;Sizzes.onlt	rdrer 
m(c valSerme
//fo	/rn 	l}/ y			ffy.jQ">":eacce:nam" c valSeem	er eretugpy= slid obd,	}ltuisPr tS		J=e/  ofeer t = |n)u			//o,	}ltuih = ,	}ltu h =c valSee< lengt	/ iona ) {eisPr tS		J&&
	rNonW.-catch"eer t )f 			}Or er t =eer t.toL
})Cas/(	// / 
t0, len
h; i++					if 			}lie		acc=(c valSeefi(e(tioner
y.is  obdretudiat;y= slider 		l=r obd=er wid tr  ( uhnal c valSeefi(=der 		ln,ctigCas.toL
})Cas/(	 = |eer t ?der 		l: );
 Iouier
	
	 tl}/{rn
						--cu/ 
t0, len
h; i++					if 			}lie		acc=(c valSeefi(e(tioner
y.is  obdretudiat;y= c valSeefi(= isPr tS	r ?rn  tlie		accner wid tres:rn  tlie		accner wid tres= |eer tIouier
	
	 tl}/{rn
na ) {eisPr tS		retudiaO t;Sizzes.onlt	rdrer 
m(c valSerme
//fo	/rn 	ll}/n 	l}/ y			ffy.jQ"":eacce:nam"c valSeem	er ri 
sXML)ugpy= sli,ctiC val,	}lt	dontgCas	  dont++,rnQy= c valFn	  dirC val	/ iona ) {e/  ofeer t = |n)u			//oJ&&
	rNonW.-catch"eer t )f 			}Or er t =eer t.toL
})Cas/(	// Or ,ctiC val |eer tIonQy= c valFn	  dirNctiC val// 
		regpy= c valFn(oyer wid tre"m	er ri dontgCasm(c valSerm,ctiC valm(isXMLse// y			ffy.jQ"~":eacce:nam" c valSeem	er em(isXMLsecugpy= sli,ctiC val,	}lt	dontgCas	  dont++,rnQy= c valFn	  dirC val	/ iona ) {e/  ofeer t = |n)u			//oJ&&
	rNonW.-catch"eer t )f 			}Or er t =eer t.toL
})Cas/(	// Or ,ctiC val |eer tIonQy= c valFn	  dirNctiC val// 
		regpy= c valFn(oye(u	iousSibllow"m	er ri dontgCasm(c valSerm,ctiC valm(isXMLse// y		isr glomalf		dastagyuID:eacce:nam",bkit.,(c gi;
m(isXMLreturn 
y.ise/  ofec gi;
ngeQE			leQById ! |n)| jQuer}oJ&&
	isXMLreturn y= slic=ec gi;
ngeQE			leQById(bkit.[1re//naOMM noC val er wid treoGo	ckit.are seBlaalberry 4.6nrred;s/naOMM n,ctisectedliable  lon		rsunr
		eateEleme#6963rn jQrred;
crid mner wid tres?	[ms:moryouiel}/ y			ffisrgNAME:eacce:nam",bkit.,(c gi;
return 
y.ise/  ofec gi;
ngeQE			leQsBygCas ! |n)| jQuer}oreturn y= slirre ];[]ddBoral oes		ts ];c gi;
ngeQE			leQsBygCas(	bkit.[1rievu
iony=in listsligth = 	f h +oes		ts< lengt		 i++					if 			}llie!==	 oes		tsfi(ngeQA	rribui}("nCas"	 = |ebkit.[1rsOptionerrg
tntext oes		tsfirsOIouier
	
	 tl}/{rn
na 
	},

	< lengtQ ta 0f?					s:

	youiel}/ y			ffisrgTAG:eacce:nam",bkit.,(c gi;
return 
y.ise/  ofec gi;
ngeQE			leQsByTaggCas ! |n)| jQuer}oreturn jQrred;
c gi;
ngeQE			leQsByTaggCas(	bkit.[1rieyouiel}/ y		ret glo	praFnlt	rastasrgCLASS:eacce:nam(,bkit.,	curLoopi 
nback ieoes		ti mori 
sXMLreturn  bkit.J=h" "r+ bkit.[1rTllback l rBa
tlash, ""
	r+ " "	/ iona ) {eisXMLreturn jQrred; bkit.// 
		regpy=in listsligth = a  obdh;(	af?h =curLoopfi()i!
									if 			}liny.is  obdretudiatliny.isemors^;(	af?.classgCasQ&&	"" "r+ 	af?.classgCasr+ " ")Tllback l/[\t\n\r]/g, " ")Ti jQxOf(bkit.) > = )f 			}Or r
y.is
!
nback sOption
aOr oes		tntext
	acc 		/ 
	 
		regpy=i						--cy.ise
nback sOption
aOracurLoopfi(W ead of/gpy=l
	
	 tl}/ 
		rediat;
			ead of/gpyt gloagyuID:eacce:nam",bkit.retudiat;
			 bkit.[1rTllback l rBa
tlash, ""
	;/ y			ffisrgTAG:eacce:nam",bkit.,(curLoopretudiat;
			 bkit.[1rTllback l rBa
tlash, ""
	.toL
})Cas/(	;/ y			ffisrgCHILD:eacce:nam",bkit.retuiona ) {ebkit.[1r = |n)nthoreturn r
y.is
!bkit.[2]sOptional;Sizzes.err lebkit.[0sse//{	 
		regpy=i	bkit.[2]W ebkit.[2]Tllback l/^\+|\s*/g,i''	//arrayure ter seruqua:namsxllt t'u			',i'odd',i'5',i'2	',i'3n+2',i'4n-1',i'-n+6'rn y= sliatch dc/(-?)t\d*)to	n([+\-]?\d*))?/m( ecyrn y=i	bkit.[2r = |n)u			oJ&&
"2n"(!i
bkit.[2r = |n)oddoJ&&
"2n+1"(!irn y=i	!/\D/catch"ebkit.[2]sOJ&&
"0n+"r+ebkit.[2]s!i
bkit.[2r	//arrayure tc//cubmi}r
		numbsrse(

	)n+(last)rincl}elowsufinfoyliableegmievegpy=i	bkit.[2]W e(atch[1r +e(atch[2]s!i
1)et-	/y//y=i	bkit.[3]W eatch[3]t-	/y//y=i}/ 
			--cy.isebkit.[2]sOptioal;Sizzes.err lebkit.[0sse//{	 
urn a callbTODO: MoveoGo it by  rgj!ingtyysef? a cabkit.[0s	  dont++//{diat;
			 bkit.;/ y			ffisrgATTR:eacce:nam(,bkit.,	curLoopi 
nback ieoes		ti mori 
sXMLreturn  sli,Cas	  bkit.[1r = bkit.[1rTllback l rBa
tlash, ""
	//{	 
iona ) {e	isXMLridhalsr			reMap[= fa]sOptioal;bkit.[1r =halsr			reMap[= fa]//{	 
urn a cae tH doesr) {ec	un-quoeedundef swaslus/e a cabkit.[4]W e( bkit.[4]s!i
bkit.[5]s!i ""
	Tllback l rBa
tlash, ""
	//{iona ) {ebkit.[2r = |n)~=oreturn rabkit.[4]W=h" "r+ bkit.[4]r+ " "//{	 
urn iat;
			 bkit.;/ y			ffisrgPSEUDO:eacce:nam(,bkit.,	curLoopi 
nback ieoes		ti morretuiona ) {ebkit.[1r = |n)mororeturn rs usedswe'r	sdoallowt shr a c melexeelsress divto	 alslmele(on s lie!== h(chunksrm( ecybkit.[3])s!i ""
	T lengt> 1s!i /^\w/catchybkit.[3])return rs	bkit.[3]W eSizzesybkit.[3],					,					,	curLoop	//{ionr
				--cuion
lislirre ];Sizzes.onlt	rybkit.[3],	curLoopi 
nback me
//fo^ mor	//{ionr

y.is
!
nback sOption
aOr oes		tntext.a fuy(	oes		t,rre )youier
	
(thnal;
			ead of/gpyr
	
(thn					--cy.isealsr.bkit..POScatchyebkit.[0ss)s!iealsr.bkit..CHILDcatchyebkit.[0ss)sOption
aOrred;r
// I/y=i}/ 
	 iat;
			 bkit.;/ y			ffisrgPOS:eacce:nam",bkit.retuiona bkit..un					se
//fo	/rn iat;
			 bkit.;/ y		ret glo	lo	onlt	r)astagyuenstild:eacce:nam	  obdretudiat;
			
	accnuopstildQ ta );
	rid 	accn// M ! |n)hido		o;/ y			ffisrguopstild:eacce:nam	  obdretudiat;
			
	accnuopstildQ ta 
// I/ y			ffis= c valld:eacce:nam	  obdretudiat;
			
	accnc valldQ ta 
// I/ y			ff
	 iats
		//ld:eacce:nam	  obdretuda callbaeless
	 Gdis
		// (We=mat s s
		//ld-by-dhrefNoda callbop:namsxin 	 "ts  ).k
		// (le a y ) {r obd=er wid tr sOption
aO obd=er wid tr .s
		//ldI jQxI/y=i}/ 
	 iat;
			
	acc.s
		//ldQ ta 
// I/ y			ffis= er wid:eacce:nam	  obdretudiat;
			
!!	accn

	CeildI/ y			ffis=  cell:eacce:nam	  obdretudiat;
			
!	accn

	CeildI/ y			ffgpy=E i:eacce:nam	  obdmdi,,bkit.retudiat;
			
!!Sizzes	 bkit.[3],	 obdr	T lengtI/ y			ffgpy=Eead	r:eacce:nam	  obdretudiat;
			
(/h\d/i)catchs
	accn,ctigth ; I/ y			ffgpy=i;
:eacce:nam	  obdretudiatssli
		r	J=
	accngeQA	rribui}(oy// M"
	md// MJ=
	acc.unct;gpjQllent6ra{r7t sn		mcV
	acc.unctoGo 'i;
'W, l(mewHTML5d// Ms (seyst.,	etc) gpjQllaus/ geQA	rribui} trueeadoGo atch GdisijesMdiat;
			 	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"i;
" = |e// sQ&&	"
		r	 = |e// sQ!ie		r	 = |					; I/ y			ffgpy=ains :eacce:nam	  obdretudiat;
			
	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"ains " = |
	acc.unctI/ y			ffgpy=/ valboi:eacce:nam	  obdretudiat;
			
	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"/ valboi" = |
	acc.unctI/ y			ffgpy=onlM:eacce:nam	  obdretudiat;
			
	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"onlM" = |
	acc.unctI/ y			ffgps	}
).d:eacce:nam	  obdretudiat;
			
	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"	}
).d" = |
	acc.unctI/ y			ffgpssub( t:eacce:nam	  obdretudiat;sli,Cas	 
	accn,ctigCas.toL
})Cas/(	;diat;
			
(,Cas	  |e	inputoQ!ie,Cas	  |e	Namton"OJ&&
"sub( t" = |
	acc.unctI/ y			ffgpsim}gM:eacce:nam	  obdretudiat;
			
	accn,ctigCas.toL
})Cas/(	 = |e	inputoJ&&
"im}gM" = |
	acc.unctI/ y			ffgpr oeset:eacce:nam	  obdretudiat;sli,Cas	 
	accn,ctigCas.toL
})Cas/(	;diat;
			
(,Cas	  |e	inputoQ!ie,Cas	  |e	Namton"OJ&&
"oeset" = |
	acc.unctI/ y			ffgpr Namton:eacce:nam	  obdretudiat;sli,Cas	 
	accn,ctigCas.toL
})Cas/(	;diat;
			
,Cas	  |e	inputoJ&&
	Namton" = |
	acc.unctQ!ie,Cas	  |e	Namton"I/ y			ffgpr inpud:eacce:nam	  obdretudiat;
			
(/inpud|s
		//|i;
r wa|Namton/i)catchs
	accn,ctigth ; I/ y			ffgpy=
		}):eacce:nam	  obdretudiat;
			
	acc = |
	acc.awnerDateE		e.ae: veE			leQ;/ y		ret glo	setFnlt	r)astagyu

	:eacce:nam	  obdmdiretudiat;
			
iQ ta 0I/ y			ffgpy=last:eacce:nam	  obdmdi,,bkit., a ) )retudiat;
			
iQ ta a ) )< lengt- 1I/ y			( val{u!fo:eacce:nam	  obdmdiretudiat;
			
iQ% 2Q ta 0I/ y			ffgpy=odd:eacce:nam	  obdmdiretudiat;
			
iQ% 2Q ta 1I/ y			( val{lt:eacce:nam	  obdmdi,,bkit.retudiat;
			
 i+,bkit.[3]t-	/y//y			( val{gt:eacce:nam	  obdmdi,,bkit.retudiat;
			
 i>,bkit.[3]t-	/y//y			( val{nth:eacce:nam	  obdmdi,,bkit.retudiat;
			
bkit.[3]t-	/Q ta iI/ y			( val{uq:eacce:nam	  obdmdi,,bkit.retudiat;
			
bkit.[3]t-	/Q ta iI/ y		ret glo	fnlt	rastasrgPSEUDO:eacce:nam	  obdm
bkit.mdi, a ) )return  sli,Cas	  bkit.[1r,ional onlt	rs= alsr.onlt	rs=t= fae]//{iona ) {eonlt	rsOption
aOrred;ronlt	r	  obdmdi,,bkit., a ) )re;
(thn					--cy.ise,Cas	  |e	c giatruoreturn jQrred;;(	af?.i;mC gi		l	me
	accninIerT;l	me
geQT;ms[
	acc ])s!i "")Ti jQxOf(bkit.[3]) > = ;
(thn					--cy.ise,Cas = |n)mororeturn r= sli,ce ];bkit.[3]vu
iony=in listsligjh = 	f h +,ceT lengtIgjh++	Igj	if 			}llie!==	 ,ce[j] = |
	accsOptionerrg
	},ead of/gpy=l
	
	 tl}/ ion
aOrred;r
// I
(thn					--ctioal;Sizzes.err r"t= fa") (thn		/ y			ffisrgCHILD:eacce:nam	  obdm
bkit.return  sli

	,dlast,	}lt	dontgCas, er wi	,drgj!s,rnQy= coui	,  by ,rnQy= unct	  bkit.[1r,ional ,ct
=
	accI
(thn	swiit.ise/  sOptioner=lsee"ailh":ioner=lsee"

	":ionerrreilf= h(,ct
=
,ct
.c(u	iousSibllower)	ptionerrgy.is,ctin,cti),
=ta 1retu gpjQerrg
	},ead of/ /{lisl}/{er
	
	}llie!==	 r===W  |n)

	"retu gpjQe
aOrred;r
// I /{er
	
	}lll ,ct
=
	accI
(tner=lsee"las	":ionerrreilf= h(,ct
=
,ct
nn;lSibllower)	ptionerrgy.is,ctin,cti),
=ta 1retu gpjQerrg
	},ead of/ /{lisl}/{er
	
	}llierred;r
// I
(tner=lsee"nth":ionerr

	W ebkit.[2]/gpy=l
lase ];bkit.[3]vu
ioerrgy.is

	=ta 1Q&&	lase

	/fetugpy=llierred;r
// I
lisl}/{er
/{er
dontgCas	 ebkit.[0sI
lisler 		l=r obd=er wid tr  ( uioerrgy.iser widQ&&	"er wid[ ndD
		:d]s! |ndontgCass!i !	accn,ctiI jQx)sOption
ay= coui	 a 0I/ y	er
/{eny=in list,ct
=er widn

	CeildIt,ct
It,ct
=
,ct
nn;lSibllowsOptionnerrgy.is,ctin,cti),
=ta 1retuionnerlll ,ct
n,ctiI jQx=
++coui		di=lisl}/{lisl} /{varna rer wid[ ndD
		:d]s|ndontgCasI
lisl}/{er
/{er
dby =r obd=,ctiI jQx-	lasevu
ioerrgy.is
se

	/fetugpy=llierred;rdby 

	/	diouier
				--tugpy=llierred;r(rdby %
se

	/Q&&rdby /
se > =  )youier
	(thn		/ y			ffisrgID:eacce:nam	  obdm
bkit.return  
			
	accn,cti),
=ta 1Q&&		accngeQA	rribui}("id"	 = |ebkit.;/ y			ffisrgTAG:eacce:nam	  obdm
bkit.return  
			
(bkit.=t e"*/Q&&		accn,cti),
=ta 1)s!i !!	accn,ctigth rid 	accn,ctigCas.toL
})Cas/(	 = |ebkit.;/ y			f y	asrgCLASS:eacce:nam	  obdm
bkit.return  
			
(" "r+;(	af?.classgCasQ!i 	accngeQA	rribui}("class")	r+ " ")vrn
Ti jQxOf(
bkit.rei>,-1;/ y			ffisrgATTR:eacce:nam	  obdm
bkit.return  sli,Cas	  bkit.[1r,ioaOr oes		t ];Sizzes.at	r ?rn  tliSizzes.at	r	  obdm,CasJ):var t;palsr			rrH doe	=t= fae] ?rn  t;palsr			rrH doe	=t= fae]	  obdJ):var t;p obd=t= fae]i!
					 ?rn r t;p obd=t= fae]s:rn  tlie	accngeQA	rribui}(,CasJ),ioaOr ndef s +oes		tr+ "",rnQy= unct	 ebkit.[2],rnQy= c val	 ebkit.[4]/rn iat;
			 oes		t ]
					 ?rn r tr===W  |n)!="s:rn  tl!// sQ&&;Sizzes.at	r ?rn Or oes		t !
					 :rn r tr===W  |n)="s?ioaOr ndef=W  |nc val :rn r tr===W  |n)*="s?ioaOr ndef=Ti jQxOf(c val) > =  :rn r tr===W  |n)~="s?ioaOr (" "r+;ndef=r+ " ")Ti jQxOf(c val) > =  :rn r t	/ vals?ioaOr ndef=W&&;oes		t !ta );
	 :rn r tr===W  |n)!="s?ioaOr ndef=W! |nc val :rn r tr===W  |n)^="s?ioaOr ndef=Ti jQxOf(c val)W   =  :rn r tr===W  |n)$="s?ioaOr ndef=5subu		ndef=< lengt- c val< lengt)W  |nc val :rn r tr===W  |n)|="s?ioaOr ndef=W  |nc val !i ndef=5subu		0, c val< lengts+d1)W  |nc val + "-"s:rn  tl);
	;/ y			ffisrgPOS:eacce:nam	  obdm
bkit.mdi, a ) )return  sli,Cas	  bkit.[2r,ional onlt	rs= alsr.setFnlt	rs=t= fae]//{iona ) {eonlt	rsOption
aOrred;ronlt	r	  obdmdi,,bkit., a ) )re;

	 }/{tur/ D
t}vu isvarho		gPOSs= alsr.bkit..POSglo	fescapsr=tacce:nam"a		,			m)uisrg
	},m)\\"r+;(		mt-	/s+d1) /}vu isn listslitunctQindalsr.bkit.sOptionalsr.bkit.[	=== d]r=tmewRegalsl alsr.bkit.[	=== d].sourcer+;(/(?![^\[]*\])(?![^\(]*\))/.source)re;

alsr	leftMkit.[	=== d]r=tmewRegalsl /(^to	.|\r|\n)*?)/.sourcer+ alsr.bkit.[	=== d].sourceTllback l/\\(\d+)/g,ifescape)re;
}u isvar	mat s ) )r=tacce:nam" a ) ), oes		ts ecuis a ) )r=ts ) ).		/to eve.s);k  onheg a ) ), 0revu is ) { oes		ts ecuis oes		tsntext.a fuy(	oes		ts, a ) )re;rnaO
	},toes			sy//		r
	asO
	}, a ) );
vu oegexPe rigc alslmele(c val Go det	rmer} ifoGdeubif serrisijepstil ofisll
c ghidtlowsae treL//  Gora{ a ) ) })ingtbunltindmethods.isll
Also hidifiisectedoGdeu
	},ed a ) ) halds d e ahe Disll
(w.ft.rit	ndtISbuijesMsunr
		Blaalberryubif ser)vrtryuuis s ) ).		/to eve.s);k  onheg eateE		e.eateE		eE			leQ.ceild tres, 0re[0(n,cti),
vu oegexProvid )a );lbaaldmethod ifri
one t	ndt ).k
	ckit.druretugpymat s ) )r=tacce:nam" a ) ), oes		ts ecuis 	sligth = a iat;
r=toes			s	memory// ia ) {
toS			// onhega ) )) = |n)[it'sst s ) )]oreturna  s ) ).		/to eve.text.a fuy(	oet, a ) )re;/{var 				--turn 
y.ise/  of a ) )< lengt = |n)numbsroreturna  in listslif h  a ) )< lengt		 i++					if 			}llig
tntext a ) )firsOI
	 tl}/{rn
						--cu/ 
t0, len
h;a ) )fir				if 			}llig
tntext a ) )firsOI
	 tl}/{r j}// F}//	}rg
	},

	e(th};
}u isvar/s  tOrd	r, sibllowC val	/ ioy.is eateE		e.eateE		eE			leQ.c mer eDateE		ePosi:namf 			}s  tOrd	rr=tacce:nam" a, breturna ) {
a = | breturna =E iDuh anatiW r
// I
lir
	},d0I// F}//	}r
y.is
!a.c mer eDateE		ePosi:nams!i !b.c mer eDateE		ePosi:namf 			}lir
	},da.c mer eDateE		ePosi:nams?,-1s:
1I// F}//	}ir
	},da.c mer eDateE		ePosi:nam(bOJ& 4s?,-1s:
1 /}vu is				--			}s  tOrd	rr=tacce:nam" a, breturna ed T,e ahe Dliablid		eanal,drFijec nd trua(lerna ) {
a = | breturna =E iDuh anatiW r
// I
lir
	},d0I//rna ed F;lbaaldto })ingtsourciI jQx(gment)dufble Dlivailstil ocebogt ahe D/{						--cy.isda.sourciI jQx&&;b.sourciI jQxf 			}lir
	},da.sourciI jQxf-;b.sourciI jQxI// F}//	} 	sligal,dbla iat;ap ];[]ddBorabp ];[]ddBoraaup ];a=er wid tr ddBorabup ];b=er wid tr ddBoracurs
	aupI//rna ed edec,e ahe Dliab sibllows (orlid		eanal)drFijec do
a qu
(c valrna ) {
aup = | bup  			}lir
	}, sibllowC val" a, bre;vaE is usedsnoer widsdrFab )o {Jc,enec,e ahe Dliabhuopconn	//ldrn
					--cy.is
!aup  			}lir
	},,-1;/ rn
					--cy.is
!bup  			}lir
	},
1I// F}//	}OM nodc,erwi--cnfoy'rfty prtanda			--cynr
			refty drFy at 	}OM ndtotbunld up a )				l//  of Gde er wid tr s )or c mer ison/ 	rreilft(;curreturn  Iep.un					securre;dBoracurs
ecur=er wid tr I// F}//	}racurs
ebupI/// 	rreilft(;curreturn  Ibp.un					securre;dBoracurs
ecur=er wid tr I// F}//	}raa h  apT lengtI/ y	b h  bpT lengtI/ gpOM noStr tiw//kingteawnr
			reftlookingr, l(ahuopcllbancern=in listsligth = 		 i++a	sid	 i++b					if 			}a ) {
apfi(i!
  bpfi(f 			}lir
	}, sibllowC val
apfi(, bpfi(f ;/

	 }/{tur/ E is usWa		 jQdty plback  upr
			refty  do
a sibllow(c valrna 
			
iQ ta a	 ?rn r sibllowC val" a, bpfi(, -1s):var tsibllowC val
apfi(, bmd1 	/
t I/ gptsibllowC valr=tacce:nam" a, b,rrereturna ) {
a = | breturna =
	},

	I// F}//	} 	sligcurs
	ann;lSibllowI/// 	rreilft(;curreturn a ) {	cur = | breturna ir
	},,-1;/  tl}/{rn
	acurs
ecurnn;lSibllowI// F}//	} r
	},
1I/ DeIE do isgexC val Go se} ifoGdeubif serr
	},se
		// hr byt= faare sisgexq		rtlow bytgeQE			leQById (a{rprovid )a ).karo {)//	acce: ( detn s usWa'rftgolow Go in'sst a )at rinpute
		// ht shr aeor a fiidt= faisOsli,rigc = eateE		e.ct("diE			leQ("div"),ioaO .idi"script"r+;(	ewD"di()).geQTimi(),ioaOroot	= eateE		e.eateE		eE			leQ;r
is0, lcninIerHTMLidi"<at= fa='"r+; .i+ "'/>";r
iss usen'sst it inGo nfo roote
		// h, c val itt	u	atus,
 #4	oeeI:s it qu
lernarootninsertBe, le(,rigc, rootn

	Ceildrevu is ed T,e ).karo {
E i t  do
addi:namal c valsnded t atgeQE			leQByIdn s usW.ft.rslf s nflowsteawnr, l(oc,erubif sers (hsecfoGdeubiancflow)vrny.is eateE		
ngeQE			leQById(; .s)sOption
alsr.f		d.ID =eacce:nam",bkit.,(c gi;
m(isXMLreturn 
y.ise/  ofec gi;
ngeQE			leQById ! |n)| jQuer}oJ&&
	isXMLreturn y= slic=ec gi;
ngeQE			leQById(bkit.[1re//nrn jQrred;
cr?rn r t;cnid = |ebkit.[1rsmee/  ofecngeQA	rribui} tr  ! |n)| jQuer}oJ&&ecngeQA	rribui} tr}("id"	n,ctiVdefi = |ebkit.[1r ?rn r t;p[ms:rn r t;p| jQuer}:rn r t;oryouiel}/ y		//nrn jalsr.onlt	r.ID =eacce:nam	  obdm
bkit.return  sli,ct
=
/  of
	accngeQA	rribui} tr  ! |n)| jQuer}oJ&&e	accngeQA	rribui} tr}("id"	//nrn  
			
	accn,cti),
=ta 1Q&&	,ctiQ&&	,ctin,ctiVdefi = |ebkit.;/ y		y//		r
rnarootnoeeI:sCeild(,rigcrevu is ed r
		th  meeIryugmentrnaroot=
rigc 
					// })(	;di//	acce: ( detn sgexC val Go se} ifoGdeubif serr
	},seailhe
		// hrn sgeare sedolow geQE			leQsByTaggCas("*/)u is gexCt("di a )at e
		// hisOsli,div = eateE		e.ct("diE			leQ("div")y//	div.a f	 jCeild( eateE		e.ct("diCom	leQ("")revu is edthat the o	,cbc m// hsndab )o {vrny.is div.geQE			leQsByTaggCas("*/)< lengt>	/fetugpy=alsr.f		d.TAG =eacce:nam",bkit.,(c gi;
return 
sli,oes		ts ]
c gi;
ngeQE			leQsByTaggCas(	bkit.[1rieyougpjQllaFnlt	rlllC possiblebc m// hsiona ) {ebkit.[1r = |n)*oreturn r= slitmp ];[]yougpjQin listsligth = 		oes		tsfir				if 			}llie!==	 oes		tsfi(n,cti),
=ta 1retuionnerlltmpntext oes		tsfirsOIouier
	
	 tl}/{rn
na 
s		ts ]
tmp//{	 
urn iat;
			 oes		ts;/ y		y//		r
rnagexC val Go se} ifra{ a	rribui}r
	},s it by defdehre  a	rribui}s//	divninIerHTMLidi"<athre ='#'></a>";r
isny.is div.

	CeildQ&&
/  of
div.

	CeildngeQA	rribui  ! |n)| jQuer}oJ&& iat;div.

	CeildngeQA	rribui (yhre ") ! |n)#"reiur va;palsr			rrH doe	.hre  =eacce:nam	  obdretudiat;
			
	accngeQA	rribui}(oyhre ", 2Q);/ y		y//		r
rnagd r
		th  meeIryugmentrnadiv 
					// })(	;/ ioy.is eateE		e.q		rtS
		//orA		secuion	acce: ( detn = slialdSizzesr=tSizze ddBoradiv = eateE		e.ct("diE			leQ("div")ddBoaO .idi"__sizze __";r
isn	divninIerHTMLidi"<p class='TEST'></p>";r
isnagd 	 "ts  jec't E does up/ (jesMs liunicctiQ
 *ract	rsare sisnagd gmequrlsnmctinisnny.is div.q		rtS
		//orA		s&&
div.q		rtS
		//orA		(".TEST/)< lengt

	/fetugiat;
			I/ y		ret/ y	Sizzesr=tacce:nam"dq		rt,(c gi;e,/;
ramdse// Optione c gi;
s=	c gi;
smereateEleQI
// OM nodilhaus/ q		rtS
		//orA		son itn-XMLreateEleQs// OM no(ID s
		//orsreac't ).k
in itn-HTMLreateEleQs)vrn
y.is
	s
edridh!Sizzes.isXMLc gi;
)sOption
aagd 	e} ifrrFyf		dsa s
		//or Go sp
ed uprn r= slibkit.= /^(\w+$)|^\.([\w\-]+$)|^#([\w\-]+$)/m( ec"dq		rtsOIouiervarna ) { bkit.ridhc gi;
.,cti),
=ta 1(!i	c gi;
n,cti),
=ta 9)sOption
aaagd 	p
ed-up:eSizzesy"TAG")vrnna ) {ebkit.[1r etugpy=llierred;rmat s ) ),
c gi;
ngeQE			leQsByTaggCas(dq		rtsO,/;
rasOIouier
ion
aaagd 	p
ed-up:eSizzesy".CLASS")vrnna 				--cy.iebkit.[2rridhalsr.f		d.CLASSrid
c gi;
ngeQE			leQsByClassgCas etugpy=llierred;rmat s ) ),
c gi;
ngeQE			leQsByClassgCasebkit.[2rsO,/;
rasOIouier
	
	 tl}ouiervarna ) { c gi;
n,cti),
=ta 9sOption
aaagd 	p
ed-up:eSizzesy"body")vrnna ed T,e bodye
		// heailhe
x// seaik m
ide mizFyf		elowsutvrnna ) {(dq		rt=ta "body"rid
c gi;
nbody etugpy=llierred;rmat s ) ),
[
c gi;
nbody ],/;
rasOIouiier
ion
aaagd 	p
ed-up:eSizzesy"#ID")vrnna 				--cy.iebkit.sidubkit.[3r etugpy=ly= slid obc=ec gi;
ngeQE			leQById(ubkit.[3rieyougpjQaOMM noC val er wid treoGo	ckit.are seBlaalberry 4.6nrred;s/naOMMMM n,ctisectedliable  lon		rsunr
		eateEleme#6963rn jQa ) {( 	accrid 	obd=er wid tr sOption
aO cae tH doesISbuijesMstandaent
 #4	O/ (anrred; lef?sion
aO cae  byt= f} trueeadoof IDgpOMjQa ) {( 	accnid = |ebkit.[3r etugpy=y=llierred;rmat s ) ),
[ 	acc ],/;
rasOIouiie	 tl}ouierer
ion
aa						--cu/ =y=llierred;rmat s ) ),
[],/;
rasOIouie	 tl}ouiesl}/{er
/{er
trytugpy=llierred;rmat s ) ),
c gi;
nq		rtS
		//orA		(q		rtO,/;
rasOIouier
	ckit.dqsaErr l 			
(thnalgexqSA ).kt	u
ran		lheon E			leQ-rooeeduq		ri D/{		is usWa	jec ).kliao {Jc,ir byeor a ftlow ec ;
ra IDeon nfo rootrrayure t do ).klow upist
 tandae(TE dkt	Go	AndrewDup gi
rig Gdedi;chnique)rrayure ent
8one tc't ).keon it'sst 
		// hrn na 				--cy.iec gi;
.,cti),
=ta 1(id
c gi;
n,ctigCas.toL
})Cas/() ! |n)it'sstoreturn r== slialdC gi;
s=	c gi;
,gpy=lliealds=	c gi;
ngeQA	rribui}(oyidore,gpy=llienid =ald	me id,gpy=la =E iPr 		l=rc gi;
ner wid tre,gpy=la lbmieveHieryst.tS
		//or= /^\s*[+~]/catch"eq		rt
	e(tioner
y.is
!aldreturn 
r rc gi;
nseQA	rribui}(oyido, nid OIouier
			--cu/ ==llienid = nidTllback l /'/g, "\\$&" OIouier
ioner
y.is
bmieveHieryst.tS
		//orid
E iPr 		leturn 
r rc gi;l=rc gi;
ner wid treIouier
io/{er
trytugpy=er
y.is
!bmieveHieryst.tS
		//or	me
E iPr 		leturn y=llierred;rmat s ) ),
c gi;
nq		rtS
		//orA		(n)[id='"r+;n .i+ "'] "r+dq		rtsO,/;
rasOIouier
io/{er
	ckit.dps/udoErr l 		/{er
yf		;lytugpy=er
y.is
!aldreturn 
r r	aldC gi;
noeeI:sA	rribui}(oyidoreIouier
gpy=l
	
	 tl}/ 
		re
	 iat;
			aldSizzes(q		rt,(c gi;e,/;
ramdse//);/ y		y//rn=in listsli
		// i	aldSizze sOption
aSizze [
		// ] =aldSizze [
		// ]I// F}//	} rgd r
		th  meeIryugmentrnaadiv 
					// 	})(	;/ }di//	acce: ( detn ssli
v "e	= eateE		e.eateE		eE			le
,gpy=bkit.Mss=,v "e.bkit.MsS
		//or	me
v "e.bozMkit.MsS
		//or	me
v "e.webkitMkit.MsS
		//or	me
v "e.msMkit.MsS
		//or;r
isny.is bkit.MssOptionagexC val Go se} ufble D possiblebt  do
bkit.MsS
		//orionagexon ahuopconn	//ld	,ctiQ(nt
9 )ailsJc,ir)n = slihuopconn	//ldMkit.= !bkit.Ms onheg eateE		e.ct("diE			leQ( "div"sO, "div"re,gpy=lps/udoW.ktW  );
 y//

trytugpya ed T,irlshluldr)ailt shr ec ;cep:namgpya ed Gvaloone t	ndt err r,nrred;s );
  trueeadgpya bkit.Ms onheg eateE		e.eateE		eE			le
,n)[atch!='']:sizze oreIouioui
	ckit.d ps/udoErr lsOptgpy=lps/udoW.ktW r
// I/ F}//	} rSizzes.bkit.MsS
		//ors=,acce:nam	 ,cti, elsrsecuisOure that the oected a	rribui} s
		//orsliablquoeedisO	 elsrs=eelsrTllback l/\=\s*t[^'"\]]*)\s*\]/g, "='$1']"	//{iona ) {h!Sizzes.isXML	 ,ctis)sOption

trytu ioner
y.is
ps/udoW.kt	me
	alsr.bkit..PSEUDOcatch" elsrseridh!/!=/catch" elsrs)sOption

lislirre ];bkit.Ms onheg ,cti, elsrieyougpjQaOMM nont
9 D bkit.MsS
		//orsrred;s );
  onhuopconn	//ld	,ctisgpy=er
y.is
rre	me
	uopconn	//ldMkit.(!irn y=i	 callbasdrF		,huopconn	//ld	,he Dliab saidoGo	eFrin aheateE		ern y=i	 callbfragE		erinont
9mdso c val n lectedionnerlll ,ct
neateE		eridh,ct
neateE		
n,cti),
!ta 11retuionne
na 
	},

	Iouier
gpy=l
	
	 i
	ckit.deetu}/ 
		rediat;
			eSizzes(elsr,					,					,r[,cti]O< lengt>	/y/ y		y//		/ })(	;di//	acce: ( detisOsli,div = eateE		e.ct("diE			leQ("div")y////	divninIerHTMLidi"<div class='atch e'></div><div class='atch'></div>";r
iss u	O/ (a jec'tyf		dsa s
cond class= f}(gme9.6)n =ll
Alsom
bat the oected geQE			leQsByClassgCas actunhehe
x// sis ) {
	divngeQE			leQsByClassgCas me
divngeQE			leQsByClassgCas("e/)< lengt

	/fetugit;
			I//		r
rnagd 	 "ts  jet.Ms class a	rribui}s,one tc't	ckit. c an		s(gme3.2)//	divnlas	CeildnclassgCasQ|n)u";r
isny.is
divngeQE			leQsByClassgCas("e/)< lengt

	1fetugit;
			I//		ret/ yalsr	ord	r+/ );k l1,= 	f"CLASS")I//	alsr.f		d.CLASS =eacce:nam",bkit.,(c gi;
m(isXMLreturn y.ise/  ofec gi;
ngeQE			leQsByClassgCas ! |n)| jQuer}oJ&&
	isXMLreturn y=
			ec gi;
ngeQE			leQsByClassgCas(bkit.[1reI/ y		ret ;r
rnagd r
		th  meeIryugmentrnadiv 
					// })(	;/ ioacce:nam dirNctiC val( dir,	curi dontgCasm(c valSerm,ctiC valm(isXMLseturnin listsligth = 	f h =c valSee< lengt		 i++					if 			}lslig	acc=(c valSeefi(e(tionny.is  obdretudiat slibkit.W  );
 y//
 		acc=  obd[dir]vu is		rreilfis  obdretudiat ny.is  obd[ ndD
		:d]s| |ndontgCasreturnaOr bkit.J=(c valSeef	accnsizseQ]e(thnal brdtk
/ 
	 }/
diat ny.is
	accn,cti),
=ta 1Q&&
	isXMLre		}lie		acc[ ndD
		:d]s|ndontgCasI
lisl	accnsizseQs|ni
/ 
	 }/
diat ny.is 	accn,ctigCas.toL
})Cas/(	 = |ecurreturnaOr bkit.J= 	acce(thnal brdtk
/ 
	 }/
dia 		acc=  obd[dir]vu 
	 }/
dia c valSeefi(|ebkit.;/ tur/ D
t}/ ioacce:nam dirC val( dir,	curi dontgCasm(c valSerm,ctiC valm(isXMLseturnin listsligth = 	f h =c valSee< lengt		 i++					if 			}lslig	acc=(c valSeefi(e(tionny.is  obdretudiat slibkit.W  );
 y//at 
 		acc=  obd[dir]vu is		rreilfis  obdretudiat ny.is  obd[ ndD
		:d]s| |ndontgCasreturnaOr bkit.J=(c valSeef	accnsizseQ]e(thnal brdtk
/ 
	 }/
diat ny.is
	accn,cti),
=ta 1QOptioner
y.is
!
sXMLseturnilie		acc[ ndD
		:d]s|ndontgCasI
lisll	accnsizseQs|ni
/ 
	  }/
diat ny.ise/  ofecurr! |n)u			//oJeturnilieny.is
	acc = |ecurreturnaOr r bkit.J=r
// I/ Fhnal brdtk	/ 
	 
		regpy=i						--cy.iseSizzes.onlt	ry	curi f	acc]sO< lengt>	/returnaOr  bkit.J= 	acce(thhnal brdtk	/ 
	 
}/ 
	 }/
dia 		acc=  obd[dir]vu 
	 }/
dia c valSeefi(|ebkit.;/ tur/ D
t}/ ioy.is eateE		e.eateE		eE			leQ.c giatrureturnaSizzes.c giatrur=tacce:nam" a, breturnir
	},dai!
  bridha.c giatrur? a.c giatru(bOJ:r
// ) /}vu is				--	i.is eateE		e.eateE		eE			leQ.c mer eDateE		ePosi:namf 			}Sizzes.c giatrur=tacce:nam" a, breturnir
	},d!!(a.c mer eDateE		ePosi:nam(bOJ& 16) /}vu is				--			}Sizzes.c giatrur=tacce:nam"eturnir
	},d);
 y//DeIE do isSizzes.isXML =eacce:nam	  obdretudiagd eateE		eE			leQ(is hidifiid )or cas/sstandaeitone tc't	yete
x// diagd (sut.Jas loaelowsufrCassrinont
- #4833) isOsli eateE		eE			leQ(=;(	af?h?
	acc.awnerDateE		l	me
	accJ:r0).eateE		eE			leQ;r
isr
	}, eateE		eE			leQ(? eateE		eE					
n,ctigCas ! |n)HTML": );
 Iot}vu isvar posProlesur=tacce:nam" s
		//or,(c gi;
mdse//secuisOsli,bkit.,isOltmpSre ];[]ddBorbmi}rs
	"",ioaOroot	=ec gi;
.,cti),
?	[c gi;
]s:(c gi;
;r
rnagd Posi:namfs
		//orslmust	eFndontnded g Gdedonlt	rn =ll
Andty lmust	:ndt(posi:namal)ty drFyeI:s nhe PSEUDOt	Go Gda		 jvarreilftu(bkit.J=halsr.bkit..PSEUDOm( ec"fs
		//orse)retudBorbmi}rs+ ebkit.[0sI
lis
		//ors=,s
		//orTllback lhalsr.bkit..PSEUDO, ""
	//{	do isis
		//ors=,alsr	bmieve[s
		//orr ?fs
		//ors+n)*or:fs
		//or//{rnin listsligth = 	f h =rooe< lengt		 i++					if 			o;Sizzes s
		//or,=rooefi(, tmpSr
mdse// )v/ D

isO
	},eSizzes.onlt	ry	bmi}r, tmpSr
 )v/
vu oegexEXPOSEoegexOhidrid )sizze  a	rribui}r
rriendeisSizzes.		r	J=
jQ		rt.		r	vu Sizzes.s
		//ors			reMap	=stvu jQ		rt.f		ds=,Sizzesvu jQ		rt.elsrW eSizzes.s
		//orsvu jQ		rt.elsr[":"]J=
jQ		rt.elsr.onlt	rsvu jQ		rt.uniqueW eSizzes.uniqueS  tvu jQ		rt.t;mW eSizzes.geQT;tvu jQ		rt.isXMLDatW eSizzes.isXMLvu jQ		rt.c giatrur=tSizzes.c giatruvu oe/ })(	;/ i isvar ru	ea h =/U	ea $/,isrrer widsc(u	h =/^to	er wids|c(u	U	ea |c(u	A		)/,isrgexNote: T,irRegalslshluld	eFrimprovedvto	xllt ehep			edist
tSizzesisrrm		tis
		//ors=,/,/,isrisSlmeleh =/^.[^:#\[\.,]*$/,isrs);k r=ts ) ).		/to eve.s);k ,isrPOSJ=
jQ		rt.elsr.bkit..POS,isrgedmethods gu*ragi;edoGo			/duk ra uniqueWseQare seu	adtlowist
ra uniqueWseQisrgu*ragi;edUniqueW 			o;ceild wi:r
// ,is rc gi;ids:r
// ,is rn;l:r
// ,is rc(u	:r
// //DeIE u jQ		rt.fn.eli;id(		olf		dasacce:nam" s
		//orf 			}lsligs
	  =Jc,irddBoaO 	f IE u ny.ise/  of s
		//orf! |n)u			//oJeturn y=
			ejQ		rt" s
		//orf .onlt	ryacce:nam"eturnjQin listth = 	f h gs
	 < lengt		 i++					if 			}llie!==	 jQ		rt.c giatru(gs
	 [	 i], jQues)fetugpy=llierred;r
// I
lisl}/{er}/ 
		)I// F}//	} 	sligrre =Jc,irntextStral( "", "f		d", s
		//orf ddBoaO lengta ivtr//{rnin listth = 	f h=Jc,ir< lengt		 i++					if 			}ll lengt


	< lengtI
lisjQ		rt.f		d" s
		//or, jQuefi(,rrere	/ iona ) {ei>	/returnaOrre that the oected Gda	
s		ts r w uniquernjQin listn

 lengt		ni++
	< lengt		n	if 			}jQin listrh = 		oi++ lengt		r	if 			}jer
y.is
rre[r]s| |
rre[n]retuionne
na 
	+/ );k ln--,y1)I/ Fhnal brdtkIouier
gpy=l
	
	 tl}/ 
		re
	}//	}rg
	},

	eisr glomalE i:eacce:nam	 	adgeQf 			}lsli 	adgeQsJ=
jQ		rt	 	adgeQf ;	}rg
	}, jQue.onlt	ryacce:nam"eturnjQin listsligth = 	f h  	adgeQr< lengt		 i++					if 			}llie!==	 jQ		rt.c giatru(Jc,ird 	adgeQrfi(s)fetugp=llierred;r
// I
	 tl}/ 
		re
	})eisr glomalndtasacce:nam" s
		//orf 			}ierred;Jc,irntextStral( winIow(c,ird s
		//or, );
 ),n)morod s
		//or)eisr glomalonlt	rasacce:nam" s
		//orf 			}ierred;Jc,irntextStral( winIow(c,ird s
		//or, 
// ),n)onlt	r", s
		//orf)eisr glomalisasacce:nam" s
		//orf 			}ierred;J!!s
		//orQ&&	"
/ 
	/  of s
		//or = |n)u			//oJ?rn rs usedsjQuesueea posi:namal s
		//or, c val membsrshi/ i	oGdeu
	},ed seQrn rs uty d$("p:

	").is("p:las	")drac't rred;r
// r, l(ahuoct shr two
"	".rn rsPOScatchyes
		//orf 	?
/ 
	isjQ		rt" s
		//or, jQue.c gi;l)Ti jQx(Jc,ir[0ss) > =  :rn 
	isjQ		rt.onlt	r" s
		//or, jQuesO< lengt>=  :rn 
	ijQue.onlt	r" s
		//orsO< lengt>= f)eisr glomalclos/stasacce:nam" s
		//ors,(c gi;
return slirre ];[]mdi,,	,	curh=Jc,ir[0sI
liionagexs ) )r(dec(unatidJas of jQ		rt 1.7)u ny.isejQ		rt.iss ) )" s
		//ores)fetugpy slilu!f h  1vu is		rreilfis curQ&& cur.awnerDateE		lQ&& curf! |nc gi;
returnjQin listth = 		 i+ s
		//ore< lengt				if 			}	}llie!==	 jQ		rts curQ).is( s
		//ore[	 i]s)fetugpy llig
tntext{ s
		//or: s
		//ore[	 i],	 obd:	curilu!f :lu!f h}OIouier
	
	 tl}/{rn
oracurs
ecur=er wid tr Iouierlu!f ++//{ tl}/{rn
o=
	},

	I// F}r
isnagd 				//isnavar poss
ePOScatchyes
		//ores)fmee/  ofes
		//ores! |n)u			//oJ?rn rsjQ		rt" s
		//ors,(c gi;
rmeejQue.c gi;l) :rn 
	i0//{rnin listth = 	f h=Jc,ir< lengt		 i++					if 			}llcurh=Jc,irfi(vu is		rreilfis curf 			}llie!==	 poss? posTi jQx(cur) >,-1s:
jQ		rt.f		d.bkit.MsS
		//or(cur, s
		//ors)fetugpy lig
tntexts curf e(thnal brdtk//{ionr
				--cuion
racurs
ecur=er wid tr Iouier
y.is
!currme
!cur.awnerDateE		l	me
curs
 |nc gi;
	me
curn,cti),
=ta 11retuionnnal brdtk/gpy=l
	
	 tl}/ 
		re
	}//	}rg
	


	< lengt> 1s? jQ		rt.unique(rreres:

	you	}ierred;Jc,irntextStral(	oet, "clos/st", s
		//orsf)eisr glomaeed tet	rmer}oGdeuposi:nam ofra{e
		// ht shrinmaeedoGdeubkit.ed seQ of 
		// hrn i jQi:eacce:nam	  obdretudin rgexNo adgeE		l, rred;ri jQiri  er wid	}r
y.is
! obdretudiat;
			
(Jc,ir[0ss&& c,ir[0s=er wid tr sOp?Jc,irnc(u	A		(O< lengt:,-1I// F}r
isnagdri jQiri  s
		//oru ny.ise/  of
	acc = |n)u			//oJeturn y=
			ejQ		rtTi s ) )" c,ir[0s,ejQ		rt	  obdret)I// F}r
isnagdrLonat}oGdeuposi:nam ofoGdeue Dired 
		// hisO=
			ejQ		rtTi s ) )"gpjQllenfri
o(uneiv DliejQ		rt it'sst,oGdeu

	e
		// htislus/e a cl	accnjq		rth?
	acc[0ss:
	acc, jQusf)eisr glomaeaddasacce:nam" s
		//or,(c gi;
return sliseQs|n/  of s
		//or = |n)u			//oJ?rn rsjQ		rt" s
		//or, c gi;l) :rn 
	ijQ		rtTmat s ) ),
s
		//orQ&&	s
		//or.,cti),
?	[
s
		//orQss: s
		//orf ddBoaOnhes|njQ		rtTmedge" c,ir.geQ(),seQs)you	}ierred;Jc,irntextStral(	isDopconn	//ld(seQ[0ss)s!i	isDopconn	//ld(nhe[0ss)s?dBoaOnhe :rn 
	jQ		rt.unique(nhe )f)eisr glomaeandS
	 :eacce:nam	 			}ierred;Jc,irnadd(Jc,irnc(u	Ot'sst )v/ D

}OIouisll
A erin)			ylslmele(c val Go se} ifra{ 
		// htishuopconn	//ldisllist
ra	eateEleme(shluld	eFrimprovedvstandaefeasible).ioacce:nam	isDopconn	//ld(ntr sOptionrred;J!ntr s!iJ!ntr =er wid tr s!iJntr =er wid tr n,cti),
=ta 11IE do u jQ		rt.eet.(		o er wid:eacce:nam	  obdretudi= slider 		l=r obd=er wid tr  ( uhrred;er widQ&&er wi
n,cti),
!ta 11r?der 		l:					// 	},	o er wids:eacce:nam	  obdretuisO=
			ejQ		rtTdir	  obdmoyer wid tre"f)eisr g	o er widsU	ea :eacce:nam	  obdmdi,,u	ea retuisO=
			ejQ		rtTdir	  obdmoyer wid tre",,u	ea f)eisr g	orn;l:eacce:nam	  obdretuisO=
			ejQ		rtTnth	  obdmo2moyn;lSibllow"f)eisr g	o e(u	:eacce:nam	  obdretuisO=
			ejQ		rtTnth	  obdmo2moye(u	iousSibllow"f)eisr g	orn;lA		:eacce:nam	  obdretuisO=
			ejQ		rtTdir	  obdmoyn;lSibllow"f)eisr g	o e(u	A		:eacce:nam	  obdretuisO=
			ejQ		rtTdir	  obdmoye(u	iousSibllow"f)eisr g	orn;lU	ea :eacce:nam	  obdmdi,,u	ea retuisO=
			ejQ		rtTdir	  obdmoyn;lSibllow",,u	ea r)eisr g	o e(u	U	ea :eacce:nam	  obdmdi,,u	ea retuisO=
			ejQ		rtTdir	  obdmoye(u	iousSibllow",,u	ea r)eisr g	o sibllows:eacce:nam	  obdretuisO=
			ejQ		rtTsibllowr obd=er wid tr .

	Ceild,	 obdr)eisr g	o;ceild wi:eacce:nam	  obdretuisO=
			ejQ		rtTsibllowr obd=

	Ceildr)eisr g	orc giwids:eacce:nam	  obdretuisO=
			ejQ		rtT,ctigCas	  obdmoyufrCas"s)s?dBoaO obd=c giwidDateE		l	me
	abd=c giwidWi jowneateE		er:rn 
	jQ		rtTmat s ) ),
	abd=ceild tres )v/ D

},eacce:nam	t= f},eamf 			}jQ		rt.fn=t= fae]r=tacce:nam",u	ea , s
		//orreturn slirre ];jQ		rtTmap(Jc,ir,eam,,u	ea r)eis	}r
y.is
!ru	ea catchyt= fae)fetugpy ls
		//or =,u	ea I// F}//	}r
y.is
s
		//orQ&&n/  of s
		//or = |n)u			//oJetugpy lrre ];jQ		rt.onlt	r" s
		//or, rret)I// F}r
isnarre =Jc,ir< lengt> 1Q&&
	gu*ragi;edUnique=t= fae]s? jQ		rt.unique(rreres:

	you	}ie!== h(c,ir< lengt> 1Qme
rm		tis
		//orcatchyes
		//orf eridhrer widsc(u	catchyt= fae)fetugpy l
	


	<(u	ers/(	;/ y		ou	}ierred;Jc,irntextStral(	oet, = f},es);k  onheg adgeE		lesO<jolo(",")f)eisr // })IE u jQ		rt.eli;id(		alonlt	rasacce:nam" elsr,	 obdsi morretui}ie!==  morretui}O	 elsrs=e":ndt("r+ elsrr+ ")";/ y		ou	}ierred;	 obds< lengt

	1s?dBoaOjQ		rt.f		d.bkit.MsS
		//or( obdr[0s, elsr)?	[
 obdr[0sQss: [ss:dBoaOjQ		rt.f		d.bkit.Ms(elsr,	 obds)eisr glomaedir:eacce:nam	  obdmddir,,u	ea return sliubkit.ed ];[]m	}llcurh=
	acc[ddire]//{io	rreilfis curQ&& curn,cti),
!ta 9Q&&	"u	ea 

	| jQuer}me
curn,cti),
!ta 1Qme
!jQ		rts curQ).is(,u	ea re)return a ) {	curn,cti),
=ta 1QOptionerbkit.edntexts curf e(thna}rn
	acurs
ecur[dir]vu 
	}	}ierred;ubkit.edeisr gloma{nth:eacce:nams curieoes		ti dir,, obdretuisr oes		t ]eoes		ts!i
1;rn sliunum ]e0//{rnin list; cur; curs
ecur[dir]return a ) {	curn,cti),
=ta 1Q&&	++num ]=]eoes		treturnnal brdtk// 
		re
	}//	}rg
	},
cureisr glo	o sibllow:eacce:nams n,, obdreturn slir ];[]//{rnin list; n; n ];nnn;lSibllowsOptionie!==  mn,cti),
=ta 1Q&&	J! |
	accsOptionerrntexts mf // 
		re
	}//	}rg
	},
rv/ D

}OIouisll
Imp		// htGdelid		eanaleacce:namy dWe=n lionlt	rt do ndtioacce:nam winIow( 
		// hr,lquy dfiir,,keep  			
rnagexCec'ty	}
					  li| jQuer}Go i jQxOf i aFnre, x 4rnagexSr
Go 0 Go ski/ u			/w(c valrnaquy dfiir ];quy dfiir !i
0//{rny.isejQ		rt.isFcce:nams quy dfiir )retuisO=
			ejQ		rtTgllb(
		// hr,lacce:nam	  obdmdiretudiatslirreVa h J!!quy dfiir onheg  obdmdi,	 obdr)eisrO=
			rreVa h=ta,keepeisrO}OIouis					--cy.is quy dfiirn,cti),
retuisO=
			ejQ		rtTgllb(
		// hr,lacce:nam	  obdmdiretudiat
			es
	acc = | quy dfiir )h=ta,keepeisrO}OIouis					--cy.is /  of quy dfiir = |n)u			//oreturn sllionlt	red ]ejQ		rtTgllb(
		// hr,lacce:nam	  obdreturn  
			
	accn,cti),
=ta 1eisrO}OIouis	y.iseisSlmelecatchy quy dfiir )retuis  
			
jQ		rt.onlt	r"quy dfiir,ionlt	red, !keepOIou
				--cuion
quy dfiir ];jQ		rt.onlt	r" quy dfiir,ionlt	redt)I// F}r
	}//	}=
			ejQ		rtTgllb(
		// hr,lacce:nam	  obdmdiretudiat
			esejQ		rtTi s ) )"  obdm quy dfiirs) > =  )h=ta,keepeisO}OIou}/////////oacce:nam ct("di	 "eFragE		es eateE		esecuisOsli	l//  ];,ctigCass+/ );es "|"re,gpys "eFrag = eateE		e.ct("diDateE		lFragE		esevu is ) { s "eFrag.ct("diE		E		esecuis	rreilfis l// < lengtetuis  s "eFrag.ct("diE		E		eyrn y=il// <pop()rn y=)I// F}r
	}	}=
			es "eFrag;
}u isvar;,ctigCasss=e"abbr|adtlcle|aside|a}elo|jecvas|datal// |details|figjep:nam|fige o|fooeer|"r+// F"Eead	r|hgao p|mark|meeer|nav|llCpud|progllss|s
c:nam|summary|e me|vid o",ioa		/ler}jQ		rth =/ejQ		rt\d+="to	\d+|				)"/g,ioa	leaelowW.fatcpck = /^\s+/,isrrxv "eTag= /<(?!r wa|br|col|embsd|hr|img|inpud|lerk|meea|er am)(([\w:]+)[^>]*)\/>/ig,ioa	taggCas= /<([\w:]+)/,ioa	tbody= /<tbody/i,ioa	v "e= /<|&#?\w+;/,ioa	noInn		v "e= /<to	script|style)/i,ioa	nojet.M= /<to	script|it'sst|embsd|op:nam|style)/i,ioa	noshimjet.Mr=tmewRegalsl"<to	"r+;,ctigCassr+ ")"moyu"),isrgedc valld="c valld"  ldc valldioa	c valld= /c valld\s*to	[^=]|=\s*.c valld.)/i,ioa	script),
= /\/(jiva|ecma)script/i,ioa	cleanScript= /^\s*<!to	\[CDATA\[|\-\-)/,ioawrapMap	=st// Fop:nam: [ 1moy<s
		// m		tiele='m		tiele'>"moy</s
		//>" ]ddBorbeg;id: [ 1moy<fiildseQ>"moy</fiildse/>" ]ddBortEead: [ 1moy<tstil>"moy</tstil>" ]ddBortr: [ 2moy<tstil><tbody>"moy</tbody></tstil>" ]ddBortd: [ 3moy<tstil><tbody><tr>"moy</tr></tbody></tstil>" ]ddBorcol: [ 2moy<tstil><tbody></tbody><colgao p>"moy</colgao p></tstil>" ]ddBorr wa: [ 1moy<map>"moy</map>" ]ddBor_dhrefNo: [= 	f""moy" ]isr g	o s "eFragE		t= ct("di	 "eFragE		es eateE		esevu iswrapMap.op:gao p= wrapMap.op:nam;iswrapMap.tbody= wrapMap.tfooe= wrapMap.colgao p= wrapMap.jep:nam= wrapMap.tEead;iswrapMap.tE= wrapMap.tdIouisll
IE jec'tysidiy def <lerk>t do <script> tags it by lerny.is
!jQ		rtTsup/  t.v "eSidiy defetuis wrapMap._dhrefNo= [ 1, "div<div>"moy</div>"e]//{}E u jQ		rt.fn.eli;id(		o=i;
:eacce:nam	 i;
return y.isejQ		rt.isFcce:namsi;
)sOptionierred;Jc,ir.eet.(acce:nam	iOptionilsligs
	 J=
jQ		rt	 jQusf)eisionils
	 .t;m	 i;
 onhegjQusmdi,	s
	 .t;m	))f)eisr
		)I// F}E u ny.ise/  of i;
 ! |n)it'sstoQ&& i;
 ! |n| jQuer}Optionierred;Jc,ir. cell().a f	 j h(c,ir[0ss&& c,ir[0s.awnerDateE		l	me
eateE		e).ct("diT;d tr 	 i;
ret)I// F}E usO=
			ejQ		rtTt;m	 jQusf)eisr glois wrapA		:eacce:nam	 v "eeturn y.isejQ		rt.isFcce:nam	 v "e)sOptionierred;Jc,ir.eet.(acce:nam	iOptioniljQ		rt(c,ir).wrapA			 v "e onhegjQusmdi)f)eisr
		)I// F}E u ny.isJc,ir[0ss)tugpya ed T, e
		// ht	Go wraptGde 	adgeQliao {diatsli wrapJ=
jQ		rt	 v "e, c,ir[0s.awnerDateE		l	).eq(0).clont(
// ) /}diany.isJc,ir[0s=er wid tr sOption
aOwrapninsertBe, le(Jc,ir[0ss)//{ tl}/{rn
aOwrapnmapyacce:nam"eturnjQislig	acc=Jc,ir /}dian	rreilfis  obd.

	CeildQ&&  obd.

	Ceildn,cti),
=ta 1QOptioner
	acc=J	accn

	CeildI/ y tl}/{rn
a 
			
	acc//{ tl}).a f	 j hjQusf)eisr		ou	}ierred;Jc,ireisr glois wrapInn		:eacce:nam	 v "eeturn y.isejQ		rt.isFcce:nam	 v "e)sOptionierred;Jc,ir.eet.(acce:nam	iOptioniljQ		rt(c,ir).wrapInn			 v "e onhegjQusmdi)f)eisr
		)I// F}E u nrred;Jc,ir.eet.(acce:nam	Optionilsligs
	 J=
jQ		rt	 jQusf)ddBor rc gi;idsh gs
	 <c gi;ids() /}diany.isJc gi;ids< lengtetuis   rc gi;ids.wrapA			 v "ere;
(thn					--c{ionils
	 .a f	 j	 v "ere; 
		re
	})eisr glomalwrap:eacce:nam	 v "eeturnilsligisFcce:nam ];jQ		rt.isFcce:nam	 v "ere;
(tierred;Jc,ir.eet.(acce:nam	iOptionijQ		rt	 jQusf).wrapA			 isFcce:nam ? v "e onhegjQusmdi)f: v "ere;re
	})eisr glomalunwrap:eacce:nam	 			}ierred;Jc,ir=er wid().eet.(acce:nam	Optionily.is
!jQ		rtT,ctigCas	 jQusm "body")sOptioniijQ		rt	 jQusf).llback Wshr	 jQus=ceild tres )v/ 
		re
	}).	 j	)eisr glomala f	 j:eacce:nam	 			}ierred;Jc,ir=domManip(adgeE		le, 
// ,lacce:nam	  obdreturn  y.isJc,irn,cti),
=ta 1QOptionerc,ir.a f	 jCeild	  obdre; 
		re
	})eisr glomalc(uf	 j:eacce:nam	 			}ierred;Jc,ir=domManip(adgeE		le, 
// ,lacce:nam	  obdreturn  y.isJc,irn,cti),
=ta 1QOptionerc,ir.insertBe, le(J	acc, jQusn

	Ceildre; 
		re
	})eisr glomalbe, le:eacce:nam	 			}iy.
(Jc,ir[0ss&& c,ir[0s=er wid tr sOp		}iierred;Jc,ir=domManip(adgeE		le, );
 ,lacce:nam	  obdreturonerc,ir.er wid tr .insertBe, le(J	acc, jQusf)eisr
		)I// 					--cy.is adgeE		ds< lengtetuis   sliseQs|njQ		rtTcleans adgeE		dsf)eisr
	seQ.text.a fuy(	seQ, jQusntos ) )")f)eisrierred;Jc,irntextStral(	seQ, "be, le", adgeE		dsf)eisr
}isr glomalded g:eacce:nam	 			}iy.
(Jc,ir[0ss&& c,ir[0s=er wid tr sOp		}iierred;Jc,ir=domManip(adgeE		le, );
 ,lacce:nam	  obdreturonerc,ir.er wid tr .insertBe, le(J	acc, jQusnn;lSibllowf)eisr
		)I// 					--cy.is adgeE		ds< lengtetuis   sliseQs|nc,irntextStral( jQusm "ded g", adgeE		dsf)eisr
	seQ.text.a fuy(	seQ, jQ		rtTclean(adgeE		le)f)eisrierred;Js
	I// F}r
r glomaeed,keepData is )or ind gmy lus/eailh--do ndtheateE		ern oeeI:sasacce:nam" s
		//or,,keepData etuisQin listsligth = 	
	acc/;(	af?h=Jc,irfi() !
									if 			}a ) {
!s
		//or	me;jQ		rt.onlt	r" s
		//or, [ 	acc ] )< lengtetuis  a ) {
!keepDataQ&&  obdn,cti),
=ta 1QOptioner
jQ		rtTcleanData(J	acc.geQE			leQsByTaggCas("*/)f)eioner
jQ		rtTcleanData(J[ 	acc ] )
/ 
	 }/
diat ny.is
	obd=er wid tr sOption
aO 	obd=er wid tr noeeI:sCeilds
	obdsOI
	 tl}/{r j}// F}//	}rg
	},
c,ireisr glois  cellasacce:nam"etuisQin listsligth = 	
	acc/;(	af?h=Jc,irfi() !
									if 			}a ed,ReeI:se
		// h	,he Dlido c(u	/ h meeIryuleakrn t ny.is
	accn,cti),
=ta 1QOptionerjQ		rtTcleanData(J	acc.geQE			leQsByTaggCas("*/)f)eioner}//	}rg ed,ReeI:slidy oeerinlow	,ctisgpy=rreilfis  obd.

	CeildQOptioner obdnoeeI:sCeilds
	obdn

	Ceildre;/{r j}// F}//	}rg
	},
c,ireisr glois clonsasacce:nam" dataAndEv		le, deepDataAndEv		leQOptionedataAndEv	idsh  dataAndEv		le ]
					 ? );
	 : dataAndEv		le;/{r deepDataAndEv	idsh  deepDataAndEv		le ]
					 ? dataAndEv		le : deepDataAndEv		le;
(tierred;Jc,irTmap(Jacce:nam (etuis  
			
jQ		rt.clons( jQusm dataAndEv		le, deepDataAndEv		leQO;re
	})eisr glomalv "easacce:nam" ndef=eturn y.isendef=W  |n| jQuer}Optionierred;Jc,ir[0ss&& c,ir[0s=,cti),
=ta 1J?rn rsc,ir[0sninIerHTMLTllback l		/ler}jQ		rtmoy") :rn 
	i				;
(tiagd 	e} ifdrFijec tat talshlrtcutlido justlus/einIerHTML(tia				--cy.is /  ofendef=W  |n)u			//or&&
		noInn		v " catch" ndef=et&& iat;(jQ		rtTsup/  t.leaelowW.fatcpck Qme
!	leaelowW.fatcpck catch" ndef=eet&& iat;!wrapMap[ (	taggCasm( ec" ndef=etme
[""moy"])[1r.toL
})Cas/(	 ]f 			}	}llndef=W  ndef=Tllback l	xv "eTagmoy<$1></$2>"	//{iona trytugpya in listslitth = 	f h=Jc,ir< lengt		 i++					if 			}lla ed,ReeI:se
		// h	,he Dlido c(u	/ h meeIryuleakrn t niy.
(Jc,isfi(n,cti),
=ta 1retuionner
jQ		rtTcleanData(Jc,isfi(.geQE			leQsByTaggCas("*/)f)eionerrsc,ir[isninIerHTMLW  ndef=/gpy=l
	
	 tl}/ gpjQllenf })ingeinIerHTMLJc,if s ec ;cep:nam, })}oGde );lbaaldmethodgpjQ	ckit.deetuionnerc,ir. cell().a f	 j  ndef=eeioner}//	tia				--cy.isejQ		rt.isFcce:nam" ndef=etetuionnec,ir.eet.(acce:nam	iOtionilsligs
	 J=
jQ		rt	 jQusf)eisionils
	 .v "e" ndef= onhegjQusmdi,	s
	 .v "e	))f)eisr
		e;/{var 				--turnnerc,ir. cell().a f	 j  ndef=eeione}//	}rg
	},
c,ireisr glois llback Wshrasacce:nam" ndef= 			}iy.
(Jc,ir[0ss&& c,ir[0s=er wid tr sOp		}iiee that the oected Gdae
		// ht	r w	oeeI:sdist
 tan d e be, l-cnfoy	r w	inserted	}iiee  c,irijec helpionx llbacklowsaeer w ht shr ceild 
		// hrn nay.isejQ		rt.isFcce:nam" ndef=etetuionneerred;Jc,ir.eet.(acce:nam	iOptionilsligs
	 J=
jQ		rt(c,ir), alds=	s
	 .v "e	eeioneils
	 .llback Wshr" ndef= onheg jQusmdi, alds)sOI
	 tl})eioner}//	}rg y.is /  ofendef=r! |n)u			//oJeturnilindef=J=
jQ		rt( ndef=e.detet.()eioner}//	}rnrred;Jc,ir.eet.(acce:nam	Optionilsliun;mW  jQusnn;lSibllow,
lisler 		mW  jQus=er wid tr  ( ioniijQ		rt	 jQusf).oeeI:s() /}diane!==  m;
return niijQ		rt	m;
).be, l-  ndef=eeioner 				--turn niijQ		rt	er wid).a f	 j  ndef=ee/{er}/ 
		)I// F}			--turn nrred;Jc,ir< lengtJ?rn rsc,irntextStral( jQ		rt	jQ		rt.isFcce:nam"ndef=)?	ndef=	Op:	nde/ ),n)llback Wshr", ndef=e :rn 
	ijQueI// F}r
r glomaedetet.asacce:nam" s
		//orf 			}ierred;JjQue.oeeI:s( s
		//or, 
// f)eisr glois domManipasacce:nams adgsmdtstil, c;lbaaldeturnilsli	oes		ts, 

	,bfragE		e,eer w h,	}llndef=W  adgr[0s,	}llscripts ];[]//{rnis usWa	jec'tyclons tr sfragE		esectedlc giatrdc valld,	insWabKutvrny.is
!jQ		rtTsup/  t.c valClonss&& adgeE		ds< lengt=ta 3s&& /  ofendef=W  |n)u			//or&&
	c valldcatch" ndef=)sOptionierred;Jc,ir.eet.(acce:nam	OptioniljQ		rt(c,ir).domManips adgsmdtstil, c;lbaal, 
// f)eisr
		)I// F}E u ny.isJjQ		rt.isFcce:nam"ndef=)sOptionierred;Jc,ir.eet.(acce:nam	iOptionisligs
	 J=
jQ		rt(c,iree/{eradgr[0sJ=
ndef= onhegjQusmdimdtstil ?	s
	 .v "e	Op:n| jQuer}ee/{ers
	 .domManips adgsmdtstil, c;lbaalf)eisr
		)I// F}E u ny.isJc,ir[0ss)tugpya er 		mW  ndef=W&& ndef==er wid tr  ( ipjQllenf wa'rFrin abfragE		e, justlus/ectedltrueeadooftbunldlowsatmewons	}rg y.is jQ		rtTsup/  t.er wid tr Q&&er wi
Q&&er wi
n,cti),
=ta 11r&&er wi
nceild tres< lengt=t=Jc,ir< lengtreturn nii
s		ts ]
{bfragE		e:er wi
Q};
(thn					--c{ionii
s		ts ] jQ		rtTbunldFragE		es adgsmdjQusmdscripts )eioner}//	}rnfragE		er=toes			s.fragE		e /}diany.isJfragE		enceild tres< lengt=ta 1retuionner

	r=tfragE		er=JfragE		en

	CeildI/ yn					--c{ionner

er=JfragE		en

	CeildI/ yn		/}diany.isJ

	retuionnertstil =dtstil &&jQ		rtT,ctigCas	 

	,b"tr"f)eisgpya in listslitth = 	f h=Jc,ir< lengt	f as	I jQxf=f h- 1		 i++					if 			}lla c;lbaal onheg	}lnnertstil ?rn r t;aOroot(c,ir[is, 

	e :rn 
	rrsc,ir[is,	}lliiee that the oected rFido ndtuleak meeIryubyugmadhidt		elyhuopcardlow	}lliiee cnfoho		ggmaltfragE		er(w.ft.rmight E v  a	rat.ed data)ltrueeadoof	}lliiee  })ingeit;ltr
addi:nam, })}oGdeho		ggmaltfragE		e it'ssi
rig Gded as		}lliiee  lef?ltrueeadoofJ

	rbuna})} leijec nnd uprbuinge celiidltrcor(unely	}lliiee  lrdceriatrdsitun:nams (Bug #8070).	}lliiee  FragE		esist
 tan fragE		e jet.Mlmust	alwaysrbuyclonsdt do nu	erlus/e a cliiee  lrdback .	}lliieoes			s.jet.Msti Qme
s l> 1Q&&	 i++ as	I jQxf) ?rn r t;aOjQ		rt.clons( fragE		e, 
// , 
// e :rn 
	irnfragE				}lliiee/{er}/ yn		/}diany.isJscriptr< lengtreturn niijQ		rt.eet.(Jscriptr, endeScriptre;/{r j}// F}//	}rg
	},
c,ireisr 
}OIouioacce:nam root(J	acc, curf 			}=
			ejQ		rtT,ctigCas		acc, "tstil") ?rn r(	acc.geQE			leQsByTaggCas("tbody")[0s(!irn y	acc.a f	 jCeild		acc.awnerDateE		l.ct("diE		E		ey"tbody"))e :rn 
	acc/t}/ ioacce:namyclonsCopyEv		l(Jsrc, de
	retuu is ) { de
	n,cti),
!ta 1Qme
!jQ		rt.E iData(Jsrcretetugit;
			I//		r
rnlsli 	,
mdi,,	,git;aldData ] jQ		rtT_data(Jsrcre,git;curData ] jQ		rtT_data de
	, aldDatare,git;ev		le ] aldData.ev		levu is ) { ev		leQOptioned	act}ocurData.E does;git;curData.ev		le	=stvu isQin list	,
 lr ev		leQOptionin listth = 	f h= ev		le[t	,
 ]< lengt		 i++					if 			}niijQ		rt.ev		lnadd de
	,t	,
 +{ ev		le[t	,
 ][	 i].= ftcpck Q? ".or: ""
	 +{ev		le[t	,
 ][	 i].= ftcpck ,{ev		le[t	,
 ][	 i],{ev		le[t	,
 ][	 i].datare;/{r j}// F}//		r
rnagd mat}oGdeyclonsdtpubllc data it'ssi
a jopyist
 taeho		ggmalis ) { curData.dataf 			}ncurData.data ] jQ		rt.eli;id(st, curData.dataf eisr 
}/ ioacce:namyclonsFixA	rribui}s(Jsrc, de
	retuu sli,cttgCasI
n s usWaido ndtun;edoGo	do idyc,ingr, l itn-E			leQsis ) { de
	n,cti),
!ta 1Qetugit;
			I//		r
rnagd clearA	rribui}s	oeeI:ss tae a	rribui}s,ow.ft.rwereac't )a	e,rnagd bui	also	oeeI:ss tae a	ret.Ev		l{ev		ls,ow.ft.rwer*do* )a	eis ) { de
	nclearA	rribui}sQetugit;de
	nclearA	rribui}s()I//		r
rnagd medgeA	rribui}smdi	ec gira
	,eailh medg}sQbaaleon nfornagd o		ggmal a	rribui}s,ondt nfo{evleQsis ) { de
	nmedgeA	rribui}sQetugit;de
	nmedgeA	rribui}s(JsrcreI//		r
rna,cttgCash  des
n,ctigCas.toL
})Cas/();r
iss useE6-8r)ailoGoyclons ceild widi	side it'sst 
		/		esectedlus/maeedoGdeu		//rietary classid a	rribui} ndef=W(raGderecten nfot	,/maeed a	rribui})oGolid		eafy nfot	,/oofJc gi;idoGo	disbacyis ) { ,cttgCash  |n)it'sstoretugit;de
	noui}rHTMLW  srcnoui}rHTMLIouis					--cy { ,cttgCash  |n)inpudor&&
(srcn	,sh  |n)c valbox"Qme
srcn	,sh  |n)raelo"etetugits useE6-8r)ailt	Go / (sist nfodc valld	u	at/oofJayclonsdtc valboxgits us l raelo buiton. W.
 ,seE6-7r)ailoGoygiv}oGdeycloned 
		// hisOeed adc valld	a f	aianc} ifoGdeudhrefNoC valld ndef=Witc'i	also	setvrny.is
srcnc valldtetugitt;de
	ndhrefNoC valldh  des
nc valld= srcnc valldI// F}r
isnagdseE6-7rgeQJc gfussdt do nnd uprsettlowiGde ndef/oofJayclonsdisnagdsc valbox/raelo buitonoGoyen  cell u			/w(trueeadoofn)in"isna) { de
	nndef=r! |nsrcnndef=tetugitt;de
	nndef=r|nsrcnndef=I// F}r
iss useE6-8r)ailt	Go 
	},
c,} s
		//sdtop:nam	GooGdeudhrefNo s
		//sdiss u	u	ataare syclon	/wtop:namsis					--cy { ,cttgCash  |n)op:namoretugit;de
	ns
		//sdr|nsrcndhrefNoS
		//sd;r
iss useE6-8r)ailt	Go setoGdeudhrefNoVdefi	GooGdeucor(une ndefaare siss uyclon	/wtoGdei 	,
soofrinputefiildsis					--cy { ,cttgCash  |n)inpudorme
,cttgCash  |n)t;mr waoretugit;de
	ndhrefNoVdefi	|nsrcndhrefNoVdefiI//		r
rnagd Ev		l data geQsJre,e wicsdrtrueeadoof jopiid ifoGde ndD
		:rnagd geQs jopiid	Go:rn;de

noeeI:sA	rribui}( jQ		rt.elD
		: OIou}////jQ		rtTbunldFragE		e	|nacce:nams adgsm
,cttsmdscriptsretuu sli fragE		e, jet.Msti , jet.Moes		ts,heat,rnr

er= adgs[= e]//{ioM n,ctisemaylc giatrdeiGdei ec ; );kitheateE		e it'sst,maeed a jQ		rtlc 		ee:nams l c gi;e it'sst.iss usef,ctis[0s(c giatrura ndeid it'sst	Gooassigm	Gooeatis ) { ,cttsridh,ct
r[0ss)tugpyaeat ];,ctir[0s.awnerDateE		l	me
,ctir[0sI//		r
rnagd Enhe oected a{ a	rr it'sstone tc't	trcor(unell u	
		ltr
auraheateE		e it'sstrnagexC t
et do Fnre, x se}m	Gooallf  jQusfGoooccurt do )illJc,if  ;cep:namrnagexFixes #8950is ) {
	doc.ct("diDateE		lFragE		es)tugpyaeat ];eateE		eI//		r
rna nodilh jet.Ml"sby l" (1/2 KB) HTML u			/wsectedliaboassociatidt shr t.Mlerin;eateE		trnagexClon	/wtop:nams los/s
c,} s
		//sd	u	atamdsoreac't jet.Mlc,}miss useE 6one tc'txllt  iQare seyou pute<it'sst>s l <embsd> 
		/		esein abfragE		en =ll
AlsomsWabKutone t	ndt clons 'c valld' a	rribui}seonyclons tr mdsoreac't jet.Mn =ll
Lasell,seE6,7,8 )ill	ndt cor(unell reuss jet.MdsfragE		esectedl
})e ct("dsdist
 unknawn 
		/s #10501is ) {
adgs< lengt=ta 1r&& /  ofe

er= |n)u			//or&&e

e< lengt< 512r&&eeat ]=];eateE		et&& iat
s
nc arA	(0)r= |n)<or&&
		nojet.McatchsJ

	ret&& iat(jQ		rtTsup/  t.c valClon Qme
!	c valldcatchsJ

	reet&& iat(jQ		rtTsup/  t.v "e5Clon Qme
!	noshimjet.McatchsJ

	reef 			}	}ljet.Msti Q=r
// I}	}ljet.M
s		ts ] jQ		rtTfragE		es[J

	rsI//	 ) {
jet.M
s		tst&&
jet.M
s		tst!ta 1Qetug}rnfragE		er=
jet.M
s		tsI// F}r
	}//	s ) {
	fragE		eQetug}nfragE		er=
doc.ct("diDateE		lFragE		e()eionejQ		rtTcleans adgs,heat, fragE		e,dscripts )eion}//	s ) { jet.Msti Qetug}njQ		rtTfragE		es[J

	rsr=
jet.M
s		ts ? fragE		e : 1v/ D

isO
	},e{bfragE		e: fragE		e, jet.Msti : jet.Msti Q};
eIE u jQ		rtTfragE		le	=stvu u jQ		rt.eet.(		o a f	 jTo: "a f	 j"g	o e(uf	 jTo: "e(uf	 j"g	o insertBe, le: "be, le"g	o insertAed g:e"ded g",is llback A		:n)llback Wshr"
},eacce:nam	t= f},eo		ggmalf 			}jQ		rt.fn=t= fae]r=tacce:nam",s
		//orreturn slirre ];[]m	}l insertJ=
jQ		rt( s
		//orf ddBoaOer 		mW  jQus< lengt=ta 1r&& c,ir[0s=er wid tr Iouis	y.iser wi
Q&&er wi
n,cti),
=ta 11r&&er wi
nceild tres< lengt=t=J1r&&insert< lengt=ta 1retui}l insert[eo		ggmalf]sJc,ir[0ss)eisrierred;Jc,ir;/{var 				--turna in listslitth = 	f h=insert< lengt		 i++					if 			}nislig	acce	={ei>	/p?Jc,ir.clont(
// ) : jQusf).geQ();ioniijQ		rt	 insert[iss)[eo		ggmalf]sg	acce	);ionii
	


	<c gckisg	acce	);ioniD

isOierred;Jc,irntextStral(	oet, = f},einsert<s
		//orf I/ y		ret ;
}OIouioacce:nam geQA			  obdreturo y.is /  ofe	acc.geQE			leQsByTaggCas ! |n)| jQuer}oJ 			}ierred;J	acc.geQE			leQsByTaggCas(n)*orOIouis					--cy.is /  ofe	accnq		rtS
		//orA		 ! |n)| jQuer}oJ 			}ierred;J	acc.q		rtS
		//orA		(n)*orOIouis					--			}ierred;;[]eisr 
}/ ioll
Ussdrtr clean,eaixes GdeudhrefNoC valldu		//ertyioacce:nameaixDhrefNoC valld	  obdreturo y.is  obdn	,sh  |n)c valbox"Qme
 obdn	,sh  |n)raelooJ 			}ie obdndhrefNoC valldh 
 obdnc valldeisr 
}/ gexFindsoallrinputDlido cass/s
c,}m	GoeaixDhrefNoC valldioacce:nameaindInputDs  obdretuu sli,cttgCash is 	accn,ctigCasQme ""
	.toL
})Cas/();r
	y { ,cttgCash  |n)inpudoJ 			}ieaixDhrefNoC valld	  obdre;rnagexSki/Jscriptr, geQtoGdei ceild wiis					--cy { ,cttgCas ! |n)scriptor&& /  ofe	acc.geQE			leQsByTaggCas ! |n)| jQuer}oJ 			}iejQ		rtTgllb(J	acc.geQE			leQsByTaggCas()inpudo),eaixDhrefNoC valldf eisr 
}/ ioed teriv}o Ft
: v tp://www.iecss.c m/shimprove/jivascript/shimprove.1-0-1.jsioacce:nameshimClons tr s  obdrettisOsli,div = eateE		e.ct("diE			leQ( "div"re;	o s "eFragE		t.a f	 jCeild	,div )y////	divninIerHTMLidJ	acc.oui}rHTMLIisO
	},edivn

	CeildI/ }E u jQ		rt.eli;id(		s clonsasacce:nam"J	accm dataAndEv		le, deepDataAndEv		leQOturn slisrcE			leQs,gitt;de
	E			leQs,gitt;i,gitts useE<=8one t	ndt 		//erll clons derat.ed, unknawn 
			leQ	,ctisgpy= clonsidJjQ		rtTsup/  t.v "e5Clon Qme
!	noshimjet.McatchsJ)<or+ 	accn,ctigCasf) ?rn r t obdnclons tr s 
// e :rn 
	ishimClons tr s  obdreyou	}ie!== h(!jQ		rtTsup/  tn,cClonsEv		lQme
!jQ		rtTsup/  tn,cClonsC valldet&& iat r(	acc.,cti),
=ta 1Qme
 obdn,cti),
=ta 11eridh!jQ		rt.isXMLDat(	accef 		gitts useE jopiis ev		leQbo {Jvia a	ret.Ev		Qare s })ingeclons tr .gitts usCalling deret.Ev		QaonoGdeyclone )ill	also	oeeI:s nfo{evleQsgitts uist
 taeho		ggmal. In ord	r	GoegeQliao {djQusmdwe })}os
egitts uu		//rietary methods Goeclear nfo{evleQs. TE dkt	Go	MooToolsgitts uiguys )or jQusfhotness.
isOieclonsFixA	rribui}s"J	accm clonsf)eisgpya ll
U)ingeSizze sandaeis ctazl ulf mdsodwe })}ogeQE			leQsByTaggCa  trueeadgpya srcE			leQe	= geQA			  obdre;gitt;de
	E			leQe	= geQA			 clonsf)eisgpya llsWairdrti}rn:namrbuna})}seE )ill	llback  nfo{ lengtu		//ertyipya llt shr ec ;			leQcy eyou areyclonlowiGde bodylido ons ofoGdeipya ll 
		/		eseonoGdeypag saaurat= faeor idoofn) lengt"
Qin listth = 		srcE			leQrfi(v	++iretudiatagd Enhe oectedoGdeue Dtlon:namntr sit	ndt 				;xFixes #9587diata) { de
	E			leQrfi(retudiataeclonsFixA	rribui}s"JsrcE			leQrfi(, de
	E			leQrfi(rOI
	 tl}/{r j}// F}//	}rggd Copy nfo{evleQsist
 taeho		ggmal	GooGdeycloneisna) { dataAndEv		leQOturnaeclonsCopyEv		l"J	accm clonsf)eisgpyna) { deepDataAndEv		leQOturn ya srcE			leQe	= geQA			  obdre;gitt;;de
	E			leQe	= geQA			 clonsf)eisgpya in listth = 		srcE			leQrfi(v	++iretudiataeclonsCopyEv		l"JsrcE			leQrfi(, de
	E			leQrfi(rOI
	 tl}/{r j}// F}//	}rgsrcE			leQe	= de
	E			leQe	= 				;
(tiagd R
	},
c,} cloed seQ	}ierred; cloeeisr glois cleai:eacce:nam	  obds,(c gi;
, fragE		e,dscripts Oturn sli(c valScript),
;
(tiac gi;t	=ec gi;l	me
eateE		e;
(tiagd !c gi;l.ct("diE			leQr)ailsrinontt shr ec ;rr lsbuisrred;s /  ofe'it'sst'rn y.ise/  ofec gi;l.ct("diE			leQr= |n)| jQuer}oJ 			}ieac gi;t	=ec gi;l.awnerDateE		l	meec gi;l[0ss&& c gi;l[0s.awnerDateE		l	me
eateE		eI/ y		rern slirre ];[]mdjI/ isQin listsligth = 	
	acc/;(	af?h=J	af?rfi() !
									if 			}ny.ise/  of
	acc = |n)numbsroJ 			ia 		acc+|n)";ioniD

isOi
y.is
! obdretudiaieac giinue;ioniD

isOrggd Conhidt v "e u			/w(trto d e ,ctisgpyny.ise/  of
	acc = |n)u			//oJeturn y=
y.is
!	v " catch	  obdreQOptioner
	acc=ec gi;l.ct("diT;d tr 	  obdeeioner 				--turn niiagexFix "XHTML"-style tags(troallrbif s (sioner
	acc=J	accTllback l	xv "eTagmoy<$1></$2>"	//{iona a ed Trim w.fatcpck ,toGdeiwi--ti jQxOf wac't ).koas ; 	//sdionilsli tagh is 	taggCasm( ec"J	accetme
[""moy"] )[1r.toL
})Cas/(	,	}lliiewrapJ=
wrapMap[ tagh]tme
wrapMap._dhrefNo,	}lliiedectE= wrap[0s,	}lliiediv =ec gi;l.ct("diE			leQ("div")y////		 callba f	 j wra f	ig	acc;idoGo unknawn 
			leQ	s "e
eatbfragE		en = y=
y.isec gi;l ]=];eateE		eQOptionera ll
U)e tan fragE		e wa':s nht("dy ct("dsdisor jQusheateE		ern y=i	 s "eFragE		t.a f	 jCeild	,div )y//y=i						--ptionera ll
U)e abfragE		e ct("dsdt shr t.MlawnerheateE		ern y=i	 ct("di	 "eFragE		esec gi;l ).a f	 jCeild	,div )y//y=i			////		 callbGooGo v "elido baal, 
e s peelooff ;lra wra f (sioner
divninIerHTMLid wra [1rr+ 	accr+ wra [2]y////		 callbMI:s	GooGdeyright dectE//		y=rreilfis dectE--QOptioneliiediv =edivnlas	Ceildy//y=i			////		 c ed,ReeI:sont'urautoinserted <tbody>ist
 tstin fragE		esionerny.is
!jQ		rtTsup/  t.tbodyf 			}	}llieagd 				// waurat<tstil>, *may* E v  spurious <tbody>	}nilslisaauBody= rtbodycatch		acc	,	}lliie	tbody= tag = |n)tstilor&&
	aauBody ?rn r eliiediv.

	CeildQ&& div.

	Ceild=ceild tres :	}	}llieaeagd 				// wauratbarey<tEead>s l <tfooe>	}llieaeawra [1r = |n)<tstil>or&&
	aauBody ?rn rr eliiediv=ceild tres :	n rr eliie[]//{rnisya in listj= tbodyc length- 1		j > =  ; --jQOptionelirny.isejQ		rtT,ctigCas	 tbody[	j ]md"tbody" eridh!tbody[	j ]nceild tres< lengtQOptionelirn	tbody[	j ]=er wid tr noeeI:sCeilds
tbody[	j ] )y//y=i		 j}// F		 j}// F				////		 ts useE jomelet ehekills leaelow w.fatcpckaare syinIerHTMLiislus/e a erny.is
!jQ		rtTsup/  t.leaelowW.fatcpck Q&&
	leaelowW.fatcpck catch	  obdreQOptioneliiediv.insertBe, le(ec gi;l.ct("diT;d tr 	
	leaelowW.fatcpcksm( ec		acc	[0ss), div.

	Ceild )y//y=i			////		r
	acc=Jdiv=ceild trese/{er}/ yn		/}di c ed,ReseQsudhrefNoC valldu, l idy raelos iddtc valboxesdi c ed,abo doGo buya f	 jid	Go tan d erinontt6/7 (#8060)gpy slilu	I//rny.is
!jQ		rtTsup/  t.a f	 jC vallduetudiat ny.is  obd[0ss&& /  ofe(lu	=J	acc< lengt) = |n)numbsroJ 			iaya in listj= 0		ji++ le		j	if 			}jer
aindInputDs  obd[j] )y//y=i			/oner 				--turn ni
aindInputDs  obdrOI
	 tl}/{r j}//n t ny.is
	accn,cti),
 			}jeg
tntexts  obdrOI
er 				--t		}jeg
ts|njQ		rtTmedge" oet,  obdrOI
er 	// F}E u ny.isbfragE		e  			}jec valScript),
 =eacce:nam	  obdretudiaOierred;J! obdn	,shme
	script), catch	  obdn	,shOI
er 	;
Qin listth = 		reefi(				if 			}nny.isJscriptr &&jQ		rtT,ctigCas		reefi(,n)scriptoreridh(!reefi(n	,shme
	eefi(n	,s.toL
})Cas/(	h  |n)t;m/jivascript"etetugitsllscriptsntexts
	eefi(ner wid tr  ?
	eefi(ner wid tr noeeI:sCeilds
	eefi(e :
	eefi(e//{ionr
				--cuion

y.is
rrefi(n,cti),
=ta 1retuionilslisjsTags ]ejQ		rtTgllbs
rrefi(.geQE			leQsByTaggCas(n)scriptore,(c valScript),
e//{ionrna 
	+/ );k .a fuy" oet, [i + 1, 0]<c gckissjsTags ) )y//y=i			rn ni
aragE		t.a f	 jCeilds
	eefi(sOI
	 tl}/{r j}// F}//	}rg
	},

	eisr glomalcleanData:eacce:nam	  obds Oturn sli data, id,	}lljet.M ]ejQ		rtTjet.M,	}lls 	/ia h JjQ		rt.ev		lns 	/ia ,	}ned	act}ElD
		:idJjQ		rtTsup/  t.d	act}ElD
		:I/ isQin listsligth = 	
	acc/;(	af?h=J	af?rfi() !
									if 			}ny.ise	accn,ctigCas &&jQ		rtT,cData[	accn,ctigCas.toL
})Cas/(	]retudiaieac giinue;ioniD

isOrgidh 
 obd[ jQ		rt.elD
		: ]	/ iona ) {eiduetudiat ndatar=
jet.M[eid ]	/ iona a) { dataQ&& data.ev		leuetudiat nin listslit	,
 lr data.ev		leuetudiat a a) { s 	/ia [t	,
 ]uetudiat aniijQ		rt.ev		lnoeeI:e(J	acc, j,
e//{ionra a ed TQuesuetalshlrtcut	Gooavoid jQ		rt.ev		lnoeeI:e'urI:erheadgpyanr
				--tudiat aniijQ		rtnoeeI:eEv		l"J	acc, j,
, data.E doese/// F		 j}// F				////		 ts usN			 tan d eJre,e wics	Gooavoid IE6/7/8uleak (#7054)ion

y.is data.E doesetudiat anidata.E does.	acc	= 				;
y=l
	
	 tl}/ gp

y.is d	act}ElD
		:ietudiat and	act}
 obd[ jQ		rt.elD
		: ]	/ ionr
				--ty.ise	accnoeeI:sA	rribui}QOptioner
	accnoeeI:sA	rribui}( jQ		rt.elD
		: OIou	 tl}/ gp and	act}
jet.M[eid ]	/{r j}// F}isr 
}OIouioacce:nam endeScriptei,  obdreturo y.is  obdnsrcJ 			}iejQ		rtTajax(tionerurl:  obdnsrcddBoaOnsync: );
	ddBanidata),
:n)scriptore
	})eisr				--tudiiejQ		rtTglobalEnde(is  obdni;l	me  obdni;lC gi;il	me  obdninIerHTMLime ""
	Tllback lh	cleanScript,n)/*$0*/"
	 )eion}//	s y.is
	obd=er wid tr sOptioO 	obd=er wid tr noeeI:sCeilds
	obdsOI
	 
}/ io/ i isvar ralphar=
/alpha\([^)]*\)/i,ioa	opckdWer=
/opckdWe=([^)]*)/,isrgeeaixldu, l IE9mdse/ #8346ioa	u f	ig=
/([A-Z]|^ds)/g,ioa	numpx= /^-?\d+to	ex)?$/i,ioa	num= /^-?\d/,isrr(ulNum= /^([\-+])=([\-+.\de]+)/glomalcssShow ]
{bposi:nam:e"dbsolui}", nisibi dWe:e"hidd		", disbacy: "block" },malcssWidtE= [ "Left"moyRight"e],malcssHeight= [ "Top"moyBoitom"e],malcurCSSglomalgeQComeui}dStyle,malcur widStyleIE u jQ		rt.fn.css= acce:nam	t= f},endef=tetugnagexSettlowi'| jQuer}'suetalno-op	s y.is adgeE		ds< lengt=ta 2r&&endef=W  |n| jQuer}Optiong
	},
c,ireisr /	}=
			ejQ		rtTaccesu(Jc,irdt= f},endef=, 
// ,lacce:nam	  obddt= f},endef=Optiong
	},endef=r! |n| jQuer}s?dBoaOjQ		rt.style	  obddt= f},endef=Os:dBoaOjQ		rt.css	  obddt= f=OeisO}OIou}IE u jQ		rt.eli;id(		aallbaddrtr styleu		//ertyfhooks )orrI:errielow GdeudhrefNornagd beE viorrIf gettlow iddtsettlow i styleu		//ertymalcssHooks:ptiongopckdWe:ptionglgeQasacce:nam"J	accm comeui}df 			}nny.is comeui}df 			}nnis usWa	shluld	alwaysrgeQ i numbsr baalist
 opckdWe	}nnisslirre ];curCSS"J	accm "opckdWe"m "opckdWe"e/// F		 
	},

	h  |n)"Q? "1" :
	ee//{ionr
				--cuion
ierred;J	acc.style.opckdWeI
	 tl}/{r j}// F}r
r glomaeed,Exclude tan follf low cssu		//ertiis	GooaddrpxmalcssNumbsr:ptiong)onllOpckdWe": 
// ,iong)ooidWeight": 
// ,iong)ler}Height": 
// ,iong)opckdWe": 
// ,iong)orphans": 
// ,iong)wijows": 
// ,iong)zI jQx": 
// ,iong)zoom": 
// r
r glomaellbaddrtr 		//ertiisareos/t= f=seyou wi-h	Goeaix be, l-maellbsettlow orrgettlowiGde ndef/malcssP	//s:ptionell it by deffloat cssu		//ertyiong)float": jQ		rtTsup/  t.cssFloat ? "cssFloator: "styleFloator
r glomaellbGet iddtsetiGde styleu		//ertyfam a d eJ tr maestyleasacce:nam"J	accmt= f},endef=, ;lra etugits usDac't set styleseonoG;l iddtcom	leQ	,ctisgpy=y.is
! obdQme
 obdn,cti),
=ta 3Qme
 obdn,cti),
=ta 8Qme
!	acc.stylesOptionierred;I/ y		rerniee that the oected rF'rF ).klowt shroGdeyrightt= f}rn slirre, j,
, origgCas ]ejQ		rtTjCaslCas/(t= f}f ddBoaOstyle ]e	acc.style,fhooks ]ejQ		rtTcssHooks[ origgCas ]	/ ionrnCas ]ejQ		rtTcssP	//s[ origgCas ]Qme
origgCas;
(tiagd C valty. rF'rFtsettlow iendef=rn y.isendef= ! |n| jQuer}Optionie	,sh  /  ofendef=eisgpya llsconhidt (ulativ} numbsr u			/wse(+= orr-=)oGo (ulativ} numbsrs. #7345gpyny.ise/  r= |n)u			//or&&e(rre ];r(ulNumm( ec" ndef=e)Jeturnilindef=J=ise+s
	ee[1rr+ 1er* +	ee[2]
	 +{er seFloat( jQ		rt.css	  obddt= f=Oe/// F	agexFixes bug #9237diata/  r|n)numbsro;ioniD

isOrge that the oected NaN idd 				 ndef=t	r wc't set. 	e}: #7116ioa y.isendef=W   				fmee/   = |n)numbsror&&isNaN" ndef=etetuionneerred;;ioniD

isOrge tIf i numbsr wau cass/drtr,oaddr'px'	Go tan (;cep: )orrceriatrdCSS 		//ertiis)ioa y.ise/   = |n)numbsror&dh!jQ		rt.cssNumbsr[ origgCas ]Qeturnilindef=+|n)px";ioniD

isOrge tIf ifhook wau 		/vid d,lus/ectedlndef ,toGdeiwi-- justtsetiGde s 	/ifild ndef=//rny.is
!hooksQme
!("set"rtr hooksetme
(ndef=W  hooks.set	  obdd ndef=e)J! |n| jQuer}Optionnis usWra fid	Go c(u	/ h IEist
 tarf low ;rr lsare sy'inndeid' ndef=t	r w 		/vid d// F	agexFixes bug #5509// F	 trytugpyaoaOstyle=t= fae]r= ndef=/gpyjQ	ckit.deetu}/{r j}//n 
				--cuisOrge tIf ifhook wau 		/vid d getiGde itn-comeui}d ndef=st
 taer=//rny.is hooksr&dh"get"rtr hooksr&&e(rre ] hooks.get	  obdd );
=, ;lra e)J! |n| jQuer}Optionnis
	},

	;ioniD

isOrge tOGdeiwi-- justtgetiGde ndef=st
iGde style it'sstrnnis
	},
style=t= fae]I// F}r
r glomaecssasacce:nam"J	accmt= f},e;lra etugn slirre,fhooks;rerniee that the oected rF'rF ).klowt shroGdeyrightt= f}rn nCas ]ejQ		rtTjCaslCas/(t= f}f I// Fhooks ]ejQ		rtTcssHooks[t= fae]I//nrnCas ]ejQ		rtTcssP	//s[ nCas ]Qme nCas;rerniee tcssFloatun;edetals 	/ia htt("d	leQi}ie!==  mCash  |n"cssFloato etugn rnCas ]e)float"I/ y		rernrge tIf ifhook wau 		/vid d getiGde comeui}d ndef=st
 taer=//ny.is hooksr&dh"get"rtr hooksr&&e(rre ] hooks.get	  obdd 
//=, ;lra e)J! |n| jQuer}Optionni
	},

	;rerniee tOGdeiwi-=, if ifway	Go getiGde comeui}d ndef= ;ists,lus/ected	tia				--cy.is;curCSSOptionni
	},;curCSS	  obddt= f=OI// F}r
r glomaellba method )orrquickll uwa f	/w(tr/o ddCSS 		//ertiis	Go geticor(une onhcula:namsis	uwa asacce:nam"J	accmtop:nams, c;lbaaldeturnilsli	ald	=stvu u c ed,ReeembsriGde ald ndef=t, idd insertiGdetmewonssisQin listslignCa  trtop:namsOptionniald=t= fae]r=e	acc.style=t= fae]Iionni	acc.style=t= fae]r=top:nams=t= fae]Ii y		rernrgc;lbaal onhes
	obdsOI u c ed,RehidtiGde ald ndef=sisQin lisgnCa  trtop:namsOptionni	acc.style=t= fae]r=told=t= fae]Ii y		reD

}OIouisll
DEPRECATED,
U)e jQ		rt.css	) trueeadgpjQ		rt.curCSS ]ejQ		rtTcssvu u jQ		rt.eet.(["height", )wijgt"],lacce:nam	 idt= f=OptionjQ		rtTcssHooks[t= fae]	=st//glgeQasacce:nam"J	accm comeui}d,e;lra etugn ilsli	ndevu u nny.is comeui}df 			}nniy.is
	obd=offsetWidtEJ! |n0f 			}nnni
	},;getWH"J	accmt= f},e;lraeeioner 				--turn niijQ		rt.uwa "J	accmtcssShow,lacce:nam	etuionilsl h ;getWH"J	accmt= f},e;lraeeioner 	})eisr tl}/{rn
a 
				ndevu{r j}// F},/{rn
aseQasacce:nam"J	accmendef=Optu nny.is 	numpxcatch" ndef=)sOptioliiee  lgit etmegativ} wijgt idd height ndef=s #1599rnilindef=J={er seFloah" ndef=)	/ iona a) {" ndef=>|n0f 			}nnni
	},;ndef=+n)px";ionitl}/{rn
a 				--turnnnni
	},;ndef=vu{r j}// 		ret ;
}OIourny.is
!jQ		rtTsup/  t.opckdWeOptionjQ		rtTcssHooks.opckdWe	=st//glgeQasacce:nam"J	accm comeui}df 		gitts useElus/sionlt	rs )orropckdWeionni
	},
opckdWecatch" (comeui}dQ&&  obd.cur widStyle ?  obd.cur widStyle.onlt	r :  obdnstyle.onlt	r)ime ""f) ?rn r t({er seFloah"Regals.$1ret/ 100f 	+ "" :	n rr comeui}dQ? "1" :n)";// F},/{rn
aseQasacce:nam"J	accmendef=Optu nnsli	style ]e	acc.style,	n rr cur widStyle ]e	acc.cur widStyle,	n rr opckdWe	=sjQ		rt.isNumeric" ndef=eQ? "alpha(opckdWe=or+ ndef=* 100r+ ")" :n)",	n rr onlt	r	=scur widStyle && cur widStyle.onlt	rQme
style.onlt	rQmen)";//gitts useEsaaurtao tilt shroopckdWe	y.iutone t	ndt E v  acyo dgitts usForc  iQabyrsettlowiGde zoom lehildBoaOstyle.zoom a 1;//gitts u	y.rsettlowoopckdWy	Go 1,t do ndtoGdeiionlt	rs ;ist - a	r cel	Go	oeeI:s onlt	rQa	rribui} #6652git a) {" ndef=>|n1 &&jQ		rtTrrim( onlt	rTllback lh	alpha, ""f) )h  |n)"Q 			}	}llagexSettlow
style.onlt	r	Go 				, ""fdh" "
stnll le v  "onlt	ra"rtriGde cssT;dioliiee  lf "onlt	ra"rts c(us/ h edli		,eclear),
ts disstildmdwe )a	t	GooavoidJc,irioliiee 
stylenoeeI:sA	rribui}Qts eEsdilh,sbuissooaper 		elyQts c,irijtr spaGd...	}llistylenoeeI:sA	rribui}( "onlt	rorOIouioliiee  lf taer= taer sit	nd onlt	rQstyleoapelisdrtr a cssurulemdwe r 	reaceiona a) {"scur widStyle && !cur widStyle.onlt	rf 			}nnni
	},e/{er}/ yn		/}di c ed,oGdeiwi-=, settmewonlt	r ndef=sisQlistylenonlt	r	=h	alphacatch" onlt	rf) ?rn r tonlt	rTllback lh	alpha, opckdWeOp:	n rr onlt	r	+h" "
+ opckdWeIi y		reD
I/ }E u jQ		rt(acce:nam	Optio ed TQuefhook jecndt buyadd d,u	ea  d eJt("dyrbuna})}iGde sup/  t atchio ed )or itsit	ndturun,u	ea  ded g d eJt("dyio y.is
!jQ		rtTsup/  t.(ulistilMarggmRightf 			}njQ		rtTcssHooks.marggmRightf=ptionglgeQasacce:nam"J	accm comeui}df 			}nned WabKutoBug 13343 - geQComeui}dStylesrred;s wrong ndef= )or marggm-right	}nned W.kliao {dbyrr c/  arilyrsettlowi
			leQ disbacy	Go 	/ler}-block	}nislig
	;reniijQ		rt.uwa "J	accmt{ "disbacy":n)	/ler}-block" },lacce:nam	etuionnny.is comeui}df 			}nnnnnrre ];curCSS"J	accm "marggm-right", )marggmRight" )y//y=i						--ptionennnnrre ];	acc.style.marggmRighty//y=i			
	 tl})eionnis
	},

	;ioniD

r 	;
Q}
}OIourny.isheateE			ndhrefNoView &&heateE			ndhrefNoView.geQComeui}dStyles 			}geQComeui}dStyles=sacce:nam"J	accmt= f} etugn slirre,fdhrefNoViewm comeui}dStyle	/ ionrnCas ]t= f}Tllback lh	u f	i, )-$1"
	.toL
})Cas/();r
	}ie!== h(dhrefNoView ]t	acc.awnerDateE			ndhrefNoViewet&& iat r(comeui}dStyles=sdhrefNoView.geQComeui}dStyle"J	accm 				e)Jeturninnrre ];comeui}dStyle.geQP	//ertyVdef/(t= f}f I// ie!== 

	h  |n)or&dh!jQ		rt.c giatru(t	acc.awnerDateE			ndateE		QE			leQ,  obdreQOptionelirre ];jQ		rt.style	  obddt= f}f I//r j}// F}//	}rg
	},

	ereD
I/ }E rny.isheateE			ndateE		QE			leQ.cur widStyles 			}cur widStyles=sacce:nam"J	accmt= f} etugn slilefQ, rsLefQ, cceomeui}d,rninnrre ]e	acc.cur widStyleQ&&  obd.cur widStyle=t= fae]ddBoaOstyle ]e	acc.styleI u c ed,AvoidJsettlowirre	Go  cell u			/w(aer=//iee 
sorwereac't dhrefNo	Gorauto//ie!== 

	h  | 				&& styleQ&& (cceomeui}d ]estyle=t= fae])Jeturninnrre ];cceomeui}dI/ y		rernrge tFt
iGde awesofaehaaldbyrDean Edwardsrnrge  v tp://erik.eeenn;t/a	c iv}s/2007/07/27/18.54.15/#com	leQ-102291rernrgelenf wa'rF ndtheeallowt shroa

gullipixel numbsrrnrggd bui	a numbsrectedsaaura wairo nndlowmdwe n;edoGo	conhidt io	Gopixelsgpy=y.is
!	numpxcatch" rrereridh	numcatch" rrerer 			}	}lled,ReeembsriGdeho		ggmal ndef=sisQlilefQ ]estyle.lef	;ioniDrsLefQ ]e	acc.rune meStyleQ&&  acc.rune meStyle.lef	;	}	}lled,Pui	iniGdetmew ndef=s	GoegeQli comeui}d ndef= o d// ie!== 
rsLefQQOptioneli acc.rune meStyle.lefe ]e	acc.cur widStyle.lef	;ioniD}dBoaOstyle.lefe ] mCash  |n)ooidSize"Q? "1em" := 

	hmen0s)eisrierrQ ]estyle.pixelLefQ+n)px";ioisrc ed,RehidtiGde chang}d ndef=sdBoaOstyle.lefe ] lef	;// ie!== 
rsLefQQOptioneli acc.rune meStyle.lefe ]ersLefQI//r j}// F}//	}r 
	},

	h  |n)"Q? "auto" :

	ereD
I/ }E rncurCSS ] geQComeui}dStylesmencur widStyleIE u acce:na;getWH"J	accmt= f},e;lrar 			}	}agd 		arht shr offsetu		//ertyiolsli	nde ] mCash  | )wijgt"Q?
	obd=offsetWidtEJ:
	obd=offsetHeightddBoaw.ft. ] mCash  | )wijgt"Q?
cssWidtEJ:
cssHeightddBoath = ddBoalu	=Jw.ft.< lengtvu is ) {	nde >n0f 			}n) {e;lra ! |n)bord	r"QOptionin list		 i++ le				if 			}nny.isJ!;lrar 			}nilsl h-={er seFloat( jQ		rt.css	  obddn)padd	//or+Jw.ft.[	 i]rer hmen0e/{er}/ ynn) {e;lra   | )marggm"r 			}nilsl h+={er seFloat( jQ		rt.css	  obdde;lrar+Jw.ft.[	 i]rer hmen0e/{=i						--			}nilsl h-={er seFloat( jQ		rt.css	  obddn)bord	r"r+Jw.ft.[	 i]r+n)WidtE"rer hmen0e/{=i			//r j}// F}//	}r 
	},
sl +n)px";ioF}//	}ge tFallrbaal	Go comeui}d 
e s cceomeui}d cssu) {necesuaryiolnde ] curCSS	  obddt= f=dt= f}f I/s ) {	ndei++0hme	ndei | 				 etugn sllr=e	acc.style=t= fae]hmen0;ioF}//s usNt by defn)",rauto,lido c(uer = )ore;lraiolndeJ={er seFloah" nder hmen0e/{maellbaddrpadd	//, bord	r, marggm/s ) {	;lrar 			}nin list		 i++ le				if 			}lsl h+={er seFloat( jQ		rt.css	  obdde)padd	//or+Jw.ft.[	 i]rer hmen0e/{er) {e;lra ! |e)padd	//of 			}ilsl h+={er seFloat( jQ		rt.css	  obdde)bord	r"r+Jw.ft.[	 i]r+n)WidtE"rer hmen0e/{=i	}//nn) {e;lra   | )marggm"r 			}nisl h+={er seFloat( jQ		rt.css	  obdde;lrar+Jw.ft.[	 i]rer hmen0e/{=i	}// F}//		r
rn 
	},
sl +n)px";io}E rny.ishjQ		rt.elDr &&jQ		rt.elDrnonlt	rsOptionjQ		rt.elDrnonlt	rs.hidd		 =eacce:nam	  obdretuditsli widtE=
	obd=offsetWidtEddBoaOheight =
	obd=offsetHeight;
(tierred;J( widtE= |n0f&&height= |n0fetme
(!jQ		rtTsup/  t.(ulistilHidd		Offsetsr&&e((	acc.styler&&;	acc.style.disbacyetme jQ		rt.css	  obdde)disbacy"r ) = |n)nace")ereD
I/ ionjQ		rt.elDrnonlt	rs.nisibl
 =eacce:nam	  obdretudiierred;J!jQ		rt.elDrnonlt	rs.hidd	m	  obdr)ereD
I
}/ io/ i isvar r20= /%20/g,ioa	braalrQ ]e/\[\]$/,isrrCRLF ]e/\r?\n/g,ioa	aauh ]e/#.*$/,isrrhead	rs= /^(.*?):[ \t]*([^\r\n]*)\r?$/m/,  useE le v s ec \r charaat	rQa	 EOLisrrinpud= /^(?:c 	or|d"di|d"die mi|d"die mi-local|eeril|hidd	m|moidh|numbsr|cassword|rang}|sea	c |t e|t xt|e mi|url|week)$/i,ioa us#7653, #8125, #8152: localu		/toc 	 deree:namisrrlocalP	/toc 	= /^(?:abo d|ape|ape\-st  ag}|.+\-eli;isnam|onle|(us|widget):$/,isrrnoC gi;il= /^(?:GET|HEAD)$/,isrrp	/toc 	= /^\/\//,isrrq		rt ]e/\?/,isr	script ]e/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,ioa	s
		//T;mr wa= /^(?:s
		/t|e;mr wa)/i,ioa	cpckssAjax ]e/\s+/,isr	tsg=
/([?&])_=[^&]*/,isr	url= /^([\w\+\.\-]+:)(?:\/\/([^\/?#:]*)(?::(\d+))?)?/,isioa usKeep
a jopyiofiGde ald loaddmethodgpj_load= jQ		rt.fn.load,isioa * Preonlt	rsioa* 1) Tfoy	r w	})}ful	Go 	/taoduc}ocust m data),
se(se/ ajax/jsonp.jsu, l ide;amele)ioa* 2) Tfose r 	rcalild:ioa*    - BEFOREoasklowu, l i trans/  tioa*    - AFTER{er am seriy dea:name(s.datasueta u			/w	y.rs.p	/cesuData is 
//e)ioa* 3),keyQts c,e data),
ioa* 4) c,e	ckit.allrsymb 	)*o	ckmrbulus/e a * 5) ( ecu:nam )ill	s	arht shr trans/  t data),
lido THEN c giinue jowm	Goo)*o	y. n;ed/e a */	o e(eonlt	rs	=st,isioa * Trans/  ts bindlowsioa* 1) keyQts c,e data),
ioa* 2) c,e	ckit.allrsymb 	)*o	ckmrbulus/e a * 3),s
		/:nam )ill	s	arht shr trans/  t data),
lido THEN go	Goo)*o	y. n;ed/e a */	o trans/  ts	=st,isioa usDateE			 loca:namisrajaxLoca:nam,isioa usDateE			 loca:nam,s
gE		esisrajaxLocPa ts,isio ed,AvoidJcom	leQ-p	/log char,s
q		ics	(#10098);lmust	a f	ase llol iddtendde comeresunamisrall),
s ];["*/"]r+;["*"]Iouisll
#8138,seEemay tarf  ec ;cep:namare syaccesulowisll
aefiildst
  lojow.loca:nam	y.heateE			ndaerin;aaurbu syseQ	}trytugsrajaxLoca:nam ];loca:nam.h(eoIou	ckit.d } etugn ll
U)e tan h(eoQa	rribui}iof ec Ai
			leQgn ll
uloc}seE )ill	modafy itygiv}nheateE			nloca:namisrajaxLoca:nam = eateE		e.ct("diE			leQ( "a" )yisrajaxLoca:nam.h(eo |n)";israjaxLoca:nam = ajaxLoca:nam.h(eoI
}/ iogexSegE			 loca:nam(trto er esisajaxLocPa ts = 	urlm( ec" ajaxLoca:nam.toL
})Cas/()etme
[]Iouisll
Base "c gs
////or"u, l jQ		rtTajaxPreonlt	r idd jQ		rtTajaxTrans/  tu acce:na;adjToPreonlt	rsOrTrans/  ts( s
////e oe 			}	}agd data),}EleresunamQtstop:namaelido dhrefNos	Goo)*orn 
	},
acce:nam	 data),}Eleresunam,laccee 			}	}ny.ise/  of
data),}Eleresunamr! |n)u			//oJeturnilaccee=
data),}Eleresunae/{erdata),}Eleresunamr=o)*oI// F}E u ny.isJjQ		rt.isFcce:nam"laccee Optu nnsli data),
se=
data),}Eleresunam.toL
})Cas/()+/ );Q( 	cpckssAjaxf ddBoaOath = ddBoooo lengt= data),
s< lengtddBoooodata),
ddBoooo istddBooooback Be, leIouiitts usFor eet. data),
	iniGdetdata),}Eleresunamionin list		 i++ lengt				if 			Boooodata),
= data),
s[	 i];	}nned Wa c gi	/lty. rF'rFtasked	Gooadd be, l-maenned idy ;istlowi
			leQdBooooback Be, le= /^\+/catch" data),
	)yi ynn) {eback Be, lef 			Booooodata),
= data),
Tsubu		( 1etme
)*oI// F F}dBoooo ist = s
////e o[ data),
	] = s
////e o[ data),
	] me
[]Iouliiee cnfondwe rdd	Go tan s
////e oyaccordlowlydBoooo ist[eback Be, lef?n)| shiftor: "text"e]"laccee vu{r j}// 		ret ;
}ouisll
Base ins/	/:na
acce:namu, l e(eonlt	rslido trans/  tsu acce:na ins/	/:Preonlt	rsOrTrans/  ts( s
////e omtop:nams,ho		ggmalOp:nams,hjqXHRddBoodata),
/* int	rmael*/, ins/	/:ed/* int	rmael*/e 			}	}odata),
= data),
 metop:nams.data),
s[	0i];	}ins/	/:ed= ins/	/:ed mestvu u ins/	/:ed[ data),
	] =r
// I}	}sli  ist = s
////e o[ data),
	]ddBoath = ddBoo lengt=  ist ?  i
e< lengt:= ddBoo( ecu:edilh= ( s
////e sh  | e(eonlt	rsf ddBoas
		/:namI}	}n list		 i++ lengtr&&e( ( ecu:edilhQme
!s
		/:nam )				if 			Boos
		/:nam =  ist[	 i](top:nams,ho		ggmalOp:nams,hjqXHR )	rnrgelenf wa got (udir	/:ed	GooanoGdei data),
rnrgelewa try taer sif ( ecutlowooilhlido noGreace nht("dy	}ny.ise/  of
s
		/:nam = |n)u			//oJeturnnny.isJ!; ecu:edilhQme
ins/	/:ed[
s
		/:nam ]Qeturnilis
		/:nam |n| jQuer}dI/ yn					--c{ionnerop:nams.data),
s.| shift( s
		/:nam )	rnilis
		/:nam |nins/	/:Preonlt	rsOrTrans/  ts(ionennnns
////e omtop:nams,ho		ggmalOp:nams,hjqXHRd s
		/:nam, ins/	/:edre;/{r j}// F}//		r
gelenf wa'rFooilhl( ecutlowo linoGd	// waurs
		//sdisgelewa try c,e	ckit.allrdata),
	if noGreace nht("dy	}y.ise( ( ecu:edilhQme
!s
		/:nam )r&dh!ins/	/:ed[
)*o ]Qeturnlis
		/:nam |nins/	/:Preonlt	rsOrTrans/  ts(ionenns
////e omtop:nams,ho		ggmalOp:nams,hjqXHRd )*o, ins/	/:edre;//		r
geleunnecesuaryare sooilhl( ecutlowo(e(eonlt	rs)rnagd bui	it'llrbe lgit edbyrrh	rcalilr inectedlcasern 
	},
s
		/:namI
}ouisll
Als 	/ia heli;idu, l ajaxtop:namsisllectedoGat se)flat"top:nams (nodoGo bu deepheli;idldeislleFixes #9887u acce:na ajaxEli;idseargre,fsrcJ 			}isli key, deepddBoaflatOp:nams= jQ		rt.ajaxSettlows.flatOp:nams mestv	}n lis keyQtnfsrcJ 			}ny.is
src[ keyQ]J! |n| jQuer}Optionni( flatOp:nams[ keyQ]J?eargre :=  deep me=  deep	=ste Op)[ keyQ]J=
src[ keyQ]Ii y		reD

a) { deepOptionnjQ		rt.eli;id( 
//=,eargre, deepsOI
	 
}/ iojQ		rt.fn.eli;id(		aaloadasacce:nam"Jurl,{er ams, c;lbaaldeturnny.ise/  of
urlr! |n)u			//oJ&dh_loadOptionni
	},h_load.a fuy(Jc,ird adgeE		dssOI
gits usDac't dooa

q		st	if noi
			leQt	r wrbuing

q		sted	tia				--cy.is;!c,ir< lengtreturn ng
	},
c,ireisr		rern slioffJ=
urlmi jQxOf(h" "
)I//	 ) {
off>|n0f 			}nnsli s
		//orf=
urlms);k 
off,
url< lengtre;/{r jurlf=
urlms);k 
0,
offOI// F}
gits usDhrefNo	Gora GET

q		strn sli/  r|n)GEToI//rnrgelenf c,} s
c gd{er amet	r wau 		/vid d//	 ) {{er amsf 			}rgelenf it't	rsacce:nam	}ny.isJjQ		rt.isFcce:nam{er amsf f 			}nned WboasseE	ected it't c,} c;lbaal	}nnc;lbaald={er ams	rnilier amsf|n| jQuer}dI/
isOrge tOGdeiwi--,tbunld a{er am u			/wisOrg				--cy.is /  of{er amsf  |n)it'sstoretugiilier ams= jQ		rt.er am{er ams, jQ		rt.ajaxSettlows.trael:namael)	rnili/  r|n)POSToI//r j}// F}//	}r sligs
	 J=
c,ire u c ed,R
q		st	Gde	oeeIteheateE		er}iejQ		rtTajax(tionerurl:Jurl,ionie	,s: / 	ddBanidata),
:n)v "e"ddBanidata:{er ams,isOrggd Comelet  c;lbaald(respamsiT;diislus/e int	rmaely)ioa jomelet asacce:nam"JjqXHRd s	atus, respamsiT;dretugiiligd 		or= tae respamsboas s 	/ifilddbyrrh	JjqXHR it'sstrnnnnnrespamsiT;dr=JjqXHR.respamsiT;dI//r rgelenf succesuful, in'sstrrh	JHTMLiinGooallrrh	Jmkit.ed 
		// hsi ynn) {JjqXHR.isResolv}o( f 			}nna us#4825:bGetrrh	Ja//eaelrespamsiiinlcasern enned irdataFnlt	r ts c(us/ hiinlajaxSettlowsrn ennjqXHR.eace(acce:nam"Jrf 			}nnnnnrespamsiT;dr=Jreioner 	})eisr tlagexSe-cy.ia s
		//orfwas s 	/ifildisr tlas
	 .v "e( s
		//orf?rn r Orggd Ct("di irdummyJdivoGo vald tae resfNosrn eniijQ		rt	"<div>")ioa r Orggd in'sstrrh	Jc gi;idsiofiGdeheateE		e in,	oeeI:lowiGdeJscriptrioa r Orggd	GooavoidJidy 'PermisunamsDhnild' ;rr lsrinontioa r Org.a f	 j(respamsiT;dTllback l	script, ""))ioioa r Orggd	Loca:eiGde s 	/ifild 
		// hsioa r Org.fi j(s
		//or) :	}	}lliea usef,ct, just in'sstrrh	Jfull resfNo	}nnnnnrespamsiT;dr)eisr tl}/{r ynn) {Jc;lbaaldeturnr tlas
	 .eet.Jc;lbaal, [ respamsiT;dd s	atus, jqXHR (sOI
	 tl}/{r j}// F}OI/	}rg
	},
c,irer
r glomaeseriy de asacce:nam"etudiierred;JjQ		rt.er am{c,ir<seriy de Array( f er
r glomaeseriy de Arrayasacce:nam"etudiierred;{c,ir<ma "acce:nam"eudiiierred;{c,ir<
			leQt	?JjQ		rt.mat Array({c,ir<
			leQt	) :
c,ireisr		)ioa nonlt	r"acce:nam"eudiiierred;{c,ir<nCas &&;!c,ir<disstildt&& iat r({c,ir<c valldme=	s
		//T;mr wacatch({c,ir<,ctigCasf)me iat rrrinpudcatch({c,ir</  r f eisr		)ioa <ma "acce:nam"ei,  obdreugn ilsli	ndeJ=
jQ		rt( jQusf).nde();r
	iiierred;	ndei | 				f?rn r O				p:	n rr jQ		rt.isArray({ndef) ?rn rrr jQ		rt.ma ({nde,lacce:nam({nde,lireugn iliierred;	{t= fa:
	obd== f},endefa:
ndeTllback lhrCRLF, "\r\noret}eioner 	}e :rn 
	ir{t= fa:
	obd== f},endefa:
ndeTllback lhrCRLF, "\r\noret}eione}).geQ();ioD

}OIouisll
A	ret.ratbccer oflacce:namsu, l E doelowJcom	oc AJAX{evleQsgijQ		rt.eet.(J"ajax		arhtajax		optajaxComelet  ajaxErr ltajax	uccesutajax		 j"+/ );Q(h" "
),lacce:nam	 idt: O		}jQ		rt.fn=toe]r=tacce:nam",fOudiierred;{c,ir<am",o,lar)ereD
I
}OIouiijQ		rt.eet.(J[h"get"de)post"e],lacce:nam	 iddmethodOptionjQ		rt[dmethode]r=tacce:nam"Jurl,{data, c;lbaal, /  retugits usshift adgeE		dssif
data adgeE		dfwas omitted	tny.isJjQ		rt.isFcce:nam
data )Optionie	,sh  ,
 metc;lbaaleionerc;lbaald=
datae/{erdataf|n| jQuer}dI// F}//	}r 
	},
jQ		rtTajax(tionie	,s:dmethod,ionerurl:Jurl,dBanidata:
data,dBanisuccesu: c;lbaal,dBanidata),
: ,
// F})ereD
I
}OIouiijQ		rt.eli;id(		a	}geQScriptasacce:nam"Jurl,{c;lbaaldetu	}r 
	},
jQ		rtTgeQ"Jurl,n| jQuer}d,{c;lbaal,n)scriptof er
r glo	}geQJSON:tacce:nam"Jurl,{data,{c;lbaaldetu	}r 
	},
jQ		rtTgeQ"Jurl,ndata,{c;lbaal,n)jsonof er
r glo	}ggd Ct("diutaJfull fildg}d settlows it'sstiinGoeargre	}gllt shr boGdlajaxSettlowsJidd settlowsefiilds.iss usefargrtiis omittldmdwridiuiinGolajaxSettlows.issajaxSetu asacce:nam"eargre,fsettlowsdeturnny.isfsettlowsdeturnns usBunldlow i settlows it'sstrnnsajaxEli;idseargre, jQ		rt.ajaxSettlowsf er

				--cuisOrge tEli;idlowlajaxSettlowsrn ensettlows =eargree/{erargre= jQ		rt.ajaxSettlowsI// F}//sajaxEli;idseargre, settlowsf e	}r 
	},eargreer
r glo	}gajaxSettlows:ptioerurl:JajaxLoca:nam,rnnysLocal:JrlocalP	/toc 	catch({ajaxLocPa ts[ 1]f ddBoaglobal: 
// ,ione	,s:n)GETo,ionec gi;id),
:n)apelica:nam/x-www-, lm-urlenjtr do,ionep	/cesuData: 
// ,ionOnsync: 
// ,ionO/*ione	 mio d:= ddBnidata: 				ddBoodata),
: 				ddBoouser= fa: 				ddBoocassword: 				ddBoljet.a: 				ddBootrael:namae: );
	ddBanhead	rs:pt}ddBan*/	oionOncceptr:ptionglxml:n)apelica:nam/xml,oG;l/xml"ddBoaOhtml:n)G;l/v "e"ddBaniG;l:n)G;l/bacin"ddBanijson:n)apelica:nam/json,oG;l/jivascript"ddBani)*o: all),
s// F},/{ionec gi;itr:ptionglxml:n/xml/ddBoaOhtml:n/v "e/ddBanijson:n/json/// F},/{ionnrespamsiFiilds:ptionglxml:n)respamsiXML"ddBaniG;l:n)respamsiT;d"// F},/{iorggd	List of
data	conhidt	rsiorggd 1) keyQ, lmatiis "sourc _	,eue Dtlon:nam_	,e" (i slowle cpck Qgm-between)iorggd 2) c,e	ckit.allrsymb 	)*o	ckmrbulus/eu, l sourc _	,eiorgconhidt	rs:pt
isOrggd Conhidt idyGd	// tooG;ldBani)*oG;l":  lojow.				//,
isOrggd T;doGo v "el(
//  ];,c trans, lmatnam)dBani)G;l v "e": 
// ,ioisOrge tEndef"dioG;l
aurahjson eleresunamiBani)G;l json": jQ		rtTer seJSON,ioisOrge tPr sioG;l
aurxmliBani)G;lrxml": jQ		rtTer siXML// F},/{iots usFortop:namsected	shluldc't bu deepheli;idld:iots usyo 	ck;adjsyo rtownocust m op:namseaer sifiots usiddare seyou ct("dionsected	shluldc't buiots u deepheli;idlde(se/ ajaxEli;id)dBoaflatOp:nams:			}ieac gi;t: 
// ,ionerurl: 
// // F}r
r glomaeajaxPreonlt	r:;adjToPreonlt	rsOrTrans/  ts( e(eonlt	rsf ddBoajaxTrans/  t:;adjToPreonlt	rsOrTrans/  ts( trans/  ts	)glo	}ggd McindmethoddBoajax:tacce:nam"Jurl,{op:namsOptiornrgelenf urlsuetan it'sst, slmula:e e(e-1.5 sigma/e ornny.ise/  of
urlf  |n)it'sstoretugiilop:namsf=
url;/{r jurlf|n| jQuer}dI// F}//	}rs usForc  op:namsoGo butan it'sst	}rsop:namsf=
op:nams mestv//	}r sliggd Ct("di rh	Jfgmal
op:nams it'sstrnnss= jQ		rt.ajaxSetup(st,{op:namsO,isOrggd C;lbaalsec gi;lionerc;lbaalC gi;t	=es.c gi;l	me
s,isOrggd C gi;lu, l global{evleQsgitts uiIt't c,} c;lbaalC gi;t	y.ions wau 		/vid d	iniGde{op:namsgitts u idd if it't	r d e ,cti  lta jQ		rtec lile:nam	}nglobalEnleQC gi;t	=ec;lbaalC gi;tr! |nst&& iat r(ec;lbaalC gi;
n,cti),
	me c;lbaalC gi;t	yns	anc of jQ		rte) ?rn rriijQ		rt	 c;lbaalC gi;t	e : jQ		rt.ev		l,isOts usDhr;rredsgittsdhr;rred= jQ		rt.Dhr;rred(	,	} jomelet Dhr;rred= jQ		rt.C;lbaals(n)inc dmemory"O,isOrggd S	atus-duf	 j		l c;lbaalsrn ens	atusCcti	=es.s	atusCcti mest,gitts u	y.Modifild keygittsy.ModifildKey,gitts u	Head	rsl(
foy	r w	s/ hi;lQa	 inc )dBani
q		stHead	rs	=st,iBani
q		stHead	rsgCass	=st,iBac ed,Respamsiihead	rsiBaniespamsiHead	rs				//,iBaniespamsiHead	rs,iBac ed trans/  tiBac trans/  t,iBac ed t mio d E doeern ent mio dT mir,isOrggd Cross-daerin deree:nam
ndrsiBanier es,iBac ed Th	JjqXHR s	atern ens	ateh = ,iBac ed To knaw	y. global{evleQs	r woGo bu disbkit.edioninir	Globals,iBac ed Loop
ndristilgitt;i,gitts usFat txhrgittsjqXHR =			}	}llat("dyS	ate:= ddB	}Orggd C;t.et c,iihead	rrnilis
tR
q		stHead	r: acce:nam	t= f},endef=tetugnanny.isJ!s	atetetugnann slilnCas ]t= f}.toL
})Cas/();r
						nCas ]t
q		stHead	rsgCass[lnCas ] ]t
q		stHead	rsgCass[lnCas ]Qme nCas;r
						
q		stHead	rs=t= fae]r= ndef=/gpy	 tl}/{r jng
	},
c,ireisr	 F},/{iotsc ed,Raw u			/wisOOOOgeQA		RespamsiHead	rsasacce:nam"etudii jng
	}, s	ate=ta 2r? espamsiHead	rs				// : 				eisr	 F},/{iotss usBunldsihead	rs aauhtstin y. n;ed/e sOOOOgeQRespamsiHead	rasacce:nams keyQetudii jngsliJmkit.;gnanny.is s	ate=ta 2Qetudii nny.isJ!espamsiHead	rsQetudii naniespamsiHead	rs	=st;gna		y=rreilfse(Jmkit. ]thead	rsm( ec" espamsiHead	rs				// ) )Optioni naniespamsiHead	rs[Jmkit.[1r.toL
})Cas/(	e]r=Jmkit.[ 2Q]y//y=i		 j}// F		 j}// F				mkit. ]tespamsiHead	rs[Jkey.toL
})Cas/(	e]/gpy	 tl}/{r jng
	},
mkit. ] |n| jQuer}s? 				p:
mkit.eisr	 F},/{iotss usO:errieestespams	Jc gi;id-/ iihead	rrnilio:errieeM mi),
: acce:nams / =tetugnanny.isJ!s	atetetugnann r<m mi),sh  ,=/gpy	 tl}/{r jng
	},
c,ireisr	 F},/{iotsc ed,Canc lrrh	J
q		strn    ab  t:;acce:nams s	atusT;dretuginn r	atusT;dr= s	atusT;dtme
)ab  t";gnanny.is trans/  tretuginn c trans/  t.ab  ts s	atusT;dre/gpy	 tl}/{r jngeace(= d s	atusT;dre/gpy jng
	},
c,ireis	 tl}/{r jv//	}rggd C;lbaalu, lare seehidyGd	// isreaceiots uiIt isrjQuer}eaer sbuna})}ijsllol jomelatru if it isrjQclr wdiots uiedoGdeu	 jiofiGde
acce:namu(w.ft. wluldsbu	mor slogicaelido t("dsti )dBanacce:namueace(=s	atus, nativ}S	atusT;d, respamsis, head	rsQetudiisOrggd C;led inc isOny.is s	ate=ta 2tetuionneerred;;ioniD

isOrge tS	ateiis "eace" nawrn ens	ateh =2;diisOrggd Clear t mio d if it ;istsisOny.is t mio dT mirtetuionneeclear) mio ds t mio dT mirte;ioniD

isOts usDhre,e wics	trans/  tr, laearlhlgarbag sc lile:namisOts us(no
mkit	r how longrrh	JjqXHR it'sst )illrbulus/e)iBac trans/  tf|n| jQuer}dI/
isOrggd C;t.e respamsiihead	rsiBaniespamsiHead	rs				//f|nhead	rsQmen)";//gitts usSet t("dyS	ategittsjqXHR.t("dyS	ater= s	atus >n0f? 4:= ;//gittssligts	uccesu,rnilisuccesu,rnili;rr l,rnnn r	atusT;dr= nativ}S	atusT;d,rnnnnnrespamsi ]tespamsit	? ajaxH doeeRespamsis(ns,hjqXHRd espamsit	e :n| jQuer}d,rnnnnnlas	Modifild,rnili;tag;//gittgelenf succesuful, E doee / =tt.ainlowisOny.is s	atus > =200f&& s	atus < 300fmens	atus =ta 304Q 			}	}llagexSetrrh	enf-Modifild-Sloc}s do/orenf-Nace-Mkit.nhead	r, if in	y.Modifild mtr .gittny.is s.y.ModifildQ 			}	}llay.ise( las	Modifildr=JjqXHR.geQRespamsiHead	r( "Las	-Modifild" ) )Optioni rr jQ		rt.las	Modifild[ y.ModifildKeye]r=Jlas	Modifild/gpy	 tl}/}llay.ise( ;tagr=JjqXHR.geQRespamsiHead	r( "Etag" ) )Optioni rr jQ		rt.;tag[ y.ModifildKeye]r=J;tag;
y=l
	
	 tl}/ gp
a usef,ct modifildgittny.isns	atus =ta 304Q 			}	}nn r	atusT;dr= ",ctmodifild";gnannys	uccesu =r
// I}gp
a usefwe E v 
data/{=i						--			}	}nn trytugpyaolisuccesu = ajaxConhidtsnsd espamsite;ioninn r	atusT;dr= "succesu";gnannnys	uccesu =r
// ;gnannn	ckit.deetugpyaolied We E v 
a{er ser;rr lioninn r	atusT;dr= "er ser;rr l";gnannn;rr lr=J;;
y=l
	
	 tl}/ i						--			}olied We ;lrast ;rr lst
 r	atusT;douliiee cnfondit by defr	atusT;ds dor	atusr, l itn-ab  tsiBann;rr lr=Jr	atusT;d;
nny.isJ!r	atusT;dfmens	atusretuginn r	atusT;dr= ";rr l";gnattny.isns	atus <n0f 			}nnn r	atush = ;
y=l
	
	 tl}/ i			//gitts usSet
datar, liGde
aat txhr it'sstrittsjqXHR.r	atush ns	atus;rittsjqXHR.r	atusT;dr= ""r+J( nativ}S	atusT;dfme s	atusT;dre///gitts us	uccesu/Err lisOny.is ys	uccesu  			}ntsdhr;rred.resolv}Wshr	 c;lbaalC gi;t, [ succesu, s	atusT;d, jqXHR (sOI
i						--			}ntsdhr;rred.re'sstWshr	 c;lbaalC gi;t, [ jqXHR, s	atusT;d, ;rr l (sOI
i			//isOrggd S	atus-duf	 j		l c;lbaalsrn enjqXHR.s	atusCcti( s	atusCctisOI
i		s	atusCctif|n| jQuer}dI/
isOny.is nir	Globalu  			}ntglobalEnleQC gi;tTrrigger(J"ajax"r+J( ys	uccesu ?n)	uccesuor: "Err l"O,isOOOOOO[ jqXHR, s, ys	uccesu ?nsuccesu : ;rr l (sOI
i			//isOrggd Comelet 	} jomelet Dhr;rred.nir	Wshr	 c;lbaalC gi;t, [ jqXHR, s	atusT;d (sOI/
isOny.is nir	Globalu  			}ntglobalEnleQC gi;tTrrigger(J"ajaxComelet ", [ jqXHR, s (sOI
i		ggd H doeeiGde
global AJAX{cougi;r
nny.isJ!( --jQ		rtTactiv} )Optio aniijQ		rt.ev		lnrrigger(J"ajax		op"sOI
	 tl}/{r j}// F}//	}rgll
A	ret.rdhr;rredsgitsdhr;rred.p	/misi( jqXHR )	rnenjqXHR.succesu = jqXHR.eace	rnenjqXHR.;rr l = jqXHR.fril	rnenjqXHR.jomelet  = jomelet Dhr;rred.addI/
isrggd S	atus-duf	 j		l c;lbaalsrn ejqXHR.s	atusCctir=tacce:nam"Jma Jeturnnny.isJma Jeturnnlsli tmp	rneOny.is s	ate< 2tetuionnnin lis tmp inJma Jeturnni		s	atusCcti[ tmp ]= [ s	atusCcti[tmp],Jma [tmp] ]y//y=i			/oner 				--turn ni
tmp =Jma [ jqXHR.s	atus ]y//y=i		jqXHR.nfons tmp, tmp OI
	 tl}/{r j}//jng
	},
c,ireis jv//	}rged,ReeI:soaauh charaat	r (#7531:s dor			//fp	/motnam)dBaellbaddu		/toc 	 if noGr		/vid d (#5866:ont7 yssult shro		/toc 	-lesu
urls)dBlied We aluo })}iGde url{er amet	rcy.iavrilstilgitts.urlf|nse( url{me s.urlf 	+ ""
	Tllback lh	aauh, ""
	Tllback lh			/toc 	,{ajaxLocPa ts[ 1]	+ "//"
	v//	}rged,Elrast data),
s  istgitts.data),
s =jQ		rtTrrim( s.data),
tme
)*"
	.toL
})Cas/()+/ );Q( 	cpckssAjaxf I
gits usDet	rmin-cy.ia cross-daerin

q		st	isrinoord	rrnny.isfs.crossDaerin
 | 				 etugn niea ts = 	urlm( ec" s.url.toL
})Cas/() OI
	 ts.crossDaerin
  !!( ea ts && iat r(epa ts[ 1]	!={ajaxLocPa ts[ 1]tmeepa ts[ 2]	!={ajaxLocPa ts[ 2]	me iat rr(epa ts[ 3]tmee(epa ts[ 1]f  |n)v tp:"Q?
80 : 443 ) O	!=rnni		({ajaxLocPa ts[ 3]tmee({ajaxLocPa ts[ 1]f  |n)v tp:"Q?
80 : 443 ) O	)iBac OI// F}
gitggd Conhidt data if noG nht("dyta u			/wrnny.isfs.dataQ&&rs.p	/cesuDatas&& /  offs.datar! |n)u			//oJeturnils.data= jQ		rt.er am{s.data, s.trael:namael)	r/ F}//	}rgll
A fuy e(eonlt	rs	}rins/	/:Preonlt	rsOrTrans/  ts( e(eonlt	rs, s, op:nams,hjqXHR )	rornrgelenf

q		sdfwas ab  t d	insid  a e(eonl	r, s	op taer=//ny.is s	ate=ta 2tetui/jng
	}, );
		r/ F}//dBlied We ck nir	 global{evleQs	rsiofinaw	y. asked	GodBlinir	Globalu	=es.global	rornrgeleU f	ica)}iGde 	,eiorgr</  r=esn	,s.toU f})Cas/( I
gits usDet	rmin-cyf

q		sdfaauJc gi;idiorgr<aauC gi;il= !rnoC gi;ilcatch({r</  r I
gits usWkit.u, l atmew settof

q		sds	}ny.is nir	Globalus&& jQ		rtTactiv}	if= |n0f 			}niijQ		rt.ev		lnrrigger(J"ajax		a t"l)	r/ F}//	}rgll
Mor  op:namsoE doelowu, l 
q		sdst shronoJc gi;idiony.isJ!r<aauC gi;il 		//gittgelenf datasueiavrilstil,ya f	 j data	Go urlgitny.isfs.dataf 			}nitts.urlf+|nserq		rtcatch({s.urleQ? "&or: "?"f 	+fs.dataI
i		ggd #9682:	oeeI:s datafsoected it't noGlus/e ins d{evle/eaelretrygp and	act}fs.dataI
i			//isOrellbGet y.ModifildKey be, l- add	//rrh	Jagii-jet.a{er amet	risOrey.ModifildKey ={s.url	rornrgellbadduagii-jet.a insurl y. n;ed/egitny.isfs.jet.a = | );
	 		//gnnlsli ts =jQ		rtTnaw(	,	} rgellbtrytllback	//r_= if it isrtaer=gpy jng
	 ={s.urlTllback lh	ts,l"$1_=or+ tsrOIouioliiee  lf noGd	// waurllback d,oadd t mis	amp	GooGdeu	 j	}nitts.urlf=lretr+J(= 

	h  |{s.urleQ?nserq		rtcatch({s.urleQ? "&or: "?"f 	+f"_=or+ tsr: ""f I//r j}// F}//	}rggexSetrrh	icor(unenhead	r, if datasueibuing
s;idiony.isfs.dataQ&&rs.aauC gi;ilQ&&rs.c gi;id),
 ! | );
	 metop:nams.c gi;id),	 		// enjqXHR.s
tR
q		stHead	r( "C gi;il-),	",rs.c gi;id),
l)	r/ F}//	}lagexSetrrh	enf-Modifild-Sloc}s do/orenf-Nace-Mkit.nhead	r, if in	y.Modifild mtr .gitty.is s.y.ModifildQ 		isOrey.ModifildKey ={y.ModifildKey me s.urle/{er) {ejQ		rt.las	Modifild[ y.ModifildKeye]r 		isOrenjqXHR.s
tR
q		stHead	r( "nf-Modifild-Sloc}",ejQ		rt.las	Modifild[ y.ModifildKeye]r e/{=i	}//nn) {ejQ		rt.;tag[ y.ModifildKeye]r 		isOrenjqXHR.s
tR
q		stHead	r( "nf-Nace-Mkit.",ejQ		rt.;tag[ y.ModifildKeye]r I//r j}// F}//	}rggexSetrrh	iAcceptrnhead	rr, liGde
serv	r, duf	 jlowooi c,e data),
ioenjqXHR.s
tR
q		stHead	r(iBani)Accept"ddBanis.data),
s[	0i]Q&&rs.nccepts[	s.data),
s[0] ] ?rn rris.nccepts[	s.data),
s[0] ]r+J(=s.data),
s[	0i]Q! |n)*"Q? ", "
+ all),
s	+f"; q=0.01" :n)"Op:	n rr s.nccepts[
)*o ]	n r);
(tiagd C valt, lnhead	rstop:nam	}nin listi in=s.head	rs 		// enjqXHR.s
tR
q		stHead	r( i,=s.head	rs[	 i]l)	r/ F}//	}rgll
Allf ocust m head	rs/m mi/  sJiddaearlh ab  diony.isfs.be, l-		 jQ&&isfs.be, l-		 j onhe	 c;lbaalC gi;t, jqXHR, s ) = | );
	 me s	ate=ta 2te 		// ergll
Ab  d	if noGreace nht("dy	}OrenjqXHR.ab  Q();ioDjng
	}, );
		r// y		rernrge tIns	;l c;lbaalsooirdhr;rreds	}nin listi in={ succesu: 1, ;rr l: 1, jomelet as1 } 		// enjqXHR[	 i](ts[	 i]l)	r/ F}//	}rellbGet trans/  tiBactrans/  t |nins/	/:Preonlt	rsOrTrans/  ts( trans/  ts, s, op:nams,hjqXHR )	rornrgelenf
no trans/  tmdwe ruto-ab  diony.isf!trans/  tretugingeace(=-1, "No Trans/  t"f er

				--cuisttsjqXHR.t("dyS	ater= 1;gitts usSend global{evleQisOny.is nir	Globalu  			}ntglobalEnleQC gi;tTrrigger(J"ajaxSend", [ jqXHR, s (sOI
i		}gitts us) mio dgitny.isfs.nsyncQ&&rs.t mio d >n0f 			} ent mio dT mirr= s
t) mio ds acce:nam"eudiiOrenjqXHR.ab  Q(J"t mio d"sOI
	 tl},rs.t mio dsOI
i			//isn trytugpyaos	ater= 1;gin c trans/  t.s;idse
q		stHead	rs,reacesOI
nnn	ckit. deetugpyaoge tPopcgater;cep:namaas ;rr l	if noGreacerneOny.is s	ate< 2tetuionnnieace(=-1, esOI
ntts usSimelytlltarf ,oGdeiwi-=/oner 				--turn ni
tarf ,ee/{=i			//r j}// F}//	}r 
	}, jqXHRer
r glo	}ggd Seriy de s d{arraytofQ, lmi
			leQt	 l a settof	}ggd key/ndef=uiinGola q		rt u			/wrnner am:;acce:nams a, trael:namael)tuditsli s ];[]ddBoaOadd =sacce:nams key,endef=tetugnannelenfendef=tit	rsacce:nam, invok=tids do
	},tidsendef=rnilindef=J={jQ		rt.isFcce:nam ndef=eQ? ndef=(Op: ndef=/gpy	 ts[	r< lengt ]= enjtr URIComeonleQs keyf 	+f"=or+ enjtr URIComeonleQ" ndef=)	/{r jv//	}rggexSetrtrael:namaelGol
//  , l jQ		rt <= 1.3.2 beE vior.gitty.is trael:namael= |n| jQuer}Optionnitrael:namael= jQ		rt.ajaxSettlows.trael:namaeI/ y		rernrge tIf  d{array wau cass/drtr,oasseE	ected it iss d{arraytofQ, lmi
			leQt.gitty.is jQ		rt.isArray({af tmee({a.jq		rt &dh!jQ		rt.isPlatrOt'sst({af te 		// eggd Seriy de sGdeQ, lmi
			leQt// egjQ		rt.eet.(Ja,lacce:nam	etuiooaOadd({c,ir<nCas,{c,ir<ndef=)	/{r j)	//n 
				--cuisOrge tIf trael:namae, enjtr sGdeQ"ald"fwayl(
fofway 1.3.2  l alderisOrge tdid it),toGdeiwi-- enjtr {er amsf(unursiv}ly.gittin listsli e(eonx ins tetugnannbunldPr ams( e(eonx,oa[ e(eonx ], trael:namae, addr I//r j}// F}//	}rggexR
	},ttae resfNolow seriy dea:nam	}r 
	},	r<join( "&"
	Tllback lh	20, "+"
	;ioD

}OIE u acce:na;bunldPr ams( e(eonx,oit', trael:namae, addtetugnty.is jQ		rt.isArray({it'te 		// egd Seriy de {arraytir c.giegjQ		rt.eet.({it',lacce:nam	 iddv 		// ety.is trael:namaelmee	braalrlcatch( e(eonxte 		// ets us)t("d eet. arraytir c
aurahsc;ar.iooaOadd( e(eonxddv)	//n 

				--cuinannelenf arraytir c
is itn-sc;ar (arraytor it'sst), enjtr tirrioliiee 
numeric i jQxlGolresolv}rdhseriy dea:nameambigudWe yssuls.iooas usNtt	ected raald(rsiof 1.0.0)	ckc't nur 		elyQdhseriy deeioliiee 
n	sted arraysu		//erlh,s do a	r cel	// toodofsoemay na})eioliiee 
a
serv	r ;rr l. Possibl
 onxes	r woGo	modafy raal'rioliiee 
dhseriy dea:namealgorshrmtoroGor		/vid s d op:namtoroflagioliiee oGoQ, lc {arraytseriy dea:namoGo bu s.allow.gnannbunldPr ams( e(eonx	+f"["r+J( /  ofenf  |n)it'sstolme jQ		rt.isArray(veQ? i :n)"Op+f"]"ddv, trael:namae, addr I//r j}// j)	//n 				--cy.is;!crael:namae &d{it't!| 				&& /  ofeit'f  |n)it'ssto 		// egd Seriy de {it'ssttir c.giegn listslignCa  trtit' 		//nnbunldPr ams( e(eonx	+f"["r+gnCa p+f"]"ddit'=t= fae], trael:namae, addr I//r }//n 				--		// egd Seriy de hsc;artir c.giegadd( e(eonx,oit'sOI
	 
}/ ioed TQuefis
stnllooi c,e jQ		rt{it'sst...r, l itwioed Wa	t	GooeI:s{c,ir	Go jQ		rt.ajax sofaedayiijQ		rt.eli;id(		o	}ggd Cougi;rr, l vald	//rrh	 numbsreofeactiv} q		ri
s// active:= ddB	}gd Las	-Modifildnhead	rrjet.ar, l ieliJ
q		strnnlas	Modifild:pt}ddBa;tag:pt}/ 
}OIouisl* H doeestespams	r	Go anlajaxJ
q		st:	n* - setsi;lQrespamsiXXXefiildsyaccordlowly	n* - fi jsoGdeyrightrdata),
	(mudi"diutbetweenJc gi;id-/ iJiddaex/	/:edrdata),
)	n* -srred;srrh	icor(uspamdlowQrespamsi	n*/u acce:na ajaxH doeeRespamsis(ns,hjqXHRd espamsit	e 		o	}gsliJc gi;idu	=es.c gi;iduddBoodata),
u	=es.data),
u,ionnrespamsiFiildu	=es.respamsiFiilduddBoljd,rnnn/ 	ddBanfgmalData)/ 	ddBanfgrstData)/ 	IouisagexFilQrespamsiXXXefiilds	}n lis t,
	inirespamsiFiildu	eturnny.is t,
	inirespamsis 		// enjqXHR[	respamsiFiildu[t,
] ]=irespamsis[ t,
	]Ii y		reD}/ 
ged,ReeI:s ruto data),
lido grec gi;id-/
	iniGdetp	/cesu
greilfsedata),
s[	0i]Q= |n)*" 		// edata),
s.shift()I//	 ) {
ctl= |n| jQuer}Optionnictl= r<m mi),slmeJjqXHR.geQRespamsiHead	r( "c gi;id-/
" Ii y		reD}/ 
ged C valty. rF'rFteeallowt shroa knawnJc gi;id-/ i
g) {
ctOptionn lis t,
	inJc gi;idu	 		// ety.is c gi;idu[ t,
	]&& c gi;idu[ t,
	]catch
ctO 		// etsdata),
s.| shift( t,esOI
nttsbt("kI//r j}// 		reD}/ 
ged C valtto se
	ifwe E v 
airespamsir, liGdeaex/	/:edrdata), i
g) {
data),
s[	0i]	inirespamsis 		dBanfgmalData)/ 	l= data),
s[	0i];	}				--		//ts us)ty	conhidtibl
 data),
sionn lis t,
	inirespamsis 		dBany.isf!data),
s[	0i] me s.conhidt	rs[ t,
	+h" "
+ data),
s[0] ] 		dBananfgmalData)/ 	l= t,
I
nttsbt("kI//r j}/Bany.isf!fgrstData)/ 	 		dBananfgrstData)/ 	l= t,
I//r j}// 		res usOr just })}ifgrstionsdBanfgmalData)/ 	l= fgmalData),slmeJfgrstData)/ 	IreD}/ 
a usefwe fo {dardata), i
ied We add c,e data),
	GooGde  ist y. n;ed/e
ied  do
	},rrh	icor(uspamdlowQrespamsi
g) {
fgmalData)/ 	 		dBag) {
fgmalData)/ 	!== data),
s[	0i] 		dBagsdata),
s.| shift
fgmalData)/ 	 I// F}//s
	},rrespamsis[
fgmalData)/ 	]I
	 
}/ ioed C.ain	conhidsnamsygiv}nrrh	J
q		st  doiGdeho		ggmal respamsiu acce:na ajaxConhidtsnsd espamsi	e 		o	}gll
A fuy GderdataFnlt	r tf 		/vid d//y.isfs.dataFnlt	r	e 		onnrespamsi ]fs.dataFnlt	r" espamsi,fs.data)/ 	 I// }	o	}gsliJdata),
u	=es.data),
u,ionnconhidt	rs	=st,iBaci,gittkey,gitt lengt= data),
s< lengtddBootmp,(tiagd Cur 		elido c(uvious data),
sionnur 		el= data),
s[	0i],(tiac(uv,(tiagd Conhidsnon eleresunamiBanconhidsnam,(tiagd Conhidsnon acce:namiBanconh,(tiagd Conhidsnon acce:namsl(transitiv} conhidsnam)iBanconh1,ionnconh2;diisO usFor eet. data),
	iniGd=tt.ain	}n lis ir= 1		 i++ lengt				if 			Bionngd Ct("di conhidt	rsJma ionngdt shrolow	ica)ld keys	}ny.is ir=== 1	e 		onnn lis keyQtn s.conhidt	rs	e 		onnny.ise/  of
key = |n)u			//oJeturnnnnnconhidt	rs[Jkey.toL
})Cas/(	e]	=es.conhidt	rs[Jkey ]I
	 tl}/{r j}// F}//	}rgllbGetrrh	 data),
s(tiac(uv	=scur wid;ionnur 		el= data),
s[	 i];	}rnrge tIf nur 		elis ruto data),
,n|pdate io	Gop(uv	}ny.is nur 		eQ= |n)*" 		// enur 		el=p(uv;rnrgelenf
no ruto ido data),
s{ar	Ja//eaeuy dif,e wit	tia				--cy.isp(uvQ! |n)*"&&p(uvQ! |nnur 		ef 			BionngllbGetrrhi conhidt	rionngconhidsnaml=p(uv	+h" "
+scur wid;ionngconhl=conhidt	rs[Jconhidsnami] meconhidt	rs[n)* "
+scur widi];	}rnrrgelenf taer sit	nd dir	/:conhidt	r, sea	c  transitiv}ly	Bany.isf!conhJeturnnnnconh2f|n| jQuer}dI// Fnn lis conh1Qtn conhidt	rs	e 		onni
tmp =Jconh1+/ );Q(h" "
);gnattny.isntmp[	0i]Q= |np(uv	metmp[	0i]Q= |n)*" 		// ennnconh2f=conhidt	rs[tmp[1]	+h" "
+scur wid ]I
	attny.isnconh2f 		// ennanconh1f=conhidt	rs[conh1f]I
	attny.isnconh1Q= |l
//   		// ennnngconhl=conh2I
	attn				--cy.isnconh2Q= |l
//   		// ennnngconhl=conh1y//y=i		 j}// F		 tsbt("kI//=i		 j}// F		 }
	 tl}/{r j}// Fa usefwe fo {dnd conhidt	r, disbkit.s d{err lisOny.is !snconh meconh2te 		//  egjQ		rt.err l( "No conhidsnamst
 "
+sconhidsnamTllback l" ","	Goo)) OI
r j}// Fa usef fo { conhidt	rsit	ndtu d{
q	indeenc isOny.isnconh ! |l
//   		// enngd Conhidtt shro1toro2 conhidt	rsyaccordlowlyrnnnnnrespamsi ]tconh ?tconh( espamsi	e :conh2snconh1(espamsi)re;/{r j}// F}//		r
s
	},rrespamsiI
}/ io/ i isvar jsc =jQ		rtTnaw(	,	}jsle= /(\=)\?(&|$)|\?\?/iIouislusDhrefNo	jsonp settlowsrnjQ		rt.ajaxSetup(	// jsonp:n)c;lbaal",// jsonpC;lbaalasacce:nam"etudiierred;JjQ		rt.eleidoo	+f"_"r+J( jsc	if	;ioD

}OIouislusDhree:,dit by def op:nams idd ins	;l c;lbaalson l	jsonp 
q		sds	}jQ		rtTajaxPreonlt	r(n)json	jsonp",lacce:nam	 s,ho		ggmalSettlows,hjqXHR ) 		o	}gslinins/	/:Datas=rs.c gi;id),
Q= |n)apelica:nam/x-www-, lm-urlenjtr do && iat( /  offs.data = |n)u			//oJOIouisy.isfs.data),
s[	0i]Q= |n)jsonp"	me iats.jsonp ! | );
	Q&&isfjslecatch({s.url)me iat rins/	/:DataQ&&fjslecatchsfs.dataf te 		//ditsli respamsiC giatrir,isOr jsonpC;lbaals=rs.jsonpC;lbaals= iat rjQ		rt.isFcce:namrs.jsonpC;lbaalseQ?rs.jsonpC;lbaal(Op:rs.jsonpC;lbaal,isOr c(uvious =  lojow[ jsonpC;lbaals],ionerurls=rs.url,dBanidatas=rs.data,dBanillback s=r"$1"r+ jsonpC;lbaals+r"$2";r
	}ie!== hs.jsonp ! | );
   		// enurlf=
urlmllback sfjsle,rllback re;/{r e!== hs.urlf  =
url	e 		onnny.isnins/	/:Data	e 		onnanidatas=rdatamllback sfjsle,rllback re;/{er}/ ynn) {es.data = |rdata	e 		onnrgellbadduc;lbaalJmaneaeuy	onnrgeurlf+|ns/\?/catchsfurleQ? "&or: "?"Op+hs.jsonp	+f"="r+ jsonpC;lbaalI
	 tl}/{r j}// F}//	}rgs.urlf=
url;/{r s.datad=
datae/{rnrge tIns	;l c;lbaalrnrg lojow[ jsonpC;lbaals] =sacce:nams respams   		// enrespamsiC giatrir ];[ respams  ]eis jv//	}rggd Clean-up acce:namiBanjqXHR.always(acce:nam"etuditts usSetuc;lbaalJbaal	Go c(uviousendef=rnirg lojow[ jsonpC;lbaals] =sc(uvious;isOrggd C;l if idfwas a acce:nam idd we E v 
airespamsi/{r e!== hrespamsiC giatrir &&fjQ		rt.isFcce:nam c(uviousee 		//  eg lojow[ jsonpC;lbaals] hrespamsiC giatrir[	0i]r I//r j}// j)	//n  ll
U)e data	conhidt	rlGolre			ev 
json	aft	rJscript ( ecu:namn  s.conhidt	rs["script
json"] =sacce:nams 		dBany.isf!respamsiC giatrir 		//  egjQ		rt.err l( jsonpC;lbaals+r"fwat	ndtrcalild"f I//r j}// Fs
	},rrespamsiC giatrir[	0 ]eis jv//	}rggdQ, lc  json data),
ioens.data),
s[	0i]Q=n)jsonoI
gits usDelegaterGolscriptdiierred;n)scripto;ioD

}OI/ io/ i ise tIns	;llscript data),
injQ		rt.ajaxSetup(	// ncceptr:ptiongscript: "G;l/jivascript, apelica:nam/jivascript, apelica:nam/ecmascript, apelica:nam/x-ecmascript"r
r gloec gi;itr:ptiongscript: /jivascript|ecmascript/r
r gloec nhidt	rs:pt
ni)G;lrscript":;acce:nams G;lf 			}niijQ		rt.globalEnals G;lf ;// Fs
	}, G;leis jioD

}OI/ iogd H doeeijet.a'sls 	/ia hca)}iand global	}jQ		rtTajaxPreonlt	r(n)script",lacce:nam	 sf 			}y.isfs.jet.a = |n| jQuer}Optionns.jet.a = );
		r/ ioDy.isfs.crossDaerinOptionns./  r|n)GEToIionns.global = );
		roD

}OI/ iogd Blojlscript tagrhaal	Grans/  tiBjQ		rtTajaxTrans/  t(n)script",lacce:nam	s 		//dited TQue	Grans/  tooilhteealst shrocross daerin

q		stsioDy.isfs.crossDaerinOp	//ditslilscriptddBoaOhead = eateE		e.head || eateE		e.geQE			leQsByTaggCas(n)head"f [0] || eateE		e.eateE		QE			leQI/	}rg
	},
		Bionngs;id:;acce:nams _,{c;lbaalOp	//ditngscript = eateE		e.ct("diE			leQ( "scriptof e//ditngscript.nsyncQ|n)nsyncoI
gitnn) {es.scriptC.a self 			}ningscript.c.a self=es.scriptC.a selI
	 tl}/{ditngscript.src ={s.url	rornrgegll
A	ret. E doeerson l	allrbrf sersditngscript.onload= script.ont("dys	atecE dg r|;acce:nams _,{isAb  dQ 			}	}llay.is{isAb  dQme
!script.t("dyS	ateQme
/loaded|jomelet /catchsfscript.t("dyS	ateQ)Q 			}	}li		ggd H doe dmemory le krinontioa tngscript.onload= script.ont("dys	atecE dg r|;				e	}	}li		ged,ReeI:s GdeJscript
	attny.isnhead && script.pa widNod   		// ennnnhead.t(eI:sCeildsfscript
);gnattnl}/{ditngts usDhre,e wics	GdeJscript
	attnscript
|n| jQuer}dI/
isOnOrggd C;lbaal	if noG ab  dionnny.isJ!isAb  dQ 		// ennnnc;lbaal(=200, "succesu"
);gnattnj}// F		 }
	 tl};gnatt ll
U)e insidtBe, le ins	ead ofya f	 jCeild rGolcirteEv		elidont6;bug.iooas usTQue	drisisare syaJba)e ,cti islus/e (#2709iands#4378).ionnhead.insidtBe, lesfscript, head.fgrstCeild
);gn	 F},/{iot  ab  t:;acce:namse 		onnny.isfscript
) 		o tngscript.onload(= d 1sOI
	 tl}/{r j}// F};ioD

}OI/ io/ i issliggd #5280:onnt	rmelfElel ler )illrkeep	connee:namsly dv
	ifwe dac't ab  tooi unloadioDxhrOnUnloadAb  dQ=  lojow.ActiveXOt'sst ?;acce:namse 		orgll
Ab  d	allrf	 jlow

q		stsiiegn listsli keyQtn xhrC;lbaals	e 		onnixhrC;lbaals[Jkey ](= d 1sOeis jioD
 : );
	ddBixhrIdh = ,iBixhrC;lbaalsI/ iogd Fcce:namr	Go ct("di xhrsu acce:na ct("diS	andardXHRse 		otrytug}rg
	},
mew  lojow.XMLH tpR
q		st()I//		ckit.d } etu 
}/ u acce:na ct("diActiveXHRse 		otrytug}rg
	},
mew  lojow.ActiveXOt'sst( "Microsoft.XMLHTTP" )I//		ckit.d } etu 
}/ u gd Ct("di rh	

q		st{it'sstu gd (TQuefis
stnlloa	ret./e GolajaxSettlowson l	baalward jomea:nbi);Qy)iojQ		rt.ajaxSettlows.xhrQ=  lojow.ActiveXOt'sst ?ioa * Microsoft fril/e Gol		//erlh a * ime			leQ rh	
XMLH tpR
q		strinont7 (ckc't

q		st localuonl	s), a * sowe })}iGde ActiveXOt'sstare syitsueiavrilstil a * Adel:namaelhtXMLH tpR
q		st	ckmrbuldisstildrinont7/IE8 so a *we n;ed a a;lbaal. a */	o acce:nam"etudiierred;;!c,ir<ysLocal && ct("diS	andardXHRse || ct("diActiveXHRs)I//		:isO usFor ;ltoGdeirbrf sers, })}iGde s	andardtXMLH tpR
q		st it'sstritct("diS	andardXHRI/ iogd Det	rmin-csup/  tl		//erti
s//(acce:nam" xhr	e 		onjQ		rt.eli;id( jQ		rt.sup/  t, 		onoajax:t!!xhr,ionncors:t!!xhrQ&&isf" shrCt(j		li;
"Qtn xhr	)iBa}OI
}O( jQ		rt.ajaxSettlows.xhr() OI/ u gd Ct("di Grans/  toif taerbrf ser	ckmr		/vid s dtxhrgiif ( jQ		rt.sup/  t.ajaxQ 			}	}jQ		rtTajaxTrans/  t(acce:nam	 sf 			}nngd Ctoss daerinooilhtallowldrifcsup/  tldrtarfughtXMLH tpR
q		stiony.isf!s.crossDaerin || jQ		rt.sup/  t.corsf 			/gittssligc;lbaal;r
	iiierred;			}nnngs;id:;acce:nams head	rs, jomelet f 			/gittnngllbGetratmewtxhrgittttssligxhrQ= s.xhr(O,isOOOOOOE doee,isOOOOOOi;r
	iiies usOf	 iGde soalrl	iiies usPasulow 				user= fa, grrir"diutaslogimr	opupooisOfir" (#2865)iBatnn) {es.user= f   		// ennnxhr.of	 ({r</  ,rs.url,fs.nsync,es.user= f ,rs.cassword )I//	tn				--		// ennnxhr.of	 ({r</  ,rs.url,fs.nsync )I//	tnl}/{ditnrgll
A fuyocust mefiilds tf 		/vid d/Batnn) { s.xhrFiildu	eturnnnnnnnn listi in s.xhrFiildu	eturnnnennnxhr[	 i]l= s.xhrFiildu[	 i];gnattnj}//	tnl}/{ditnrglusO:erriee m mi t,
	i. n;ed/e
atnn) { r<m mi),sQ&&ixhr.o:errieeM mi),
	eturnnnennxhr.o:errieeM mi),
 r<m mi),s )I//	tnl}/{ditnrgll
X-R
q		stld-Wshrihead	rrniliO usFor cross-daerin

q		sts, seuing
auJc gdi:namsu, l a e(eolightra wrniliO usakin
Gola jigsaw puzzee,we simelytnehid settiroGo bu sulecrniliO us(it	ckmralways bu settomra fir-
q		stJba)it	 l ehii uulow ajaxSetup)rniliO usFor s f -daerin

q		sts, wac't cE dg ihead	r	i. nht("dy 		/vid dcrnilny.isf!s.crossDaerin &dh!head	rs["X-R
q		stld-Wshr"]	eturnnnennhead	rs[ "X-R
q		stld-Wshr"i]Q=n)XMLH tpR
q		st"I//	tnl}/{ditnrgll
N;ed an ;lrabtry/ckit.u, locross daerin

q		sts inxFi(eoox 3	}nn tryturnnnnnnnn listi in head	ru	eturnnnennnxhr.s
tR
q		stHead	r( i,=head	rs[	 i]l)	r/attnj}//	tn		ckit.d _	etu}/{ditnrgll
Do s;idrrh	J
q		strn   as usTQue	may rai)}ianr;cep:namaw.ft. ue	a//eaeuyrn   as usE doildrin jQ		rt.ajax (so ,cbtry/ckit.eaer )rnennnxhr.s;id( (rs.aauC gi;ilQ&&fs.dataf t|| 				f e//ditnrggd	Lisi;i	rrnilnnc;lbaalr|;acce:nams _,{isAb  dQ 			}	}llassli=s	atus,rnnnennns	atusT;d,dii naniespamsiHead	rs,dii naniespamsis,dii nanlxm	e	}	}li		ged,Fi(eoox tarf sr;cep:namsare syaccesulow 		//erti
s	}li		ged ofs dtxhrare syaJmelwork ;rr l	occuled	}li		ged v tp://helpful.knabs-di;
.jom/i jQx.php/ComeonleQ_rred;ed_frilule_jtr :_0x80040111_(NS_ERROR_NOT_AVAILABLE)rnennn tryturnrnennn ts usWkstnehidrcalild idd is ab  t d	 locomelet 	} ynn) {Jc;lbaalQ&&is{isAb  dQme
xhr.t("dyS	ata = |n4Q)Q 			}	}li	nrglusOnuyoc;led inc isOnilnnc;lbaalr|;| jQuer}dI/
isOnOnrgll
Do noGrkeep	aseactiv} idymor isOn ynn) {sE doil	eturnnnenennnxhr.ont("dys	atecE dg r|jQ		rtTnaop	rneOnynn) {sxhrOnUnloadAb  dQeturnnnenenn and	act}fxhrC;lbaals[sE doil	];gnattnjnj}//	tntnl}/{ditnrgrgelenf it't	rn ab  dionnnlay.is{isAb  dQeturnnnenenn all
Ab  d	itJmaneaeuy	i. n;ed/e
atnnnlay.is
xhr.t("dyS	ata ! |n4Qeturnnnennennnxhr.ab  Q();ioattnjnj}//	tntn				--		// ennnnn r	atush =xhr.s	atus;ritti naniespamsiHead	rsh =xhr.geQA		RespamsiHead	rs();ioattnnaniespamsis	=st;gnai nanlxm	h =xhr.respamsiXMLI/
isOnO enngd Cons
//// respamse  ist
atnnnlay.is
xml && xml.eateE		QE			leQ /*s#4958*/Qeturnnattnnaniespamsis.xm	h  xml;ioattnjnj}//	ttnnaniespamsis.i;t	==xhr.respamsiT;dI////	ttnnanged,Fi(eoox tarf sianr;cep:namare syaccesulow//	ttnnanged,s	atusT;du, lorefNoy cross-daerin

q		sts//	ttnnantryturnnnnnnennns	atusT;t	==xhr.s	atusT;t;ioattnjnj}	ckit.d } eturnnattnaolied Wedit by deft shr WebkitJgivlowianr;mpoy s	atusT;trnnnnnnennns	atusT;t	=="";ioattnjnj}////	ttnnanged,Fnlt	r	r	atusr, l itn s	andardtbeE viors////	ttnnangelenf c,} 
q		st	is local idd we E v 
data:oasseE	ea succesu//	ttnnangele(successt shronoJdata wac't geQ noGifild,ectet't c,} b	st we//	ttnnangel	ckmrdoygiv}nscur wid ime			leQa:nams)rnennn nny.isJ!r	atus && r<ysLocal && !s.crossDaerinOption ennnnn r	atush =espamsis.i;t	?=200 : 404;//	ttnnangelenE -s#1450: sofat missrred;sr1223are syid	shluld b	=204//	ttnnn				--	y.isns	atus =tar1223Option ennnnn r	atush =204;gnattnjnj}//	tntnl}/{tntnl}/{njnj}	ckit.d fi(eooxAccessEcep:namOption ennny.isJ!isAb  dQ 		// enn jomelete(=-1, fi(eooxAccessEcep:namOy//y=i		 j}// F		 j}/
isOnOrggd C;l jomelet fi. n;ed/e
 ennny.isirespamsis 		dBann jomelete(=s	atus, s	atusT;d, respamsis, espamsiHead	rsl)	r/attnj}//	tn	e//ditnrggdty. rF'rFtinsync mcti  l it'ttinijet.aditnrggdtidd aau b	 syre			ev d dir	/:uy	(nt6;&ont7)ditnrggdtwe n;ed toJmaneaeuy	fi(e c,} c;lbaal	}nnny.isJ!r.nsyncQme
xhr.t("dyS	ata = |n4Q 		dBannnc;lbaal()I//	tn				--		// ennnE doil	= ++xhrIdI//ynn) {sxhrOnUnloadAb  dQeturnnnenenngd Ct("di rh	eactiv} xhrs c;lbaals  ist y. n;ed/e
iiiinrggdtidd a	ret. rh	 unload E doeerion ennny.isJ!xhrC;lbaals	e 		onnnnnnnnxhrC;lbaals	=st;gna rriijQ		rt	  lojow
	TunloadsxhrOnUnloadAb  dOy//y=i		 j}// Fnnrgellbadd toJlist ofeactiv} xhrs c;lbaals// FnnrgexhrC;lbaals[sE doil	]	=ec;lbaal	r/attnj}//	tnnnxhr.ont("dys	atecE dg 	=ec;lbaal	r/ttnj}//	t F},/{iot   ab  t:;acce:namse 		oynn) {Jc;lbaalQ 		dBannnc;lbaal(0,1);
y=l
	
	 tl}/ i			eis jioD
)I
}/ io/ i isvari
			disblay	=st,iBn) r f ,r) r f Doc,iBnrfxt,
u	=e/^(?:togwle|shlw|hid )$/,iBnrfxnum	=e/^([+\-]=)?([\d+.\-]+)([a-z%]*)$/i,gitt mirId,gitfxA	rrsh =[	}nngd heightranimatnams// F[ "height"de)margimTop"de)margimBott m"de)padd	//Top"de)padd	//Bott m"s],ionngdt sdthranimatnams// F[ " sdth"de)margimLeft"de)margimRight"de)padd	//Left"de)padd	//Right"s],ionngdtopck;Qyranimatnams// F[ "opck;Qyo ]	n ],gitfxNowIouiijQ		rt.fn.eli;id(		o	shlw:;acce:namsls 	ld,eeaulow,{c;lbaaldetu	}r vari
			, disblay;r
	}ie!==sls 	ldQmels 	ldf= |n0f 		diiierred;{c,ir<animate( grrFx("shlw"de3),ls 	ld,eeaulow,{c;lbaald)	//n 
				--cuisOrgn listsli ih = , 'f {c,is< lengt		 i++j				iQ 		dBann
			f {c,is[	 i];	}rnrgie!==sl
			.s	yil	eturnnnenedisblay	=s
			.s	yil.disblay;r
	}ieac ed,Resetrrhi inlin-cdisblay of{c,isi
			leQ toJlea	n if it is	}ieac ed,buing
hidd sybyoc;scaded 	ueest l itt	}nnny.isJ!jQ		rt._data(
			,Q"alddisblay") &&cdisblay = |n)nace"	eturnnnnenedisblay	=s
			.s	yil.disblay	=="";ioat	 j}/
isOntts usSetu
			leQtaw.ft. E v  b	 syo:erried st shrodisblay: naceisOntts usins ts	yilsheeQ toaw.ate:errrh	 dhrefNorbrf serts	yil is	}ieac edu, l sut.s du
			let	}nnny.iscdisblay = |n)" &&fjQ		rt.css(
			,Q"disblay") = |n)nace"	eturnnnnenejQ		rt._data( 
			,Q"alddisblay", dhrefNoDisblay(
			<,ctigCai)re;
y=l
	
	 tl}/ i			//gitts usSet
rh	 disblay of{most oferh	u
			leQtains tsec gd laopgitts u
Golavoidrrhi cons	an/ reflowisOrgn lis ih = 		 i++j				iQ 		dBann
			f {c,is[	 i];	}rnrgie!==sl
			.s	yil	eturnnnenedisblay	=s
			.s	yil.disblay;r
	}ieac y.iscdisblay = |n)" meldisblay = |n)nace"	eturnnnnene
			.s	yil.disblay	==jQ		rt._data( 
			,Q"alddisblay"f t||n)";
y=l
	
	 tl}/ i			//gittg
	},
c,ireis jr
r glo	}ghid :;acce:namsls 	ld,eeaulow,{c;lbaaldetu	}r !==sls 	ldQmels 	ldf= |n0f 		diiierred;{c,ir<animate( grrFx("hid "de3),ls 	ld,eeaulow,{c;lbaal)	//n 
				--cuisOr vari
			, disblay,dii nih = ,dii n'f {c,is< lengt	//nsOrgn lis 		 i++j				iQ 		dBann
			f {c,is[i];rnrgie!==sl
			.s	yil	eturnnnenedisblay	=sjQ		rt.css( 
			,Q"disblay"f ;r
	}ieac y.iscdisblay ! |n)nace"	&& !jQ		rt._data( 
			,Q"alddisblay"f teturnnnnenejQ		rt._data( 
			,Q"alddisblay", disblayre;
y=l
	
	 tl}/ i			//gitts usSet
rh	 disblay of{rh	u
			leQtains tsec gd laopgitts u
Golavoidrrhi cons	an/ reflowisOrgn lis ih = 		 i++j				iQ 		dBanny.is{c,is[i].s	yil	eturnnnenec,is[i].s	yil.disblay	|n)nace";
	 tl}/ i			//gittg
	},
c,ireis jr
r glo	}g usSa:s GdeJald togwle acce:namiBa_togwle: jQ		rt.fn.togwleglo	}gtogwle: acce:namslfn,lfn2,{c;lbaaldetu	}r variboo	h  /  oflfn = |n)boolean";r
	}ie!== hjQ		rt.isFcce:namfn) &&fjQ		rt.isFcce:namfn2 teturnnnnc,is<_togwle.a fuys{c,is, argu	leQta)	//n 
				--c) {
fn
 | 				 ||iboo	teturnnnnc,is.eet.(acce:namse 		oynvar s	ate=iboo	t?
fn
: jQ		rt(c,is).is(":hidd s"e;
y=ljQ		rt(c,is)[ s	atet?
"shlw"
: "hid " ]()	/{r j)	//n 
				--cuisOrgc,ir<animate(grrFx("togwl "de3),lfn,lfn2,{c;lbaal I//r }//n tg
	},
c,irer
r glo	}gfati)o:;acce:namsls 	ld, to,eeaulow,{c;lbaaldetu	}ierred;{c,ir<onlt	r(":hidd s"e.css("opck;Qy"de0).shlw()+;id()ditnrg<animate({opck;Qy: to},ls 	ld,eeaulow,{c;lbaal)	r
r glo	}ganimate:;acce:nams 		//, s 	ld,eeaulow,{c;lbaaldetu	}r variop:;l	=sjQ		rt.s 	ld(ls 	ld,eeaulow,{c;lbaald)	//n 
!== hjQ		rt.isEmpoyOt'ssts 		//f teturnnnerred;{c,is.eet.(iop:;l.jomelet , [ );
  ]l)	r/ F}//	}rgll
Do noG cE dg ire,e wicsd 		//erti
s	rs fir-		//ertyeeaulow )illrbu last
at		//	=sjQ		rt.eli;id(st, 		//l)	r/dBanacce:namueaAnima:nam"etuditts usXXXe'c,is'uea
s	noGralways E v 
ai,ctigCaiare syrunn	//rrh	ditts usatch suir /
isOny.i(iop:;l.q		ua = | );
	 		//nenejQ		rt._marks{c,issOI
i			//isn  variop:	=sjQ		rt.eli;id(st,iop:;l	),dii nisE			leQf {c,isn,cti),
	=tar1,dii nhidd sf {isE			leQf&&fjQ		rt(c,is).is(":hidd s"),dii n= f},ende, 	,ee,dii nier es, s	a t, ;id, unid,dii nmethod;	}rnrrgel )ill s	or  fir 		//ertyeeaulow  dorbulus/e toodet	rmin-are syanranimatnam{isocomelet 	} op:<animatedP	//erti
s	=st	//nsOrgn lis p in 		//Q 			}	}llage 		//ertye= fedit by deatnamdii n= f}	=sjQ		rt.c f}lCas/( /Q ;rnrgie!==slp ! | = f   		// enn		//=t= fae]r= 		//=tp	];gnan and	act} 		//=tp	];gnan j}/
isOnttnder= 		//=t= fae]	rornrgeglleeaulowlresolu:nam: fir 		//ertye> op:<s 	/ia Eaulowe> op:<eaulowe> 'swlow' (dhrefNo)dittty.is jQ		rt.isArray({ndef teturnnn op:<animatedP	//erti
s=t= fae]r= nde[ 1f]I
	atttnder= 		//=t= fae]r= nde[ 0 ]eistn				--turnnn op:<animatedP	//erti
s=t= fae]r= op:<s 	/ia Eaulowf&& op:<s 	/ia Eaulow=t= fae] ||iop:<eaulow || 'swlow';gnan j}/
dittty.is nde	=ta "hid " && hidd s || nde	=ta "shlw"	&& !hidd s etudii jng
	}, op:<comelet  onhes{c,issOInan j}/
dittty.is{isE			leQf&&f	t= f}	=ta "height" ||t= f}	=ta " sdth"f teturnnn ggd Mcku sul	ected noGd	// sne ks o dgiieac ed,Record ;lt3yo:erflow a	rribuatcsbuna})}ontuea
s	nodgiieac ed cE dg irh	yo:erflow a	rribua-are syo:erflowX  dogiieac ed o:erflowY	r w	s/t	GooGde s f endef=rnnn op:<o:erflowh =[{c,is.s	yil.o:erflow,{c,is.s	yil.o:erflowX,{c,is.s	yil.o:erflowYe]	rornrgets usSet disblay 		//ertyeGooinlin--bloalt, lnheight/ sdthrnrgets usanimatnams inoinlin	u
			leQtected r w E v	//  sdth/heightranimat/e
atnn) { jQ		rt.csss{c,is,Q"disblay"f 	=ta "inlin	o && iaaaaaaajQ		rt.csss{c,is,Q"float" ) = |n)nace"	eturnisOnOrggdoinlin--le:elu
			leQtencceptoinlin--bloal;isOnOrggdobloal-le:elu
			leQten;ed toJbi inlin-t shrolayo dgiieac y.isJ!jQ		rt.sup/  t.inlin-BloalN;edsLayo d || dhrefNoDisblay({c,is.,ctigCaif 	=ta "inlin	oteturnnn Orgc,ir.s	yil.disblay	|n)inlin--bloal";r
	}ietn				--turnnn Orgc,ir.s	yil.zoo	f {1I//=i		 j}// F		 }
	 tl}/{r j}//isOny.i(iop:<o:erflowt!| 				teturnnn c,is.s	yil.o:erflow	|n)hidd s"I
i			//isOrgn lis p in 		//teturnnn }	=tmewtjQ		rt.fxs{c,is,Qop:, /Q ;rnrgitnder= 		//=tpi];	}rnrgie!==slrfxt,
ucatch({ndef teturnrn   as usTraalsare GdeirtoJshlwt l hid Jba)ed in 		ivat/rn   as usdataoa	ret./e GooGde 
			let	}i nmethod	==jQ		rt._data( c,is,Q"togwl " + /Q  ||is nde	=taQ"togwl " ? hidd s ?
"shlw"
: "hid " := 
);gnattny.isnmethodteturnnn OrjQ		rt._data( c,is,Q"togwl " + /,nmethod	=ta "shlw"	? "hid " :="shlw"	Oy//y=i		 e[nmethod	]()I//	tn				--		//y=i		 e[ nde	]()I//	tn			//isOrg				--		//y=iniea ts = rfxnumm( ec" nde	Oy//y=i		s	a t =   our( ;r
	}ieac y.iscea ts	eturnnnnene
nd	=cea siFloat(epa ts[2]l)	r/attnjunit =epa ts[3] ||{ jQ		rt.cssNumbsr=tpi]	? "" :="px"f ;r
	}ieolied Wedn;ed toocomeua-as	a t	// ndef=rnnieac y.iscunit ! |="px"	eturnnnne OrjQ		rt.s	yil( c,is,Q/,n(
nd ||{1Op+cunit)	r/attn		s	a t = (n(
nd ||{1Op/   our( 	et*as	a t;rnnnne OrjQ		rt.s	yil( c,is,Q/,ns	a t +cunit)	r/attn			//isOrgnnelenf af+|/- {cok=nfwat			/vid d, rF'rFteo	//
airelativ}sanimatnamrnnieac y.i(epa ts[1]	eturnnnenene
nd	=c(n(pa ts[ 1]f  |n)-="	? -1 :=1et*a
nd	Op+as	a t;r/attn			//isOrgnne.cust m( s	a t, ;id, unidf ;r
	}ieog				--		isOrgnne.cust m( s	a t,ende, ""re;
y=l
	
	 tl}/ i			//gitts usFor JS u			cl jomelianc rnnnerred;{c// I//r }//n tg
	},iop:;l.q		ua = | );
	?rnnnnc,is.eet.(ueaAnima:nam	e :rnnnnc,is.q		ua(iop:;l.q		ua,ueaAnima:nam	)	r
r glo	}gs	op: acce:nams / a,uclearQ		ua,ug/toEndteturnny.ise/  ofe/  r! |n)u			//oJeturnilg/toEndt=uclearQ		ua;
y=clearQ		ual= t,
I//r jt,
f|n| jQuer}dI// F}rnny.iseclearQ		ua&& /   ! | );
   		rnnnnc,is.q		ua(it,
tme
)fx", []	eI//r }//n tg
	},ic,is.eet.(acce:namse uisOr varii jQx,dii nhadT mirs = );
	,dii nt mirs	==jQ		rt.t mirs,// etsdata	==jQ		rt._data( c,isre///gitts ueclear marker{cougi;rsty. rF knawoGdey wac't bedBany.isf!g/toEndteturnnOrjQ		rt._unmarks{crua,{c,issOI
i			//isn nacce:namus	opQ		ua( 
			,Qdata,ii jQxJeturnnlsli hools	=Qdata[ii jQxJ];
y=ljQ		rt.t(eI:sData( 
			,ii jQx,{crus )I//	tnhools.s	op(ug/toEndteI
i			//isn y.ise/  
 | 				 etugn nign lisii jQxii rdata	e 		}ieac y.isQdata[ii jQxJ]&&Qdata[ii jQxJ].s	op&&Qi jQx.i jQxOf(".run") = |ni jQx< lengt -n4Q 		dBannns	opQ		ua({c,is,Qdata,ii jQxJe;
y=l
	
	 tl}/ i						--	y.isQdata[ii jQxJ= t,
	+h".run"J]&&Qdata[ii jQxJ].s	op)	dBnns	opQ		ua({c,is,Qdata,ii jQxJe;
y=	//isOrgn lisii jQxJ= t mirs< lengt		i jQx--;Q 		dBanny.is t mirs[ii jQxJ].
			 = |{c,isf&&f	t,
	 | 				 || t mirs[ii jQxJ].q		ua = | t,
)	e 		}ieac y.isQg/toEndteturn	}ieac ggdQ, lc  Gde ieliJsi;p toJbi GdeJlas		}ieac gt mirs[ii jQxJ]s{crua )I//	tn				--		// ennnt mirs[ii jQxJ].sav}S	ate(e;
y=l
	
	i nhadT mirs = c// I//rnnnt mirs+/ );cesii jQxd 1sOeis jtl}/ i			//gitts u s	a t Gde ieliJiniGd=tq		ua	y. GdeJlasiJsi;p watc'tQ, lc dgitts u t mirs nur 		ely )ill{c;l Gdeilocomelet  c;lbaals,aw.ft. )ill{deq		uagitts u butooilh	y. Gdey )e wQg/toEnddBany.isf!sQg/toEndt&&fhadT mirs e 		//  egjQ		rt.deq		ua({c,is, t,
r I//r j}// j)	//j}//
}OI/ iogd Anima:nams ct("didsyncarfnously )ill{runsyncarfnouslyu acce:na ct("diFxNowse uisOs
t) mio dseclearFxNow,= 
);gng
	},i
fxNow =jQ		rtTnaw(	
);
}/ u acce:na clearFxNowse uisOfxNow =| jQuer}dI
}/ u gd Grrir"di{er amet	rr	Go ct("di a s	andardtanimatnamr acce:na grrFxs / a,unum 		// sli it'	=st	//nsgjQ		rt.eet.({fxA	rrs.concki.a fuys[]d{fxA	rrs.s);cesi0,unum ),lacce:nam	etuiooit'[{c,isf]l= t,
I//j)	//gng
	},iit'I
}/ u gd Grrir"di{shlrtcu:sr, l cust mranimatnams//jQ		rt.eet.(uios);d Down: grrFxs="shlw"d 1sO,ios);d Up: grrFxs="hid "d 1sO,ios);d Togwl : grrFxs="togwl "d 1sO,iogfatiIn: {topck;Qy:="shlw"	},iogfatiOut: {topck;Qy:="hid "	},iogfad Togwl : {topck;Qy:Q"togwl "  
},lacce:nam	t= f}, 		//s	eturnnjQ		rt.fn=t= fae]r=;acce:namsls 	ld,eeaulow,{c;lbaaldetu	}r rred;{c,ir<animate( 		//s,ls 	ld,eeaulow,{c;lbaald)	//		e
}OI/ //jQ		rt.eli;id(		o	s 	ld:;acce:namsls 	ld,eeaulow,{fs etudii variop:	=ls 	ld&& /  ofls 	ldf  |n)it'ssto?sjQ		rt.eli;id(st,ls 	ld	e :		//  ejomelet asfs me
!fs && eaulow || iat rjQ		rt.isFcce:namls 	ld	e &&ls 	ld,dBaniduratnam:ls 	ld,dBanieaulowasfs && eaulow || eaulow	&& !jQ		rt.isFcce:nam eaulow	) && eaulowis jv//	} op:<duratnam =tjQ		rt.fx.off?s0 : /  oflop:<duratnamf  |n)numbsro?lop:<duratnam :rnnnnop:<duratnam intjQ		rt.fx.s 	lds?ljQ		rt.fx.s 	lds[lop:<duratnam ] :ljQ		rt.fx.s 	lds._dhrefNoI
gits usit by def op:.q		ua - c// /| jQuer}d/				 ->
)fx"rnny.iseop:.q		ua  | 				 ||eop:.q		uaQ= |l
//   		// enop:.q		uaQ=
)fx"	r/ F}//	}rgll
Q		ualowisenop:.ald = op:<comelet I
gitsop:<comelet r=;acce:namssitUnmark 		dBany.isfjQ		rt.isFcce:nam op:.ald e 		//  enop:.ald onhes{c,issOIna F}//	}rny.iseop:.q		ua  		//  egjQ		rt.deq		ua({c,is,eop:.q		uasOIna F				--	y.issitUnmark ! | );
 teturnnOrjQ		rt._unmarks{c,issOIna F}// jv//	} 
	},iop:	r
r glo	}ieaulowaturnnlin-ar:;acce:nams 	,un,JfgrstNum, dif,teturnnnerred;{fgrstNum + dif,t* p	rneO,iBacswlow:;acce:nams 	,un,JfgrstNum, dif,teturnnnerred;{( (r-Mkih<coss 	*Mkih<PI Op/ 2	Op+a0.5	et* dif,t+JfgrstNumeis jr
r glo	}nt mirs:;[]ddBisOfx:;acce:nam( 
			, op:nams,h		//teturnnnc,is.op:nams = op:nams;rnnnc,is.
			 = 
			;rnnnc,is.		//r= 		//I
gitsop:nams.o		g = op:nams.o		g ||st	//j}//
}OI/ iojQ		rt.fx.		/tot,
	 turnn usSimele acce:namr, l settlows ts	yi endef=rnn|pdate:;acce:nam(eturnny.ise,is.op:nams.s	e/teturnnn,is.op:nams.s	e/ onhes{c,is.
			,{c,is.,ow,{c,is	eI//r }//n tg(ljQ		rt.fx.s	e/[ c,is.		//r] ||{jQ		rt.fx.s	e/._dhrefNo )s{c,issO	r
r glo	}gllbGetrrhi cur wid sdeeiolcur:;acce:nam(eturnny.is{c,is.
			[ c,is.		//r]t!| 				&& (!c,is.
			.s	yil	||{c,is.
			.s	yil[ c,is.		//r]  | 				 teturnnnerred;{c,is.
			[ c,is.		//r]I//r }//n i varcea sld,dBanir	=sjQ		rt.csss{c,is.
			,{c,is.		//l)		}rged,Empoy s	rlows, 				,| jQuer}d  dor"ruto" r i conhidt	d too0,ionngdtcomelexendef=s sut.s s "ro	ate(1rae)" r i rred;eds s is,ionngdtsimeleendef=s sut.s s "10px" r icea s	d tooFloat.	} 
	}, isNaN(cea s	d =cea siFloat(er e 	?f!rlmee	Q= |r"ruto"?s0 : r : ea s	d	r
r glo	}gllb		a tyanranimatnamst
 on	 numbsr	Go anoGdei	}gcust m:;acce:nam(st
,	Go, unidl)tuditsli selff {c,is,ionnOfx =tjQ		rt.fxI/ io c,is.s	a t) mi =tfxNowlme ct("diFxNowse;rnnnc,is.
nd	=	Go;rnnnc,is.now =c,is.s	a t =st	;rnnnc,is.	os =c,is.s	ate=i0;rnnnc,is.unit = unidlme c,is.unit ||{ jQ		rt.cssNumbsr[ c,is.		/pi]	? "" :="px"f ;r
	}inacce:namutsQg/toEndteturnnnerred; self.s	e/sQg/toEndteI//r }//n tg:.q		uaQ=
,is.op:nams.q		ua;rnnnc.
			 ={c,is.
			;rnnnc.sav}S	ate =sacce:nams 		dBany.is self.op:nams.hid &&=jQ		rt._datas self.
			,{)fxshlw"	+ self.		//l) = |n| jQuer}OptionnnnjQ		rt._datas self.
			,{)fxshlw"	+ self.		//, self.s	a tsOIna F}// jv//rnny.is{cs 	&&=jQ		rt.t mirs+push(t 	&&=!t mirIOptionnnt mirIr= s
tnnt	rnde({fx.t al,{fx.int	rndeteI//r }r
r glo	}g usSimele 'shlw'sacce:nam	o	shlw:;acce:nams)tuditsli dataShlw	==jQ		rt._data( c,is.
			,{)fxshlw"	+{c,is.		//l)		/	}rggexR
membsr	waer sw-as	a tld,fsoectedsw-	ckmQg/Jbaal	Go it lat	rrnnnc,is.op:nams.o		g[ c,is.		//r]   dataShlw	||{jQ		rt.s	yils{c,is.
			,{c,is.		//l)	rnnnc,is.op:nams.shlw = c// 		/	}rggexBeginiGd=sanimatnamrnnigd Mcku sul	ected w-as	a t ed  tsmnhe  sdth/height
Golavoidridyoflash of c gi;idrnny.is dataShlw	! |n| jQuer}Optionas usTQue	shlw ue	p allowsup	waer sa c(uviousehid or	shlw left offrnnn,is.cust m( ,is.cur(O, dataShlw	 er

				--curnnn,is.cust m({c,is.		//	=ta " sdth"lme c,is.		//	=ta "height" ? 1s:= d ,is.cur(OteI//r }//n tgllb		a tyby	shlwlowoGde 
			let	}ijQ		rt	 c,is.
			 ).shlw();r
r glo	}g usSimele 'hid 'sacce:nam	o	hid :;acce:nams)tu	}rggexR
membsr	waer sw-as	a tld,fsoectedsw-	ckmQg/Jbaal	Go it lat	rrnnnc,is.op:nams.o		g[ c,is.		//r]   jQ		rt._data( c,is.
			,{)fxshlw"	+{c,is.		//l)	||{jQ		rt.s	yils{c,is.
			,{c,is.		//l)	rnnnc,is.op:nams.hid  = c// 		/	}rggexBeginiGd=sanimatnamrnni,is.cust m( ,is.cur(O, 0sO	r
r glo	}gllbEet.Jsi;p ofs dsanimatnamrnnsi;p:;acce:namsQg/toEndt)tuditsli 	,un,Jjomelet ,rnnn =tfxNowlme ct("diFxNowse,gingeac  = c// ,ging
			 ={c,is.
			,gingop:nams = c,is.op:namsv//rnny.isQg/toEndtme c >= op:nams.duratnam	+{c,is.s	a t) mit)tuditnnc,is.now =c,is.end	r
rnnc,is.	os =c,is.s	ate=i1	r
rnnc,is.|pdate( ;r
	}ieaop:nams.animatedP	//erti
s[ c,is.		//r] = c// 	//isOrgn lis p in op:nams.animatedP	//erti
sQ 		dBanny.is op:nams.animatedP	//erti
s[ /r] ! |l
//   		// engeaca = );
		
	 tl}/{r j}//isOny.i(ieac   		// e ed,Resetrrh	yo:erflowdBanny.is op:nams.o:erflowt!| 				&&J!jQ		rt.sup/  t.shrlokWrapBloalsf 			/gitt egjQ		rt.eet.(J[ ""de)X"de)Y"s],;acce:namsii jQxdendef=	eturnnnnene
			.s	yil[ "o:erflow"	+endef=	] = op:nams.o:erflow[ii jQxJ];
y= j)	//jr j}//isOn	ggd Hid  Gde 
			letoif tae="hid "	//eratnam	watreacerneOny.is op:nams.hid=	eturnnnnijQ		rt	 
			 ).hid=()	//jr j}//isOn	ggd Resetrrh	y		//erti
s,oif taetir c aau b	 syhidd sor	shlwnrneOny.is op:nams.hid=	me op:nams.shlw	eturnnnOrgn lis p in op:nams.animatedP	//erti
sQ 		dBannOrjQ		rt.s	yil( 
			,{	,uop:nams.o		g[ pi]l)	r/att=ljQ		rt.t(eI:sData( 
			,{)fxshlw"	+{p,{crus )I/}ieac ggdQTogwl  datasit	nd lodg r n;ed/er/att=ljQ		rt.t(eI:sData( 
			,{)togwl " + p,{crus )I/}ieac }//jr j}//isOn	ggd E ecu:  Gde jomelet sacce:nam	sOn	ggd iniGd={evleQected Gde jomelet sacce:nam tarf sianr;cep:nam	sOn	ggdsw-	must ;isuletir wac't beoc;led tw;ce. #5684//isOn	gjomelet  = op:nams<comelet IrneOny.is jomelet f 			/gittnngop:nams<comeleta = );
		
	    comelet  onhe	 
			 );
	 tl}/ i			//gittg
	},
);
		
r

				--cugitts ueclasulonh eaulow	ckmnoGrbulus/et shroanonnuer;Qyrduratnamgitny.is op:nams<duratnamf  onnuer;Qyr 		dBannnc,is.now =c;n 

				--cuinannn =c -{c,is.s	a t) m		
	   c,is.s	ate=in / op:nams<duratnam	
gpyaoge tPerft b Gde eaulow	acce:nam, dhrefNor	Go swlow
	   c,is.	os =jQ		rt.eaulow= op:nams.animatedP	//erti
s[c,is.		//]J]s{c,is.s	ate,un,= d 1, op:nams<duratnam );
	 nnc,is.now =c,is.s	a t +{( (c,is.end -{c,is.s	a tet* c,is.	os OIna F}//aoge tPerft b Gde ieliJsi;p ofiGd=sanimatnamrnnnnc,is.|pdate( ;r
			//ginerred;{c// I//r 
}I/ //jQ		rt.eli;id(tjQ		rt.fx, 		ont al:;acce:nams)tuditsli t mir,gi nt mirs	==jQ		rt.t mirs,// nih = I/ //rgn lis 		 i+ t mirs< lengt				if 		gi nt mirJ= t miru[	 i];gnatted C valt c,} t mirJhat	ndt nht("dy b	 syt(eI:sddBany.isf!t mirs 	&& t miru[	 i]f  = t mirf 		gi nt mirs+/ );cesii--d 1r I//r j}// F}//	}ry.isf!t mirs< lengtf 		gi jQ		rt.fx.s	op(eI//r }r
r glo	}gint	rnde:=13glo	}gs	op: acce:nams 		gi=clearnnt	rnde({t mirIreI//r t mirIr|;				er
r glo	}gs 	lds:ptiongsllw:;600,ionnfast: 200,ionnlusDhrefNo	s 	ldionn_dhrefNo: 400r
r glo	}gsi;p:ptiongopck;Qy:;acce:nam(sxJeturnnjQ		rt.s	yil(sx.
			,{)opck;Qy"desx.nlw	 er

	glo	}nn_dhrefNo:;acce:nam(sxJetudBany.isfsx.
			.s	yil	&&fsx.
			.s	yil[fsx.		//r]t!| 				f 		gi nsx.
			.s	yil[fsx.		//r]t=esx.nlw	+esx.unic;n 

				--cuinansx.
			[fsx.		//r]t=esx.nlw;n 

	is jioD

}OI/ iollbadds  sdth/height
si;p acce:namsioll
Do noG setridyGd	// b	lowt0//jQ		rt.eet.([ " sdth"de)height"s],;acce:namsii,h		//teturnnjQ		rt.fx.s	e/[ 		//r]t=escce:nam(sxJetudBjQ		rt.s	yil(sx.
			,{		//, Mkih<max(0desx.nlw)	+esx.unicd)	//		e
}OI/ //y.isfjQ		rt.eler &&fjQ		rt.eler<onlt	rsQ 		dBajQ		rt.eler<onlt	rs.animatedt=escce:nam	 
			 etudiierred;JjQ		rt.gre/sjQ		rt.t mirs, acce:namslfnteturnnnerred; 
			 = |lfn.
			;rnnn})< lengt	//		e
}/ // us)tylGolres	or  rh	 dhrefNt disblay ndef=	ofs du
			let	}acce:nam dhrefNoDisblay({,ctigCaif 			/giy.isf!
			disblay[{,ctigCaif]	eturn	}r varibody = eateE		e.body,ging
			 ={jQ		rt	 "<" +{,ctigCaif+h">" ).a f	 jTo(ibody e,gienedisblay	=s
			.csss{"disblay"f ;r
ng
			.t(eI:e( ;r
	}ieelenf c,} simeleeway frils,ionngdtgetu
			leQ'ttt("l dhrefNt disblay byoa	retd	// it
Gola r cpr) r f 	}ry.isldisblay = |n)nace" meldisblay = |n)"Optionas usNor) r f 
Go })}iyet,eso ct("di itdBany.isf!) r f f 		gi n) r f  = eateE		e.ct("diE			leQ( ") r f "f ;r
 n) r f . r f BordirJ= ) r f . sdthJ= ) r f .height=i0;rnn			//gittgbody.a f	 jCeilds ) r f re///gittsgd Ct("di aijet.astie jopy of{rh	 ) r f reateE		e o{fgrstoc;l.gittsgd ntu dosOfir" )illtallow })lGolre})}iGder) r f Doct shro dlre-writlowoGde fcku HTMLgittsgdreateE		e Golic; WebKiQf&,Fi(eoox wac'ttallowlre})lowoGh	 ) r f reateE		e.dBany.isf!) r f Doc mef!) r f .ct("diE			leQf 		gi n) r f Doc = s ) r f .c gi;idWlojow
mef) r f .c gi;idDateE		e ).eateE		e;gi n) r f Doc.writl((reateE		e.jomea:Mod}	=ta "CSS1Comea:"	? "<!eatt,
	html>" :n)"Op+ "<html><body>" );gi n) r f Doc.clase( ;rnn			//ging
			 ={) r f Doc.ct("diE			leQ({,ctigCaire///gitts) r f Doc.body.a f	 jCeilds 
			re///gienedisblay	=sjQ		rt.css( 
			,Q"disblay"f ;r
ttgbody.t(eI:eCeilds ) r f reI//r }//n tgllb		or rrh	icor(uct dhrefNt disblayn tg
			disblay[{,ctigCaif]	= disblayI// }	o	}grred; 
			disblay[{,ctigCaif]I
}/ io/ i isvarirtstie	=e/^t(?:stie|d|h)$/i,gitrr ot	=e/^(?:body|html)$/iI/ //y.isf"getBou jlowClileQRsstoin eateE		e.eateE		QE			leQ	eturnnjQ		rt.fn.offsett=escce:nam	 op:nams )tuditsli 
			 ={c,is[0],iboxv//rnny.i	 op:nams )tuditg
	},ic,is.eet.(acce:nams iOptionnnnjQ		rt.offset.s
tOffset({c,is, op:nams,hir I//r j}eI//r }//n tgy.isf!
			 mef!
			.lwnerDateE		e )tuditg
	},;				er/r }//n tgy.is 
			 = |l
			.lwnerDateE		e.body )tuditg
	},;jQ		rt.offsee.bodyOffsets 
			re///r }//n tgtryturnnnnbox	=s
			.getBou jlowClileQRsst( ;rnj}	ckit.de)tu}//n i var eat |l
			.lwnerDateE		e,gingeacE			 = eat.eateE		QE			leQI/	}nigd Mcku sul	 rF'rFtnoGteeallowt shroa disconnee:edtDOM{,ctin tgy.isf!box mef!jQ		rt.c giatrs( eacE			, 
			re )tuditg
	},;box ? {t	op: box.	op, left: box.left 	: {t	op: 0, left: 0 	eis jrn	}r varibody = eat.body,ging lo = gedWlojow(eate,gieneclileQT//r = eacE			.clileQT//r meibody.clileQT//r mei0,gieneclileQLeft = eacE			.clileQLeft meibody.clileQLeft mei0,gienescrollT//r =  lo.cageYOffset || jQ		rt.sup/  t.boxMod}	&&JeacE			.scrollT//r meibody.scrollT//,gienescrollLeft =  lo.cageXOffset || jQ		rt.sup/  t.boxMod}	&&JeacE			.scrollLeft meibody.scrollLeft,gi nt//r = box.	op p+ scrollT//r - clileQT//,gieneleft = box.left + scrollLeft - clileQLefQI/	}rg
	}, {t	op: 	op, left: left 	//j}I/	}				--turnnjQ		rt.fn.offsett=escce:nam	 op:nams )tuditsli 
			 ={c,is[0]v//rnny.i	 op:nams )tuditg
	},ic,is.eet.(acce:nams iOptionnnnjQ		rt.offset.s
tOffset({c,is, op:nams,hir I//r j}eI//r }//n tgy.isf!
			 mef!
			.lwnerDateE		e )tuditg
	},;				er/r }//n tgy.is 
			 = |l
			.lwnerDateE		e.body )tuditg
	},;jQ		rt.offsee.bodyOffsets 
			re///r }//n tgsliocomeua-dS	yil,gieneoffseePa wid |l
			.offseePa wid,isOr c(uvOffseePa wid |l
			,isOr eat |l
			.lwnerDateE		e,gingeacE			 = eat.eateE		QE			leQ,gingbody = eat.body,gingdhrefNtView = eat.ehrefNtView,isOr c(uvComeua-dS	yil = dhrefNtView ? dhrefNtView.getComeua-dS	yil( 
			, 				f 	:l
			.cur widS	yil,gi nt//r|l
			.offseQT//,gieneleft = 
			.offseQLefQI/	}rgw.fil ((
			 = 
			.pa widNod  	&& 
			 ! |lbody	&& 
			 ! |leacE			  		dBany.isfjQ		rt.sup/  t.fixedPosi:nam	&& c(uvComeua-dS	yil.	ositnamf  |n)fixed"Optionassbt("kI//=			//gingcomeua-dS	yil = dhrefNtView ? dhrefNtView.getComeua-dS	yil(
			, 				 	:l
			.cur widS	yil;gi nt//r -= 
			.scrollT//;gieneleft -= 
			.scrollLefQI/	}rtgy.is 
			 = |loffseePa widOptionass	op p+= 
			.offseQT//;gieeneleft += 
			.offseQLefQI/	}rany.isfjQ		rt.sup/  t.ea
sNotaddBordir&&J!(jQ		rt.sup/  t.ea
saddBordirForTstieA jCells&&irtstiecatch(
			<,ctigCai)e )tuditgss	op p+= ea siFloat(ecomeua-dS	yil.bordirT//WsdthJl)	||i0;rnneeneleftp+= ea siFloat(ecomeua-dS	yil.bordirLefQWsdthJ)	||i0;rnn=			//ginr c(uvOffseePa wid |loffseePa wid;rnneneoffseePa wid |l
			.offseePa widI//=			//gBany.isfjQ		rt.sup/  t.subtractsBordirForO:erflowNotVisibil	&&fcomeua-dS	yil.o:erflowt! |n)visibil"Optiogss	op p+= ea siFloat(ecomeua-dS	yil.bordirT//WsdthJl)	||i0;rnneenleftp+= ea siFloat(ecomeua-dS	yil.bordirLefQWsdthJ)	||i0;rnn=		//isOr c(uvComeua-dS	yil =ecomeua-dS	yiler/r }//n tgy.is c(uvComeua-dS	yil.	ositnamf  |n)relative" me c(uvComeua-dS	yil.	ositnamf  |n)static"Optiogss	op p+=ibody.offseQT//;gieneleft +=ibody.offseQLefQer/r }//n ny.isfjQ		rt.sup/  t.fixedPosi:nam	&& c(uvComeua-dS	yil.	ositnamf  |n)fixed"Optionas	op p+= Mkih<max(JeacE			.scrollT//,ibody.scrollT// );gieneleftp+= Mkih<max(JeacE			.scrollLeft,ibody.scrollLeftre///r }/	}rg
	}, {t	op: 	op, left: left 	//j}I/}/ //jQ		rt.offsett=eurn	}rbodyOffset:;acce:nam(body )tuditsli 	op =ibody.offseQT//,gieneleft = body.offseQLefQI/	}ny.isfjQ		rt.sup/  t.ea
sNotInclueeMargimInBodyOffsetOptionas	op p+= ea siFloat(sjQ		rt.css(bodyde)margimTop")J)	||i0;rneneleftp+= ea siFloat(sjQ		rt.css(bodyde)margimLefQ")J)	||i0///r }/	}rg
	}, {t	op: 	op, left: left 	//j}glo	}gs
tOffset:;acce:nam( 
			, op:nams,hi )tuditsli 	ositnamf sjQ		rt.css( 
			,Q"	ositnam"l)		/	}rggexset 	ositnamffgrst,hin-ca)}i	op/left	r w	s/t ehii amfstatic 
			n tgy.is cositnamf  |n)static"Optiogss
			.s	yil.	ositnamf|n)relative"///r }//n tgsliocurE			 = jQ		rt	 
			 ),gienecurOffset=ocurE			.offsee(),gienecurCSSTopf sjQ		rt.css( 
			,Q"	op" ),gienecurCSSLefQf sjQ		rt.css( 
			,Q"left" ),gienecalculat	Positnamf|ns cositnamf  |n)absolu:e" me 	ositnamf  |n)fixed") &&fjQ		rt.inArray("ruto", [curCSSTop, curCSSLefQ])e> -1,dii 		//s	=st, curPositnam	=st, curTop, curLefQ		/	}rggexn;ed toJbi stie toJcalculat	 	ositnamfy.ieiGdeirtop or left it	rutou dos	ositnamfysieiGdeirabsolu:e or fixedn tgy.is calculat	PositnamfOptiogsscurPositnam	=ocurE			.	ositnam( ;rnn		curTop	=ocurPositnam.t//;gienecurLefQ	=ocurPositnam.lefter

				--curnnn	curTop	=oea siFloat(scurCSSTopf)	||i0///rnecurLefQ	=oea siFloat(scurCSSLefQJ)	||i0///r }/	}ny.isfjQ		rt.isFcce:nam	 op:nams )tOptiogssop:nams = op:nams onhe	 
			,ii,hcurOffseteI//r }//n tgy.isfop:nams t//t!| 				f 		dii 		//s t//t=isfop:nams t//t-hcurOffset t//tOp+ curTopI//r }n tgy.isfop:nams left !| 				f 		dii 		//s left = sfop:nams leftt-hcurOffset lefttOp+ curLefQer/r }//n ny.isf"})lowoin op:nams )tuditgop:nams })low onhe	 
			, 		//s	eer

				--curnnn	curE			.csss 		//s	eer

	//r 
}I/ ouiijQ		rt.fn.eli;id(		o//r	ositnam:;acce:nam(eturnny.is{!c,is[0] )tuditg
	},;				er/r }//nitsli 
			 ={c,is[0],//nitgllbGetr*t("l*loffseePa widnitgoffseePa weQf {c,isnoffseePa weQ(),//nitgllbGeticor(uctloffseesnitgoffsee        {c,isnoffsee(),gienpa widOffset=orr otcatch(offseePa weQ[0]<,ctigCai)r? {t	op: 0, left: 0 	 :loffseePa widnoffsee()		/	}rggexSubtract 
			letomargimsgits usitte:are syan 
			letJhatomargim:	rutorrh	ioffseQLefQu dosmargimLefQgits usa woGde s f ein Safdri ca})lowooffset lefteGooincor(uctlyJbi 0nitgoffsee.t//r -= ea siFloat(sjQ		rt.css(
			de)margimTop")J)	||i0;rnenoffset left -= ea siFloat(sjQ		rt.css(
			de)margimLefQ")J)	||i0///rneellbadd offseePa weQfbordirsgienpa widOffset.	op p+= ea siFloat(sjQ		rt.css(offseePa weQ[0]de)bordirT//Wsdth")J)	||i0/gienpa widOffset leftp+= ea siFloat(sjQ		rt.css(offseePa weQ[0]de)bordirLefQWsdth")J)	||i0		/	}rggexSubtractoGde lwoloffseesniierred;			}nnn	op:  offsee.t//r - pa widOffset.	op,gieneleft:ooffset left - pa widOffset leftgien	//j}glo	}goffseePa weQ:;acce:nam(eturnng
	},ic,is.map(acce:namse uisOr varioffseePa weQf {c,isnoffseePa weQ	|| eateE		e.body	//jrgw.fil (offseePa weQ&& (!rr otcatch(offseePa weQ<,ctigCai)&&sjQ		rt.css(offseePa weQ,Q"	ositnam")f  |n)static"e 		//  enoffseePa wid |loffseePa wid.offseePa widI//=			//tg
	},;offseePa widI//=j)	//j}//)	/// u gd Ct("di scrollLefQu do scrollT//nmethodsnijQ		rt.eet.(J["Left"de)Top"],;acce:namsii,h= f   		// varimethod	=="scroll" +h= f 	//rnnjQ		rt.fn=imethod	]t=escce:nam(ndedetu	}r vari
			,  loI/	}ny.i(nde = |n| jQuer}Optionn
			f {c,is[	0i];	}rnrgiy.isf!
			Optionng
	},;				e//=			//ging lo = gedWlojows 
			re///gin	ggd R
	},ic,i scroll;offsee//tg
	},; lo ? ("cageXOffsetoin  lo)r?  lo[	 	? "cageYOffset" :n"cageXOffseto] :ionngjQ		rt.sup/  t.boxMod}	&&  lo.eateE		e.eateE		QE			leQ=imethod	] || iatng lo.eateE		e.body=imethod] :ionng
			=imethod]er/r }//nits usSetic,i scroll;offseen tg
	},ic,is.eet.(acce:namse uisOr  lo = gedWlojows{c,issO	r
rnrgiy.isf lo e uistng lo.scrollT/( iatng! 	?nde :ljQ		rtsf lo e.scrollLeft(O,isOOOOO  	?nde :ljQ		rtsf lo e.scrollT//()ditnrO	r
r 

				--cuinanc,is[	method	]t=ndeI//r j}// j)	//j}e
}OI/ //acce:nam gedWlojows 
			recuing
	},fjQ		rt.isWlojows 
			re?rnnn
			r:rnnn
			n,cti),
	=tar9?rnnnn
			ndhrefNtView || 
			.pa widWlojow :ionn);
		
}/ io/ i i gd Ct("di  sdth,nheight,hinnerHeight,hinnerWsdth,no derHeighQu do o derWsdthnmethods//jQ		rt.eet.([ "Height"de)Wsdth" ],;acce:namsii,h= f   		//// varit,
	 h= f .	oLo)e Cas/(O	r
r gd innerHeighQu do innerWsdthrnnjQ		rt.fn=i"inner" +h= f 	]t=escce:nam()tuditsli 
			 ={c,is[0]v//nerred; 
			 ?iogss
			.s	yil ?iogssea siFloat(sjQ		rt.css( 
			,it,
de)padd	//")	e :rnnnnc,is[it,
	](e :rnnnn				er
r 	r
r gdno derHeighQu do o derWsdthrnnjQ		rt.fn=i"o der" +h= f 	]t=escce:nam(smargim )tuditsli 
			 ={c,is[0]v//nerred; 
			 ?iogss
			.s	yil ?iogssea siFloat(sjQ		rt.css( 
			,it,
demargim ?e)margim" :e)bordir")	e :rnnnnc,is[it,
	](e :rnnnn				er
r 	r
r jQ		rt.fn=it,
	]t=escce:nam(ssde   		nitgllbGet  lojow
 sdthJ lnheightditsli 
			 ={c,is[0]v//giy.isf!
			Optiotg
	},;sdea  | 				 ? 				 :{c,is///r }/	}ny.isfjQ		rt.isFcce:nam	 sde    )tuditg
	},ic,is.eet.(acce:nams iOptionnnnsli selff fjQ		rts{c,issOInan jself=it,
	]	 sde  onhes{c,is,ii,hself=it,
	]	  )r I//r j}eI//r }//n tgy.isfjQ		rt.isWlojows 
			reOptionas usEv	rton	u
	sulus/ eateE		e.eateE		QE			leQ	or eateE		e.body dhf	 jlowoon
Q	irlt vs S	andards mctiionas us3rdJc gdi:namtallowssNokia sup/  t,s s it sup/  tt c,}JeacE			 		// buttnoGtCSS1Comea:isOr varJeacE			Pr//r|l
			.eateE		e.eateE		QE			leQ=i"clileQ" +h= f 	],isOOOObody |l
			.eateE		e.body	//jnerred; 
			.eateE		e.jomea:Mod}	=ta "CSS1Comea:"	&& eacE			Pr//r|| iatnbody	&& body=i"clileQ" +h= f 	]r|| eacE			Pr//;//nitgllbGetieateE		e
 sdthJ lnheightdi F				--	y.iss
			n,cti),
	=tar9Optionas usEiGdei scroll[Wsdth/HeighQ]J l;offsee[Wsdth/HeighQ],aw.ft.e:errissgt("dir//jnerred; Mkih<max(ionng
			.eateE		QE			leQ="clileQ" +h= f ],ionng
			.body="scroll" +h= f ],a
			.eateE		QE			leQ="scroll" +h= f ],ionng
			.body="offsee" +h= f ],a
			.eateE		QE			leQ="offsee" +h= f ]ionn);//nitgllbGeti l see
 sdthJ lnheightoonoGde 
			let	}i				--	y.i	 sde  = |n| jQuer}OptisOr varJo		g = jQ		rt.css( 
			,it,
 ),gieneerrQ	=oea siFloat(Jo		g );//nitgg
	},fjQ		rt.isNeE			c( 
	re? 
	r:Jo		g;//nits usSetic,i  sdthJ lnheightoonoGde 
			let (dhrefNteGoopix		-	y. ndef=	is unidilss)	}i				--tuditg
	},ic,is.css(it,
d /  oflsde  = |n)u			//oJ?lsde  :lsde  +="px"f ;r
i	//j}I/	}	 ;r
r
r
r
r
gd E 	osefjQ		rt GooGde globde it'sst	} lojow.jQ		rt =  lojow.$ = jQ		rt;r
r
gd E 	osefjQ		rt asianrAMD mctuil, butooilh	n lrAMD loadirtectedr
gdn| jQrs	andoGh	 )sseest shroloajlowomfNtieleenQrsnams iffjQ		rtr
gusins tcageected ;ltmight{c;l jQuer}()+sTQe loadir )illtlojic"dir
gu Gdey E v 
s 	/ia tallowanc s	n lomfNtieleejQ		rtenQrsnams btr
gu
s 	/ifylow jQuer}.amd.jQ		rt = c// . R
gisi;r asiah= f d mctuil,r
gu
sinceejQ		rt	ckmQbi conc"din"diet shrooGdei ffiltected	may us/ jQuerl,r
gu buttnoG us/ ay		//er conc"din"dnam scripQected | jQrs	andsianodymousr
gu AMD mctuils. Ah= f d AMD ue	safesQu do{most robust waylGolr
gisi;r.r
gu Lo)e ca)}ijq		rt uelus/etbuna})}oAMD mctuilh= f ssa wojQri:sdst	r
gu ffilh= f s,u doejQ		rt uesit by lh	d}	i:srsdins tlo)e ca)} ffilh= f .ioll
Do{c,issafi;r ct("dlow Gde globdefsoected	y.ianrAMD mctuil wanor	Go{c;liollsitConf);cteGoehid {c,isenQrsnam iffjQ		rt, it )illtwork.ioy.ise/  of jQuer  = |n)acce:nam"	&& jQuer}.amd	&& jQuer}.amd.jQ		ry )tuditjQuer}( "jq		rt", [],;acce:nam ()tu 
	},fjQ		rt; }
);
}/ u /	}	 	 