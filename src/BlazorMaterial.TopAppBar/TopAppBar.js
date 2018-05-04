Blazor.registerFunction('BlazorMaterial.TopAppBar.AttachTo', function (topAppBar) {
  mdc.topAppBar.MDCTopAppBar.attachTo(topAppBar);
  return true;
});
