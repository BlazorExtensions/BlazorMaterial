Blazor.registerFunction('BlazorMaterial.Drawer.AttachTo', function (drawer, persistent) {
  if (persistent) {
    mdc.drawer.MDCPersistentDrawer.attachTo(drawer);
  } else {
    mdc.drawer.MDCTemporaryDrawer.attachTo(drawer);
  }
  return true;
});
