Blazor.registerFunction('BlazorMaterial.AddRipple', function (button) {
  mdc.ripple.MDCRipple.attachTo(button);
  return true;
});
