Blazor.registerFunction('BlazorMaterial.AddRipple', function (message) {
  mdc.ripple.MDCRipple.attachTo(document.querySelector('.mdc-button'));
  return true;
});
