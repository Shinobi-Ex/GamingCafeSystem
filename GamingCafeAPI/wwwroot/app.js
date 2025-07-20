// Gaming Café Management System JavaScript

class GamingCafeManager {
    constructor() {
        this.apiUrl = 'http://localhost:5277/api'; // Updated to match your running server
        this.refreshInterval = null;
        this.init();
    }

    async init() {
        console.log('🎮 Initializing Gaming Cafe Manager...');
        
        try {
            await this.loadDashboard();
            this.setupEventListeners();
            this.startAutoRefresh();
            
            console.log('✅ Gaming Cafe Manager initialized successfully');
            this.showToast('Gaming Café System Online', 'success');
        } catch (error) {
            console.error('❌ Failed to initialize Gaming Cafe Manager:', error);
            this.showToast('Failed to connect to server', 'error');
        }
    }

    async loadDashboard() {
        try {
            console.log('📊 Loading dashboard data...');
            
            const response = await fetch(`${this.apiUrl}/dashboard`);
            
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            
            const data = await response.json();
            console.log('📈 Dashboard data loaded:', data);
            
            this.updateUI(data);
            
        } catch (error) {
            console.error('Failed to load dashboard:', error);
            this.showError('Failed to connect to server. Make sure your API is running on localhost:5277');
            throw error;
        }
    }

    updateUI(data) {
        // Update header statistics
        this.updateElement('active-stations', data.activeStations || 0);
        this.updateElement('today-revenue', `₹${this.formatNumber(data.todayRevenue || 0)}`);
        this.updateElement('network-usage', `${data.networkUsage || 0}%`);
        
        // Update server status
        if (data.serverStatus) {
            this.updateServerMetrics(data.serverStatus);
        }
        
        // Update stations grid
        if (data.stations) {
            this.updateStationsGrid(data.stations);
        }
    }

    updateElement(id, value) {
        const element = document.getElementById(id);
        if (element) {
            element.textContent = value;
        } else {
            console.warn(`⚠️ Element with id '${id}' not found`);
        }
    }

    updateServerMetrics(serverStatus) {
        // Update progress bars and values
        this.updateMetric('cpu', serverStatus.cpu || 0);
        this.updateMetric('ram', serverStatus.ram || 0);
        this.updateMetric('disk', serverStatus.disk || 0);
        
        // Update uptime
        this.updateElement('uptime', serverStatus.uptime || '0d 0h 0m');
    }

    updateMetric(type, percentage) {
        // Update progress bar
        const progressBar = document.getElementById(`${type}-progress`);
        if (progressBar) {
            progressBar.style.width = `${percentage}%`;
            
            // Add color coding based on usage
            progressBar.className = 'progress-fill';
            if (percentage > 80) {
                progressBar.style.background = 'linear-gradient(90deg, #ef4444, #dc2626)';
            } else if (percentage > 60) {
                progressBar.style.background = 'linear-gradient(90deg, #f59e0b, #d97706)';
            } else {
                progressBar.style.background = 'linear-gradient(90deg, var(--primary-color), var(--secondary-color))';
            }
        }
        
        // Update value text
        const valueElement = document.getElementById(`${type}-value`);
        if (valueElement) {
            valueElement.textContent = `${percentage}%`;
        }
    }

    updateStationsGrid(stations) {
        const grid = document.getElementById('stations-grid');
        if (!grid) {
            console.warn('⚠️ Stations grid not found');
            return;
        }

        // Clear existing content
        grid.innerHTML = '';
        
        // Create station cards
        stations.forEach(station => {
            const stationCard = this.createStationCard(station);
            grid.appendChild(stationCard);
        });
        
        console.log(`🖥️ Updated ${stations.length} gaming stations`);
    }

    createStationCard(station) {
        const card = document.createElement('div');
        card.className = 'card station-card';
        card.setAttribute('data-station-id', station.id);
        
        const statusClass = station.status.toLowerCase();
        const isGaming = station.status.toLowerCase() === 'gaming';
        
        card.innerHTML = `
            <div class="station-header">
                <h4 class="station-id">Station ${station.id}</h4>
                <span class="station-status ${statusClass}">${station.status}</span>
            </div>
            <div class="station-info">
                <div class="station-info-item">
                    <span class="station-info-label">User:</span>
                    <span class="station-info-value">${station.user || 'None'}</span>
                </div>
                <div class="station-info-item">
                    <span class="station-info-label">Session:</span>
                    <span class="station-info-value">${station.sessionDuration || '0m'}</span>
                </div>
                <div class="station-info-item">
                    <span class="station-info-label">IP Address:</span>
                    <span class="station-info-value">${station.ipAddress || 'N/A'}</span>
                </div>
                <div class="station-info-item">
                    <span class="station-info-label">CPU:</span>
                    <span class="station-info-value">${station.cpu || 0}%</span>
                </div>
                <div class="station-info-item">
                    <span class="station-info-label">RAM:</span>
                    <span class="station-info-value">${station.ram || 0}%</span>
                </div>
                <div class="station-info-item">
                    <span class="station-info-label">GPU:</span>
                    <span class="station-info-value">${station.gpu || 0}%</span>
                </div>
            </div>
            <div class="station-actions">
                <button class="btn btn--sm ${isGaming ? 'btn--secondary' : 'btn--primary'}" 
                        onclick="gamingCafe.toggleSession(${station.id}, '${station.status}', '${station.user || ''}')">
                    <i class="fas ${isGaming ? 'fa-stop' : 'fa-play'}"></i>
                    ${isGaming ? 'End Session' : 'Start Session'}
                </button>
                <button class="btn btn--sm btn--outline" 
                        onclick="gamingCafe.restartStation(${station.id})">
                    <i class="fas fa-sync-alt"></i>
                    Restart
                </button>
            </div>
        `;
        
        return card;
    }

    // Station Management Methods
    async toggleSession(stationId, currentStatus, currentUser) {
        const isGaming = currentStatus.toLowerCase() === 'gaming';
        
        if (isGaming) {
            // End session
            await this.endSession(stationId);
        } else {
            // Start session
            await this.startSession(stationId);
        }
    }

    async startSession(stationId) {
        const userName = prompt('Enter user name for the session:');
        if (!userName || userName.trim() === '') {
            this.showToast('User name is required to start a session', 'warning');
            return;
        }

        try {
            this.showToast(`Starting session for ${userName} on Station ${stationId}...`, 'info');
            
            // For now, we'll simulate the session start since we haven't implemented the endpoint yet
            await this.simulateSessionToggle(stationId, 'start', userName);
            
        } catch (error) {
            console.error('Failed to start session:', error);
            this.showToast('Failed to start session', 'error');
        }
    }

    async endSession(stationId) {
        if (!confirm(`End session for Station ${stationId}?`)) {
            return;
        }

        try {
            this.showToast(`Ending session for Station ${stationId}...`, 'info');
            
            // For now, we'll simulate the session end
            await this.simulateSessionToggle(stationId, 'end');
            
        } catch (error) {
            console.error('Failed to end session:', error);
            this.showToast('Failed to end session', 'error');
        }
    }

    async restartStation(stationId) {
        if (!confirm(`Restart Station ${stationId}? This will end any active session.`)) {
            return;
        }

        try {
            this.showToast(`Restarting Station ${stationId}...`, 'warning');
            
            // Simulate restart process
            await this.simulateRestart(stationId);
            
        } catch (error) {
            console.error('Failed to restart station:', error);
            this.showToast('Failed to restart station', 'error');
        }
    }

    // Simulation methods (until we implement full CRUD operations)
    async simulateSessionToggle(stationId, action, userName = null) {
        return new Promise((resolve) => {
            setTimeout(() => {
                const message = action === 'start' 
                    ? `Session started for ${userName} on Station ${stationId}` 
                    : `Session ended for Station ${stationId}`;
                
                this.showToast(message, 'success');
                this.loadDashboard(); // Refresh data
                resolve();
            }, 1000);
        });
    }

    async simulateRestart(stationId) {
        return new Promise((resolve) => {
            setTimeout(() => {
                this.showToast(`Station ${stationId} has been restarted successfully`, 'success');
                this.loadDashboard(); // Refresh data
                resolve();
            }, 2000);
        });
    }

    // Event Listeners Setup
    setupEventListeners() {
        // Navigation buttons
        document.querySelectorAll('.nav-btn').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const sectionId = e.currentTarget.getAttribute('data-section');
                this.showSection(sectionId);
            });
        });

        // Quick action buttons
        document.addEventListener('click', async (e) => {
            const button = e.target.closest('.btn');
            if (!button) return;

            const buttonText = button.textContent.trim();
            
            if (buttonText.includes('Restart All Stations')) {
                await this.restartAllStations();
            } else if (buttonText.includes('System Health Check')) {
                await this.performHealthCheck();
            } else if (buttonText.includes('Refresh Status')) {
                await this.refreshDashboard();
            }
        });
    }

    async restartAllStations() {
        if (!confirm('Restart all stations? This will end all active gaming sessions.')) {
            return;
        }
        
        this.showToast('Initiating restart for all stations...', 'warning');
        
        // Simulate mass restart
        setTimeout(() => {
            this.showToast('All stations have been restarted successfully', 'success');
            this.loadDashboard();
        }, 3000);
    }

    async performHealthCheck() {
        this.showToast('Performing comprehensive system health check...', 'info');
        
        try {
            // Test API connectivity
            await this.loadDashboard();
            
            setTimeout(() => {
                this.showToast('✅ System Health Check Complete - All systems operational', 'success');
            }, 2000);
            
        } catch (error) {
            this.showToast('❌ System Health Check Failed - Issues detected', 'error');
        }
    }

    async refreshDashboard() {
        this.showToast('Refreshing dashboard data...', 'info');
        try {
            await this.loadDashboard();
            this.showToast('Dashboard refreshed successfully', 'success');
        } catch (error) {
            this.showToast('Failed to refresh dashboard', 'error');
        }
    }

    // Navigation
    showSection(sectionId) {
        // Hide all sections
        document.querySelectorAll('.section').forEach(section => {
            section.classList.remove('active');
        });
        
        // Show selected section
        const targetSection = document.getElementById(sectionId);
        if (targetSection) {
            targetSection.classList.add('active');
        }
        
        // Update navigation buttons
        document.querySelectorAll('.nav-btn').forEach(btn => {
            btn.classList.remove('active');
        });
        
        const activeBtn = document.querySelector(`.nav-btn[data-section="${sectionId}"]`);
        if (activeBtn) {
            activeBtn.classList.add('active');
        }
    }

    // Auto-refresh functionality
    startAutoRefresh() {
        // Refresh every 15 seconds
        this.refreshInterval = setInterval(() => {
            this.loadDashboard().catch(error => {
                console.warn('Auto-refresh failed:', error);
            });
        }, 15000);
        
        console.log('🔄 Auto-refresh started (every 15 seconds)');
    }

    stopAutoRefresh() {
        if (this.refreshInterval) {
            clearInterval(this.refreshInterval);
            this.refreshInterval = null;
            console.log('🔄 Auto-refresh stopped');
        }
    }

    // Utility Methods
    formatNumber(num) {
        return new Intl.NumberFormat('en-IN').format(num);
    }

    showToast(message, type = 'info') {
        const toastContainer = document.querySelector('.toast-container') || this.createToastContainer();
        
        const toast = document.createElement('div');
        toast.className = `toast ${type}`;
        
        // Add appropriate icon
        const icons = {
            success: 'fas fa-check-circle',
            error: 'fas fa-exclamation-circle',
            warning: 'fas fa-exclamation-triangle',
            info: 'fas fa-info-circle'
        };
        
        toast.innerHTML = `
            <i class="${icons[type] || icons.info}"></i>
            <span>${message}</span>
        `;
        
        toastContainer.appendChild(toast);
        
        // Auto-remove after 5 seconds
        setTimeout(() => {
            toast.remove();
        }, 5000);
        
        console.log(`📢 ${type.toUpperCase()}: ${message}`);
    }

    showError(message) {
        this.showToast(message, 'error');
        
        // Also log to console for debugging
        console.error('🚨 System Error:', message);
    }

    createToastContainer() {
        const container = document.createElement('div');
        container.className = 'toast-container';
        document.body.appendChild(container);
        return container;
    }

    // Cleanup
    destroy() {
        this.stopAutoRefresh();
        console.log('🎮 Gaming Cafe Manager destroyed');
    }
}

// Initialize the application when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    // Create global instance
    window.gamingCafe = new GamingCafeManager();
    
    console.log('🚀 Gaming Café Management System Loaded');
});

// Handle page unload
window.addEventListener('beforeunload', () => {
    if (window.gamingCafe) {
        window.gamingCafe.destroy();
    }
});
