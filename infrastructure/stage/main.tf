resource "azurerm_resource_group" "mitigation_calculator" {
  name     = "mitigation_calculator_${var.environment_short_name}"
  count    = var.is_vritual ? 0 : 1
  location = "Switzerland North"
}

resource "azurerm_container_app" "mitigation_calculator" {
  name                         = "MitigationCalculator-Dev"
  count                        = var.is_vritual ? 0 : 1
  container_app_environment_id = var.container_app_environment_id
  resource_group_name          = azurerm_resource_group.mitigation_calculator[0].id
  revision_mode                = "Single"

  template {
    container {
      name   = "mitigationcalculator"
      image  = "ghcr.io/lumi1986/stfc.mitigationcalculator:main"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }
}