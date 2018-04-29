Blazor.registerFunction('BlazorMaterial.Toolbar.AttachTo', function (message) {
  mdc.toolbar.MDCToolbar.attachTo(document.querySelector('.mdc-toolbar'));
  return true;
});
