Blazor.registerFunction('BlazorMaterial.Toolbar.AttachTo', function (toolbar) {
  mdc.toolbar.MDCToolbar.attachTo(toolbar);
  return true;
});
